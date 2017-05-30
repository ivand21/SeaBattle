using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using BitwaMorska;
using System.Timers;

namespace bitwa_morska_serwer
{
    [Serializable]
    public class Ship : MapObject
    {
        public ShipColor Color { get; set; }
        public bool IsReadyToShoot
        {
            get
            { return _IsReadyToShoot; }
            set
            {
                _IsReadyToShoot = value;
                if (value == false)
                {
                    ShotTimer.Start();
                }
            }
        }

        public bool IsVulnerable
        {
            get
            {
                return _IsVulnerable;
            }
            set
            {
                _IsVulnerable = value;
                if (value == false)
                {
                    VulnerableTimer.Start();
                }
            }
        }

        public Direction Direction { get; set; }
        public int Kills
        {
            get { return _Kills; }

            set
            {
                _Kills = value;
                if (Points >= Constants.POINTS_TO_WIN)
                {
                    Map.Timer.Enabled = false;
                    Form.Log("Koniec");
                    Form.EndGame(this);
                }
            }
        }
        private int _Kills;

        public int Deaths { get; set; }
        public System.Timers.Timer ShotTimer { get; set; }
        public System.Timers.Timer VulnerableTimer { get; set; }
        public int Points
        {
            get
            {
                var kd = Kills * 10 - Deaths * 5;
                if (kd >= 0) return kd;
                else return 0;
            }
        }

        public bool _IsReadyToShoot;
        public bool _IsVulnerable;

        public Ship(Map Map, ShipColor color) : base(Map, 0, 0)
        {
            {
                this.Color = color;
                switch (color)
                {
                    case ShipColor.Red:
                        this.Name = "ship_red";
                        this.Image = Properties.Resources.icon_red_right;
                        this.Location = new Point(Constants.RESPAWN_RED_X, Constants.RESPAWN_RED_Y);
                        this.Direction = Direction.Right;
                        break;
                    case ShipColor.Green:
                        this.Name = "ship_green";
                        this.Image = Properties.Resources.icon_green_left;
                        this.Location = new Point(Constants.RESPAWN_GREEN_X, Constants.RESPAWN_GREEN_Y);
                        this.Direction = Direction.Left;
                        break;
                    case ShipColor.Violet:
                        this.Name = "ship_violet";
                        this.Image = Properties.Resources.icon_violet_left;
                        this.Location = new Point(Constants.RESPAWN_VIOLET_X, Constants.RESPAWN_VIOLET_Y);
                        this.Direction = Direction.Left;
                        break;
                    case ShipColor.Yellow:
                        this.Name = "ship_yellow";
                        this.Image = Properties.Resources.icon_yellow_right;
                        this.Location = new Point(Constants.RESPAWN_YELLOW_X, Constants.RESPAWN_YELLOW_Y);
                        this.Direction = Direction.Right;
                        break;
                }
                this.IsAlive = true;
                this.IsReadyToShoot = true;
                this.Kills = 0;
                this.Deaths = 0;
                this.Type = ObjectType.Ship;
                this.ShotTimer = new System.Timers.Timer();
                ShotTimer.AutoReset = false;
                ShotTimer.Elapsed += ShotTimerTick;
                ShotTimer.Interval = Constants.SHOT_INTERVAL;
                this.VulnerableTimer = new System.Timers.Timer();
                VulnerableTimer.AutoReset = false;
                VulnerableTimer.Elapsed += VulnerableTimerTick;
                VulnerableTimer.Interval = Constants.VULNERABLE_INTERVAL;
                this.IsVulnerable = false;

            }
        }


