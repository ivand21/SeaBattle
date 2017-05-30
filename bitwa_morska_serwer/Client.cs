using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace bitwa_morska_serwer
{
    public class Client
    {
        public Map Map {get; set;}
        public TcpClient Socket { get; set; }
        public int Id { get; set; }
        public int Kills { get { return Ship.Kills; } }
        public int Deaths { get { return Ship.Deaths; } }
        public int Points { get { return Ship.Points; } }
        public Ship Ship { get { return Map.Objects[Id] as Ship; } }

        public Client(int id, TcpClient socket, Map map)
        {
            Id = id;
            Socket = socket;
            Map = map;
        }
    }
}
