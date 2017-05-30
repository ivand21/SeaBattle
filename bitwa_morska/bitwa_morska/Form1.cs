using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using BitwaMorska;
using System.Runtime.Serialization.Formatters.Binary;

namespace bitwa_morska
{
    public partial class mainForm : Form
    {

        public Ship Ship { get; set; }
        public Map Map { get; set; }
        public GameState Mode { get; set; }
        public int ClientId { get; set; }

        private TcpClient Client { get; set; }
        public bool IsConnected { get; set; }
        public BinaryReader Reader { get; set; }
        public BinaryWriter Writer { get; set; }

        public readonly List<Image> PlayerImages = new List<Image>
        {
            Properties.Resources.img_red,
            Properties.Resources.icon_green,
            Properties.Resources.icon_violet,
            Properties.Resources.icon_yellow
        };

        public mainForm()
        {
            InitializeComponent();
            Mode = GameState.NoGame;
        }



        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Mode == GameState.Singleplayer)
            {
                if (gamePanel.Enabled)
                {
                    Ship.GetDirection(e);
                }
            }
            else if (Mode == GameState.Multiplayer && IsConnected && Ship != null)
            {
                NetworkStream Stream = Client.GetStream();
                if (e.KeyCode == Keys.Up)
                    SendData(new DataPacket(ClientId, ClientCommands.Move, ObjectType.Ship, 0, 0, Ship.Color, Direction.Up, Ship.Name));
                else if (e.KeyCode == Keys.Down)
                    SendData(new DataPacket(ClientId, ClientCommands.Move, ObjectType.Ship, 0, 0, Ship.Color, Direction.Down, Ship.Name));
                else if (e.KeyCode == Keys.Left)
                    SendData(new DataPacket(ClientId, ClientCommands.Move, ObjectType.Ship, 0, 0, Ship.Color, Direction.Left, Ship.Name));
                else if (e.KeyCode == Keys.Right)
                    SendData(new DataPacket(ClientId, ClientCommands.Move, ObjectType.Ship, 0, 0, Ship.Color, Direction.Right, Ship.Name));

                if (e.KeyCode == Keys.Space)
                    SendData(new DataPacket(ClientId, ClientCommands.Shoot, ObjectType.Ship, 0, 0, Ship.Color, Direction.Shoot, Ship.Name));

            }
        }

        private void mainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (Mode == GameState.Singleplayer)
            {
                if (gamePanel.Enabled)
                {
                    Ship.Stop(e);
                }
            }
            else if (Mode == GameState.Multiplayer && IsConnected && Ship != null)
            {
                SendData(new DataPacket(ClientId, ClientCommands.Stop, ObjectType.Ship, 0, 0, Ship.Color, 0, Ship.Name));
            }
        }

        #region menu buttons
        private void menuHelpButton_Click(object sender, EventArgs e)
        {
            menuPanel.Enabled = false;
            menuPanel.Visible = false;
            howToPlayPanel.Enabled = true;
            howToPlayPanel.Visible = true;
        }

        //how to play -> menu
        private void htp2menuButton_Click(object sender, EventArgs e)
        {
            howToPlayPanel.Enabled = false;
            howToPlayPanel.Visible = false;
            menuPanel.Enabled = true;
            menuPanel.Visible = true;
        }

        // about author -> menu
        private void aa2menuButton_Click(object sender, EventArgs e)
        {

            aboutAuthorPanel.Enabled = false;
            aboutAuthorPanel.Visible = false;
            menuPanel.Enabled = true;
            menuPanel.Visible = true;
        }

        private void menuExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuCreditsButton_Click(object sender, EventArgs e)
        {
            menuPanel.Enabled = false;
            menuPanel.Visible = false;
            aboutAuthorPanel.Enabled = true;
            aboutAuthorPanel.Visible = true;
        }

        private void menuSingleplayerButton_Click(object sender, EventArgs e)
        {
            if (Map != null)
            {
                Map.Objects.RemoveAll(c => c.Image != null);
                Map.Objects.RemoveAll(c => c.Image != null);
                Ship.Dispose();
            }

            Mode = GameState.Singleplayer;
            Map = new Map(mapPanel, this);
            Ship = new Ship(Map, Constants.RESPAWN_RED_X, Constants.RESPAWN_RED_Y, true);
            txtDeathsValue.Text = Ship.Deaths.ToString();
            txtKillsValue.Text = Ship.Kills.ToString();
            txtPointsValue.Text = (10 * Ship.Kills - 5 * Ship.Deaths).ToString();
            menuPanel.Enabled = false;
            menuPanel.Visible = false;
            gamePanel.Enabled = true;
            gamePanel.Visible = true;
        }

        private void menuMultiplayerButton_Click(object sender, EventArgs e)
        {
            try
            {

                Client = new TcpClient();
                Client.Connect(IPAddress.Parse(tbIpAddress.Text), 1024);


                Mode = GameState.Multiplayer;
                //deathsValue.Text = ship.deaths.ToString();
                //killsValue.Text = ship.kills.ToString();
                //pointsValue.Text = (10 * ship.kills - 5 * ship.deaths).ToString();

                menuPanel.Enabled = false;
                menuPanel.Visible = false;
                gamePanel.Enabled = true;
                gamePanel.Visible = true;

                Ship = new Ship();
                ReceivingThread.RunWorkerAsync();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Nie mogę połączyć z serwerem.");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Nieprawidłowy adres IP.");
            }

           
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsConnected)
            {
                DataPacket packet = new DataPacket(ClientId, ClientCommands.Disconnect, ObjectType.Ship, 0, 0, ShipColor.None, Direction.None, "");
                SendData(packet);
                Client.GetStream().Close();
                Client.Close();
                IsConnected = false;
            }
            ReceivingThread.CancelAsync();
        }

        #endregion

        private void ReceivingThread_DoWork(object sender, DoWorkEventArgs e)
        {
            Reader = new BinaryReader(Client.GetStream());
            Writer = new BinaryWriter(Client.GetStream());


            IsConnected = true;
            Map = new Map(mapPanel, this);



            while (true)
            {
                var received = Reader.ReadString();
                var packet = PacketFromString(received);
                if (packet == null) continue;
                switch (packet.Command)
                {
                    case ServerCommands.GetId:
                        ClientId = packet.ClientId;
                        break;
                    case ServerCommands.AddShip:
                        this.Invoke((Action)delegate ()
                       {
                           Ship = new Ship(Map, true, packet.Color);
                           playerShipImage.Image = PlayerImages[packet.ClientId];
                       });
                        break;
                    case ServerCommands.Spawn:
                        this.Invoke((Action)delegate ()
                        {
                            Map.AddObject(Map, packet.Location.X, packet.Location.Y, packet.Type, packet.Name, packet.Color);
                        });
                        Writer.Write("OK");
                        break;
                    case ServerCommands.Move:
                        var obj = Map.GetObjectByName(packet.Name);

                        if (obj.InvokeRequired)
                        {
                            obj.Invoke((Action)delegate ()
                            {
                                obj.Location = packet.Location;
                                Map.Rotate(obj, packet.Direction);
                            });
                        }
                        else
                        {
                            obj.Location = packet.Location;
                            Map.Rotate(obj, packet.Direction);
                        }
                        break;
                    case ServerCommands.Die:
                        var toDie = Map.GetObjectByName(packet.Name);
                        Map.Destroy(toDie);
                        break;
                    case ServerCommands.UpdatePoints:
                        UpdateScores(packet);
                        break;
                    case ServerCommands.GetPoints:
                        SetScores(packet);
                        break;
                    case ServerCommands.Disconnect:
                        Client.GetStream().Close();
                        Client.Close();
                        IsConnected = false;
                        EndGame(packet.Name);
                        return;
                    case ServerCommands.Error:
                        continue;
                    case ServerCommands.GameOver:
                        EndGame("Koniec gry! Zwycięzca: " + packet.Color);
                        break;
                    default:
                        continue;
                }
            }
        }


        private void SendData(DataPacket packet)
        {
            Writer.Write(PacketToString(packet));
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
            catch (FormatException e)
            {
                return new DataPacket(0, ClientCommands.Error, ObjectType.IceMountain, 0, 0, 0, 0, e.Message);
            }
        }

        public void UpdateScores(DataPacket packet)
        {
            switch (packet.Color)
            {
                case ShipColor.Red:
                    if (packet.Name == "kill") IncrementScore(txtRedKills);
                    else if (packet.Name == "death") IncrementScore(txtRedDeaths);
                    else
                    {
                        IncrementScore(txtRedKills);
                        IncrementScore(txtRedDeaths);
                    }
                    ComputePoints(txtRedPoints, txtRedKills, txtRedDeaths);
                    if (this.Ship.Color == ShipColor.Red)
                        UpdateInfoPanel(txtRedPoints, txtRedKills, txtRedDeaths);
                    break;
                case ShipColor.Green:
                    if (packet.Name == "kill") IncrementScore(txtGreenKills);
                    else if (packet.Name == "death") IncrementScore(txtGreenDeaths);
                    else
                    {
                        IncrementScore(txtGreenKills);
                        IncrementScore(txtGreenDeaths);
                    }
                    ComputePoints(txtGreenPoints, txtGreenKills, txtGreenDeaths);
                    if (this.Ship.Color == ShipColor.Green)
                        UpdateInfoPanel(txtGreenPoints, txtGreenKills, txtGreenDeaths);
                    break;
                case ShipColor.Violet:
                    if (packet.Name == "kill") IncrementScore(txtVioletKills);
                    else if (packet.Name == "death") IncrementScore(txtVioletDeaths);
                    else
                    {
                        IncrementScore(txtVioletKills);
                        IncrementScore(txtVioletDeaths);
                    }
                    ComputePoints(txtVioletPoints, txtVioletKills, txtVioletDeaths);
                    if (this.Ship.Color == ShipColor.Violet)
                        UpdateInfoPanel(txtVioletPoints, txtVioletKills, txtVioletDeaths);
                    break;
                case ShipColor.Yellow:
                    if (packet.Name == "kill") IncrementScore(txtYellowKills);
                    else if (packet.Name == "death") IncrementScore(txtYellowDeaths);
                    else
                    {
                        IncrementScore(txtYellowKills);
                        IncrementScore(txtYellowDeaths);
                    }
                    ComputePoints(txtYellowPoints, txtYellowKills, txtYellowDeaths);
                    if (this.Ship.Color == ShipColor.Yellow)
                        UpdateInfoPanel(txtYellowPoints, txtYellowKills, txtYellowDeaths);
                    break;
            }
        }

        private void UpdateInfoPanel(Label points, Label kills, Label deaths)
        {
            txtKillsValue.Invoke((Action) delegate() { txtKillsValue.Text = kills.Text; });
            txtDeathsValue.Invoke((Action)delegate () { txtDeathsValue.Text = deaths.Text; });
            txtPointsValue.Invoke((Action)delegate () { txtPointsValue.Text = points.Text; });
        }

        private void SetScores(DataPacket packet)
        {
            switch (packet.Color)
            {
                case ShipColor.Red:
                    SetDownloadedScore(txtRedKills, txtRedDeaths, txtRedPoints, packet);
                    break;
                case ShipColor.Green:
                    SetDownloadedScore(txtGreenKills, txtGreenDeaths, txtGreenPoints, packet);
                    break;
                case ShipColor.Violet:
                    SetDownloadedScore(txtVioletKills, txtVioletDeaths, txtVioletPoints, packet);
                    break;
                case ShipColor.Yellow:
                    SetDownloadedScore(txtYellowKills, txtYellowDeaths, txtYellowPoints, packet);
                    break;
                default:
                    break;
            }
        }

        public void IncrementScore(Label label)
        {
            label.Invoke((Action)delegate () { label.Text = (int.Parse(label.Text) + 1).ToString(); });
        }

        public void SetDownloadedScore(Label kills, Label deaths, Label points, DataPacket packet)
        {
            kills.Invoke((Action)delegate () { kills.Text = packet.Location.X.ToString(); });
            deaths.Invoke((Action)delegate () { deaths.Text = packet.Location.Y.ToString(); });
            var kd = packet.Location.X * 10 - packet.Location.Y * 5;

            points.Invoke((Action)delegate () { points.Text = kd.ToString(); });
        }


        public void ComputePoints(Label points, Label kills, Label deaths)
        {
            var kd = int.Parse(kills.Text) * 10 - int.Parse(deaths.Text) * 5;
            points.Invoke((MethodInvoker)(() => points.Text = kd.ToString()));
        }

        public void EndGame(string message)
        {
            gamePanel.Invoke((Action)delegate ()
            {
                ReceivingThread.CancelAsync();
                gamePanel.Enabled = false;
                gamePanel.Visible = false;
            });
            menuPanel.Invoke((Action)delegate ()
            {
                menuPanel.Enabled = true;
                menuPanel.Visible = true;
                MessageBox.Show(message);
            });

        }

    }
}