        public Ship(Map Map, ShipColor color, string name) : base(Map, 0, 0)
        {
            this.Color = color;
            switch (color)
            {
                case ShipColor.Red:
                    this.Image = Properties.Resources.icon_red_right;
                    this.Location = new Point(Constants.RESPAWN_RED_X, Constants.RESPAWN_RED_Y);
                    break;
                case ShipColor.Green:
                    this.Image = Properties.Resources.icon_green_right;
                    this.Location = new Point(Constants.RESPAWN_GREEN_X, Constants.RESPAWN_GREEN_Y);
                    break;
                case ShipColor.Violet:
                    this.Image = Properties.Resources.icon_violet_right;
                    this.Location = new Point(Constants.RESPAWN_VIOLET_X, Constants.RESPAWN_VIOLET_Y);
                    break;
                case ShipColor.Yellow:
                    this.Image = Properties.Resources.icon_yellow_right;
                    this.Location = new Point(Constants.RESPAWN_YELLOW_X, Constants.RESPAWN_YELLOW_Y);
                    break;
            }
            this.IsAlive = true;
            this.Name = name;
            this.IsReadyToShoot = true;
            this.Direction = Direction.Right;
            this.Map.Objects.Add(this);
            this.Kills = 0;
            this.Deaths = 0;
            this.Type = ObjectType.Ship;
            this.ShotTimer = new System.Timers.Timer();
            ShotTimer.Elapsed += ShotTimerTick;
            ShotTimer.Interval = Constants.SHOT_INTERVAL;
            this.VulnerableTimer = new System.Timers.Timer();
            VulnerableTimer.AutoReset = false;
            VulnerableTimer.Elapsed += VulnerableTimerTick;
            VulnerableTimer.Interval = Constants.VULNERABLE_INTERVAL;
            this.IsVulnerable = false;

            //if (Form.IsConnected)
            //    Form.SendData(new DataPacket(ServerCommands.Spawn, this.Name, Location.X, Location.Y, color, Direction));
        }

        private void ShotTimerTick(object sender, EventArgs e)
        {
            IsReadyToShoot = true;
        }

        private void VulnerableTimerTick(object sender, ElapsedEventArgs e)
        {
            IsVulnerable = true;
        }


        public void GetDirection(Direction dir)
        {
            if (this.InvokeRequired)
                this.Invoke((Action)delegate ()
               {
                   if (IsAlive)
                   {
                       if (dir == Direction.Left)
                       {
                           if (SpeedX >= 0) SpeedX = -Constants.SHIP_SPEED;
                           SpeedY = 0;
                           this.Direction = Direction.Left;
                           Rotate(this.Direction);
                       }
                       else if (dir == Direction.Right)
                       {
                           if (SpeedX <= 0) SpeedX = Constants.SHIP_SPEED;
                           SpeedY = 0;
                           this.Direction = Direction.Right;
                           Rotate(this.Direction);
                       }
                       else if (dir == Direction.Up)
                       {
                           if (SpeedY >= 0) SpeedY = -Constants.SHIP_SPEED;
                           SpeedX = 0;
                           this.Direction = Direction.Up;
                           Rotate(this.Direction);
                       }
                       else if (dir == Direction.Down)
                       {
                           if (SpeedY <= 0) SpeedY = Constants.SHIP_SPEED;
                           SpeedX = 0;
                           this.Direction = Direction.Down;
                           Rotate(this.Direction);
                       }

                       if (dir == Direction.Shoot)
                       {
                           if (IsReadyToShoot)
                           {
                               Shoot();
                           }
                       }
                   }
               });
        }

        public void Stop()
        {
            SpeedX = 0;
            SpeedY = 0;
        }

        public void Shoot()
        {
            Rocket r = new Rocket(this.Map, this, Direction);
            IsReadyToShoot = false;
            IsVulnerable = true;
        }

        public void CollisionWithMountain(int mIndex)
        {
            Respawn();

            if (this.IsVulnerable)
            {
                this.IsVulnerable = false;

                if (Map.Mountains[mIndex].IsIceMountain)
                {
                    Map.Mountains[mIndex].IsAlive = false;
                }

                Deaths++;

                var packet = new DataPacket
                {
                    ClientId = (int)this.Color,
                    Command = ServerCommands.UpdatePoints,
                    Name = "death",
                    Color = this.Color,
                    Location = new Point(0, 0),
                    Direction = this.Direction,
                    Type = this.Type
                };

                if (Form.Clients != null)
                    Form.SendData(packet);
            }

        }

