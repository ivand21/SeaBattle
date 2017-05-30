using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using BitwaMorska;

namespace bitwa_morska_serwer
{
    public partial class mainForm : Form
    {
        Map Map { get; set; }
        int ClientsNo { get; set; }
        public List<Client> Clients { get; set; }
        public bool ClientPending { get; set; }

        public mainForm()
        {
            InitializeComponent();
            Map = new Map(mapPanel, this);
            ClientsNo = 0;
            Clients = new List<Client>();
            txtIpAdress.Text = GetIpAdress();

        }

        private TcpListener Listener = null;
        private TcpClient Server = null;
        public bool IsConnected = false;
        public BinaryReader r = null;
        public BinaryWriter w = null;
        public NetworkStream Stream = null;


        public void Log(string txt)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke((Action)delegate ()
                {
                    txtLog.Focus();
                    txtLog.AppendText(txt + '\n');
                    txtLog.ScrollToCaret();
                });
            }
            else
            {
                txtLog.Focus();
                txtLog.AppendText(txt + '\n');
                txtLog.ScrollToCaret();
            }
        }

        public void SendingLog(DataPacket packet)
        {
            sendLog.Focus();
            sendLog.AppendText(packet.Command + " ");
            sendLog.AppendText(" name: " + packet.Type + " " + packet.Location.X + " " + packet.Location.Y);
            sendLog.ScrollToCaret();
        }

        private void OnKeyPressed(string name, Direction direction)
        {
            Ship s = Map.GetShipByName(name);
            s.GetDirection(direction);
        }

        private void OnKeyUp(string name)
        {
            Ship s = Map.GetShipByName(name);
            s.Stop();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Listener = new TcpListener(IPAddress.Parse(txtIpAdress.Text), 1024);
            Server = new TcpClient();
            Log("Server");
            Log("Listening on port 1024.");
            Log("Waiting for clients...");
            button1.Enabled = false;
            Listener.Start();
            Map.Timer.Enabled = true;
            ListenThread.RunWorkerAsync();
        }

        private void ListenThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                TcpClient newClient = Listener.AcceptTcpClient();

                if (Clients.Count < 4)
                {
                    Log("Client connected.");
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.Start(newClient);
                    Thread.Sleep(100);
                }
                else
                {
                    var packet = new DataPacket(0, ServerCommands.Disconnect, ObjectType.Ship, 0, 0, ShipColor.None, Direction.None, "Przekroczono limit graczy.");
                    var bw = new BinaryWriter(newClient.GetStream());
                    bw.Write(PacketToString(packet));
                    newClient.GetStream().Close();
                    newClient.Close();
                    Log("Client denied.");
                }

            }
        }

        private string GetIpAdress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            button1.Enabled = false;
            Log("Błąd połączenia z siecią!");
            return "...";
        }


        private void HandleClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            BinaryWriter writer = new BinaryWriter(clientStream);
            BinaryReader reader = new BinaryReader(clientStream);

            var _id = SendId(writer);
            SendMap(writer, reader);

            Clients.Add(new Client(_id, tcpClient, Map));

            var sPacket = new DataPacket
            {
                Command = ServerCommands.Spawn,
                ClientId = _id,
                Color = (Map.Objects[_id] as Ship).Color,
                Direction = (Map.Objects[_id] as Ship).Direction,
                Location = (Map.Objects[_id] as Ship).Location,
                Type = ObjectType.Ship,
                Name = (Map.Objects[_id] as Ship).Name
            };

            (Map.Objects[_id]).Invoke((Action)delegate ()
               {
                   Map.Objects[_id].IsAlive = true;
                   Map.Objects[_id].Visible = true;
               });

            var strPacket = PacketToString(sPacket);

            foreach (var c in Clients.Where(c => c.Id != sPacket.ClientId))
            {
                var _writer = new BinaryWriter(c.Socket.GetStream());
                _writer.Write(strPacket);
                SendScores(_writer);
            }

            sPacket.Command = ServerCommands.AddShip;
            writer.Write(PacketToString(sPacket));
            SendScores(writer);
            ClientPending = false;

            while (true)
            {
                try
                {
                    var str = reader.ReadString();
                    DataPacket packet = PacketFromString(str);

                    if (packet == null) continue;
                    if (packet.Command == ClientCommands.Move)
                    {
                        (Map.Objects[packet.ClientId] as Ship).GetDirection(packet.Direction);
                    }
                    else if (packet.Command == ClientCommands.Stop)
                        Map.ShipStop((Map.Objects[packet.ClientId] as Ship));
                    else if (packet.Command == ClientCommands.Shoot)
                    {
                        (Map.Objects[packet.ClientId] as Ship).GetDirection(Direction.Shoot);
                    }
                    else if (packet.Command == ClientCommands.Error)
                        continue;
                    else if (packet.Command == ClientCommands.Disconnect)
                    {
                        Map.DeleteShip(Map.Objects[packet.ClientId] as Ship);
                        var _client = Clients.First(c => c.Id == packet.ClientId);
                        _client.Socket.GetStream().Close();
                        _client.Socket.Close();
                        Clients.Remove(_client);
                        DataPacket dcPacket = new DataPacket(packet.ClientId, ServerCommands.Die, ObjectType.Ship, 0, 0, (ShipColor)packet.ClientId, Direction.None, Map.Objects[packet.ClientId].Name);
                        foreach (var c in Clients)
                        {
                            SendData(dcPacket);
                        }
                        return;
                    }
                    else
                        continue;
                }
                catch (EndOfStreamException ex)
                {
                    return;
                }
                catch (IOException ex)
                {
                    return;
                }
            }
        }

        private string PacketToString(DataPacket packet)
        {
            string toSend = "";
            toSend += packet.ClientId + ";";
            toSend += packet.Command + ";";
            toSend += (int)packet.Type + ";";
            toSend += packet.Location.X + ";";
            toSend += packet.Location.Y + ";";
            toSend += (int)packet.Color + ";";
            toSend += (int)packet.Direction + ";";
            toSend += packet.Name;
            return toSend;
        }


        private DataPacket PacketFromString(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str)) return null;
                DataPacket packet = new DataPacket();
                string[] data = str.Split(';');
                if (data.Count() < 8) return null;
                packet.ClientId = int.Parse(data[0]);
                packet.Command = data[1];
                packet.Type = (ObjectType)int.Parse(data[2]);
                packet.Location = new Point(int.Parse(data[3]), int.Parse(data[4]));
                packet.Color = (ShipColor)int.Parse(data[5]);
                packet.Direction = (Direction)int.Parse(data[6]);
                packet.Name = data[7];
                return packet;
            }
            catch (FormatException ex)
            {
                return new DataPacket(0, ServerCommands.Error, ObjectType.IceMountain, 0, 0, 0, 0, ex.Message);
            }
        }

        public int SendId(BinaryWriter writer)
        {
            int id = 0;
            for (; id<4; id++)
            {
                if (!Map.Objects[id].IsAlive)
                    break;
            }

            var packet = new DataPacket
            {
                ClientId = id,
                Command = ServerCommands.GetId,
                Type = ObjectType.Ship,
                Location = new Point(0, 0),
                Name = "",
                Direction = Direction.None,
                Color = ShipColor.None
            };
            writer.Write(PacketToString(packet));
            return id;
        }

        public void SendData(DataPacket packet)
        {
            foreach (var c in Clients)
            {
                try
                {
                    var writer = new BinaryWriter(c.Socket.GetStream());
                    writer.Write(PacketToString(packet));
                }
                catch (Exception ex)
                { continue; }
            }
        }

        private void SendMap(BinaryWriter writer, BinaryReader reader)
        {
            foreach (var o in Map.Objects.Where(o => o.IsAlive))
            {
                var packet = new DataPacket
                {
                    ClientId = 0,
                    Command = ServerCommands.Spawn,
                    Type = o.Type,
                    Location = o.Location,
                    Name = o.Name,
                    Direction = Direction.None,
                    Color = ShipColor.None
                };
                var s = o as Ship;
                if (s != null)
                {
                    packet.Color = s.Color;
                    packet.Direction = s.Direction;
                }
                writer.Write(PacketToString(packet));
                var response = reader.ReadString();
            }
            foreach (var m in Map.Mountains.Where(m => m.IsAlive))
            {
                var packet = new DataPacket
                {
                    ClientId = 0,
                    Command = ServerCommands.Spawn,
                    Type = m.Type,
                    Location = m.Location,
                    Name = m.Name,
                    Direction = Direction.None,
                    Color = ShipColor.None
                };
                var str = PacketToString(packet);
                writer.Write(str);
            }
        }

        private void SendScores(BinaryWriter writer)
        {

            for (int i = 0; i < 4; i++)
            {
                var ship = Map.Objects[i] as Ship;

                ship.Invoke((Action)delegate ()
                {

                    if (ship.IsAlive)
                    {
                        var packet = new DataPacket
                        {
                            ClientId = i,
                            Command = ServerCommands.GetPoints,
                            Type = ObjectType.Ship,
                            Location = new Point(ship.Kills, ship.Deaths),
                            Name = ship.Name,
                            Direction = Direction.None,
                            Color = ship.Color
                        };
                        writer.Write(PacketToString(packet));
                    }
                });
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Map.Timer.Enabled)
            {
                var packet = new DataPacket
                {
                    Command = ServerCommands.Disconnect,
                    ClientId = 0,
                    Type = ObjectType.IceMountain,
                    Location = new Point(0, 0),
                    Name = "Serwer rozłączony.",
                    Direction = Direction.None,
                    Color = ShipColor.None
                };
                foreach (var c in Clients)
                {
                    SendData(packet);
                    
                    c.Socket.GetStream().Close();
                    c.Socket.Close();
                }
            }
        }

        public void EndGame(Ship winner)
        {
            DataPacket packet = new DataPacket(0, ServerCommands.GameOver, ObjectType.Ship, 0, 0, winner.Color, winner.Direction, winner.Name);
            SendData(packet);
        }
    }
}
