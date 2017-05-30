using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BitwaMorska
{
    public enum Direction { Up, Down, Right, Left, Shoot, None }
    public enum ShipColor { Red, Green, Violet, Yellow, None }
    public enum GameState { NoGame, Singleplayer, Multiplayer }
    public enum ObjectType { Ship, Rocket, Mountain, IceMountain }

    [Serializable()]
    public class DataPacket
    {
        public DataPacket() { }

        public DataPacket(int id, string command, ObjectType type, int x, int y, ShipColor color, Direction direction, string name)
        {
            this.ClientId = id;
            this.Command = command;
            this.Type = type;
            this.Location = new Point(x, y);
            this.Color = color;
            this.Direction = direction;
            this.Name = name;
        }

        public int ClientId;
        public ObjectType Type;
        public string Command;
        public Point Location;
        public ShipColor Color;
        public Direction Direction;
        public string Name;
    }

    public class ServerCommands
    {
        public const string OK = "OK";
        public const string Error = "serror";
        public const string Disconnect = "disconnect";
        public const string Move = "smove";
        public const string Die = "die";
        public const string Spawn = "spawn";
        public const string AddShip = "addship";
        public const string GetId = "getid";
        public const string UpdatePoints = "updatepoints";
        public const string GetPoints = "getpoints";
        public const string GameOver = "gameover";
    }

    public class ClientCommands
    {
        public const string Connect = "connect";
        public const string Disconnect = "disconnect";
        public const string Move = "cmove";
        public const string Shoot = "shoot";
        public const string Stop = "stop";
        public const string Error = "cerror";
    }

    public static class Constants
    {
        public const int IMG_SIZE = 40;

        public const int TIMER_INTERVAL = 20;
 
        public const int SHIP_SPEED = 10;

        public const int ROCKET_SPEED = 31;
        public const int SHOT_INTERVAL = 300;
        public const int VULNERABLE_INTERVAL = 1000;

        public const int RESPAWN_RED_X = 50;
        public const int RESPAWN_RED_Y = 50;

        public const int RESPAWN_GREEN_X = 890;
        public const int RESPAWN_GREEN_Y = 350;

        public const int RESPAWN_VIOLET_X = 790;
        public const int RESPAWN_VIOLET_Y = 50;

        public const int RESPAWN_YELLOW_X = 50;
        public const int RESPAWN_YELLOW_Y = 350;

        public const int POINTS_TO_WIN = 15;

    }

    public static class ShipNames
    {
        public const string Red = "ship_red";
        public const string Green = "ship_green";
        public const string Violet = "ship_violet";
        public const string Yellow = "ship_yellow";
    }
}