        public void CollisionWithRocket(int rIndex)
        {

            Rocket r = Map.Objects[rIndex] as Rocket;
            if (r.Owner.Color != this.Color)
            {
                IsVulnerable = false;
                Respawn();

                r.Owner.Kills++;
                Map.Objects[rIndex].IsAlive = false;

                var killPacket = new DataPacket
                {
                    ClientId = (int)r.Owner.Color,
                    Command = ServerCommands.UpdatePoints,
                    Name = "kill",
                    Color = r.Owner.Color,
                    Location = new Point(0, 0),
                    Direction = r.Owner.Direction,
                    Type = ObjectType.Rocket
                };

                if (Form.Clients != null)
                    Form.SendData(killPacket);

                Deaths++;

                var deathPacket = new DataPacket
                {
                    ClientId = (int)this.Color,
                    Command = ServerCommands.UpdatePoints,
                    Name = "death",
                    Color = this.Color,
                    Location = new Point(0, 0),
                    Direction = this.Direction,
                    Type = ObjectType.Rocket
                };

                if (Form.Clients != null)
                    Form.SendData(deathPacket);

            }
        }

        public void CollisionWithShip(int sIndex)
        {

            var s = Map.Objects[sIndex] as Ship;
            s.IsVulnerable = false;
            s.Respawn();
            this.IsVulnerable = false;
            this.Respawn();
            s.Deaths++;
            s.Kills++;

            var sPacket = new DataPacket
            {
                ClientId = (int)s.Color,
                Command = ServerCommands.UpdatePoints,
                Name = "both",
                Color = s.Color,
                Location = new Point(0, 0),
                Direction = s.Direction,
                Type = ObjectType.Ship
            };
            if (Form.Clients != null)
                Form.SendData(sPacket);


            this.Kills++;
            this.Deaths++;

            var tPacket = new DataPacket
            {
                ClientId = (int)this.Color,
                Command = ServerCommands.UpdatePoints,
                Name = "both",
                Color = this.Color,
                Location = new Point(0, 0),
                Direction = this.Direction,
                Type = ObjectType.Ship
            };
            if (Form.Clients != null)
                Form.SendData(tPacket);

        }

        public void RespawnDelegate()
        {
            this.SpeedX = 0;
            this.SpeedY = 0;
            int x = 50;
            int y = 50;

            switch (Color)
            {
                case ShipColor.Red:
                    x = Constants.RESPAWN_RED_X;
                    y = Constants.RESPAWN_RED_Y;
                    break;
                case ShipColor.Green:
                    x = Constants.RESPAWN_GREEN_X;
                    y = Constants.RESPAWN_GREEN_Y;
                    break;
                case ShipColor.Violet:
                    x = Constants.RESPAWN_VIOLET_X;
                    y = Constants.RESPAWN_VIOLET_Y;
                    break;
                case ShipColor.Yellow:
                    x = Constants.RESPAWN_YELLOW_X;
                    y = Constants.RESPAWN_YELLOW_Y;
                    break;
            }

            this.Location = new Point(x, y);
            Rect.Location = new Point(x, y);

            DataPacket packet = new DataPacket
            {
                Command = ServerCommands.Move,
                Name = this.Name,
                Color = this.Color,
                Direction = this.Direction,
                Location = new Point(x, y),
                ClientId = 0,
                Type = this.Type
            };

            if (Form.Clients != null)
                Form.SendData(packet);
        }


        public void Respawn()
        {
            if (this.InvokeRequired)
                this.Invoke((Action)delegate ()
                {
                    RespawnDelegate();
                });
            else
                RespawnDelegate();

        }

        public override void OnMove(object sender, EventArgs e)
        {
            if (this.IsVulnerable)
            {
                for (int j = Map.Objects.Count - 1; j >= 0; j--)
                {
                    if (Map.Objects[j] != null)
                    {
                        if (this.CheckCollision(Map.Objects[j]))
                        {
                            if (Map.Objects[j] is Rocket)
                            {
                                this.CollisionWithRocket(j);
                            }
                            else if (Map.Objects[j] is Ship)
                            {
                                this.CollisionWithShip(j);
                            }
                            //Form.killsValue.Text = Form.Ship.Kills.ToString();
                            //Form.deathsValue.Text = Form.Ship.Deaths.ToString();
                            //Form.pointsValue.Text = (Form.Ship.Points).ToString();


                            Map.Objects.RemoveAll(t => (t.Type != ObjectType.Ship) && !t.IsAlive);
                            break;
                        }
                    }
                }

            }

            // kolizja z górą
            if (this.IsAlive)
            {
                for (int j = Map.Mountains.Count - 1; j >= 0; j--)
                {
                    if (Map.Mountains[j] != null)
                    {
                        if (this.CheckCollision(Map.Mountains[j]))
                        {
                            this.CollisionWithMountain(j);
                            //Form.killsValue.Text = Form.Ship.Kills.ToString();
                            //Form.deathsValue.Text = Form.Ship.Deaths.ToString();
                            //Form.pointsValue.Text = (Form.Ship.Kills * 10 - Form.Ship.Deaths * 5).ToString();
                            Map.Objects.RemoveAll(t => (t.Type != ObjectType.Ship) && !t.IsAlive);

                            Map.Mountains.RemoveAll(t => t.Visible == false);
                            return;
                        }
                    }
                }
            }
        }

        public void Rotate(Direction direction)
        {
            if (this == null) return;

            if (this.Color == ShipColor.Red)
            {
                switch (direction)
                {
                    case Direction.Left:
                        this.Image = Properties.Resources.icon_red_left;
                        break;
                    case Direction.Right:
                        this.Image = Properties.Resources.icon_red_right;
                        break;
                    case Direction.Up:
                        this.Image = Properties.Resources.icon_red_up;
                        break;
                    case Direction.Down:
                        this.Image = Properties.Resources.icon_red_down;
                        break;
                }
            }
            else if (this.Color == ShipColor.Green)
            {
                switch (direction)
                {
                    case Direction.Left:
                        this.Image = Properties.Resources.icon_green_left;
                        break;
                    case Direction.Right:
                        this.Image = Properties.Resources.icon_green_right;
                        break;
                    case Direction.Up:
                        this.Image = Properties.Resources.icon_green_up;
                        break;
                    case Direction.Down:
                        this.Image = Properties.Resources.icon_green_down;
                        break;
                }
            }
            else if (this.Color == ShipColor.Violet)
            {
                switch (direction)
                {
                    case Direction.Left:
                        this.Image = Properties.Resources.icon_violet_left;
                        break;
                    case Direction.Right:
                        this.Image = Properties.Resources.icon_violet_right;
                        break;
                    case Direction.Up:
                        this.Image = Properties.Resources.icon_violet_up;
                        break;
                    case Direction.Down:
                        this.Image = Properties.Resources.icon_violet_down;
                        break;
                }
            }
            else if (this.Color == ShipColor.Yellow)
            {
                switch (direction)
                {
                    case Direction.Left:
                        this.Image = Properties.Resources.icon_yellow_left;
                        break;
                    case Direction.Right:
                        this.Image = Properties.Resources.icon_yellow_right;
                        break;
                    case Direction.Up:
                        this.Image = Properties.Resources.icon_yellow_up;
                        break;
                    case Direction.Down:
                        this.Image = Properties.Resources.icon_yellow_down;
                        break;
                }
            }
        }


    }
}
