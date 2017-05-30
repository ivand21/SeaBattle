using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using BitwaMorska;

namespace bitwa_morska
{
    public class Ship : MapObject
    {
        public ShipColor Color { get; set; }
        public bool IsReadyToShoot { get; set; }
        public bool IsSteerable { get; set; }
        public Direction Direction { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public System.Timers.Timer ShotTimer { get; set; }
        public int Points { get { return Kills * 10 - Deaths * 5; } }

        public Ship() { }


        public Ship(Map map, int x, int y, bool steerable) : base(map, x, y)
        {
            this.Invoke((Action)delegate ()
            {

                this.Name = "ship_red";
                this.Image = Properties.Resources.icon_red_right;
                this.IsReadyToShoot = true;
                this.IsSteerable = steerable;
                this.Direction = Direction.Right;
                this.Map.Objects.Add(this);
                this.Kills = 0;
                this.Deaths = 0;
                this.ShotTimer = new System.Timers.Timer();
                ShotTimer.Elapsed += ShotTimerTick;
                ShotTimer.Interval = Constants.SHOT_INTERVAL;
            });
        }

        public Ship(Map Map, bool steerable, ShipColor color) : base(Map, 0, 0)
        {
            this.Invoke((Action)delegate ()
           {
               this.Color = color;
               switch (color)
               {
                   case ShipColor.Red:
                       this.Name = "ship_red";
                       this.Image = Properties.Resources.icon_red_right;
                       this.Direction = Direction.Right;
                       this.Location = new Point(Constants.RESPAWN_RED_X, Constants.RESPAWN_RED_Y);
                       break;
                   case ShipColor.Green:
                       this.Name = "ship_green";
                       this.Image = Properties.Resources.icon_green_left;
                       this.Direction = Direction.Left;
                       this.Location = new Point(Constants.RESPAWN_GREEN_X, Constants.RESPAWN_GREEN_Y);
                       break;
                   case ShipColor.Violet:
                       this.Name = "ship_violet";
                       this.Image = Properties.Resources.icon_violet_left;
                       this.Direction = Direction.Left;
                       this.Location = new Point(Constants.RESPAWN_VIOLET_X, Constants.RESPAWN_VIOLET_Y);
                       break;
                   case ShipColor.Yellow:
                       this.Name = "ship_yellow";
                       this.Image = Properties.Resources.icon_yellow_right;
                       this.Direction = Direction.Right;
                       this.Location = new Point(Constants.RESPAWN_YELLOW_X, Constants.RESPAWN_YELLOW_Y);
                       break;
               }
               this.Map.Objects.Add(this);
               this.Kills = 0;
               this.Deaths = 0;
               this.Type = ObjectType.Ship;
               this.ShotTimer = new System.Timers.Timer();
               ShotTimer.Elapsed += ShotTimerTick;
               ShotTimer.Interval = Constants.SHOT_INTERVAL;
           });
        }

        public Ship(Map Map, int x, int y, bool steerable, ShipColor color, string name) : base(Map, x, y)
        {
            this.Invoke((Action)delegate ()
            {

                this.Color = color;
                switch (color)
                {
                    case ShipColor.Red:
                        this.Image = Properties.Resources.icon_red_right;
                        this.Direction = Direction.Right;
                        break;
                    case ShipColor.Green:
                        this.Image = Properties.Resources.icon_green_left;
                        this.Direction = Direction.Left;
                        break;
                    case ShipColor.Violet:
                        this.Image = Properties.Resources.icon_violet_left;
                        this.Direction = Direction.Left;
                        break;
                    case ShipColor.Yellow:
                        this.Image = Properties.Resources.icon_yellow_right;
                        this.Direction = Direction.Right;
                        break;
                }
                this.Location = new Point(x, y);
                this.Name = name;
                this.IsReadyToShoot = true;
                this.IsSteerable = steerable;
                this.Map.Objects.Add(this);
                this.Kills = 0;
                this.Deaths = 0;
                this.Type = ObjectType.Ship;
                this.ShotTimer = new System.Timers.Timer();
                ShotTimer.Elapsed += ShotTimerTick;
                ShotTimer.Interval = Constants.SHOT_INTERVAL;
            });
        }

        private void ShotTimerTick(object sender, EventArgs e)
        {
            IsReadyToShoot = true;
        }

        public void GetDirection(KeyEventArgs e)
        {
            if (IsAlive && IsSteerable)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (SpeedX >= 0) SpeedX = -Constants.SHIP_SPEED;
                    SpeedY = 0;
                    this.Direction = Direction.Left;
                    this.Image = Properties.Resources.icon_red_left;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (SpeedX <= 0) SpeedX = Constants.SHIP_SPEED;
                    SpeedY = 0;
                    this.Direction = Direction.Right;
                    this.Image = Properties.Resources.icon_red_right;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (SpeedY >= 0) SpeedY = -Constants.SHIP_SPEED;
                    SpeedX = 0;
                    this.Direction = Direction.Up;
                    this.Image = Properties.Resources.icon_red_up;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (SpeedY <= 0) SpeedY = Constants.SHIP_SPEED;
                    SpeedX = 0;
                    this.Direction = Direction.Down;
                    this.Image = Properties.Resources.icon_red_down;
                }

                if (e.KeyCode == Keys.Space)
                {
                    if (IsReadyToShoot)
                    {
                        Shoot();
                    }
                }
            }
        }

        public void Stop(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SpeedX = 0;
                SpeedY = 0;
            }
        }


        public void Shoot()
        {
            Rocket r = new Rocket(this.Map, this, Direction);
            IsReadyToShoot = false;
            ShotTimer.Enabled = true;
        }

        public void CollisionWithMountain(int mIndex)
        {
            if (Map.Mountains[mIndex].IsIceMountain)
            {
                Map.Mountains[mIndex].IsAlive = false;
            }

            Deaths++;

            if (this.IsSteerable)
            {
                Respawn();
            }
        }

        public void CollisionWithRocket(int rIndex)
        {
            Rocket r = Map.Objects[rIndex] as Rocket;
            if (r.Owner != this)
            {
                r.Owner.Kills++;
                Map.Objects[rIndex].IsAlive = false;

                Deaths++;
                this.IsAlive = false;

                if (this.IsSteerable)
                {
                    Respawn();
                }

            }
        }

        public void CollisionWithShip(int sIndex)
        {
            var s = Map.Objects[sIndex] as Ship;
            s.Deaths++;
            s.Kills++;
            s.IsAlive = false;

            if (s.IsSteerable)
            {
                s.Respawn();
            }

            this.Kills++;
            this.Deaths++;
            this.IsAlive = false;

            if (this.IsSteerable)
            {
                Respawn();
            }
        }

        public void Respawn()
        {

            this.SpeedX = 0;
            this.SpeedY = 0;

            switch (Color)
            {
                case ShipColor.Red:
                    this.Location = new Point(Constants.RESPAWN_RED_X, Constants.RESPAWN_RED_Y);
                    break;
                case ShipColor.Green:
                    this.Location = new Point(Constants.RESPAWN_GREEN_X, Constants.RESPAWN_GREEN_Y);
                    break;
                case ShipColor.Violet:
                    this.Location = new Point(Constants.RESPAWN_VIOLET_X, Constants.RESPAWN_VIOLET_Y);
                    break;
                case ShipColor.Yellow:
                    this.Location = new Point(Constants.RESPAWN_YELLOW_X, Constants.RESPAWN_YELLOW_Y);
                    break;
            }
        }

        public override void OnMove(object sender, EventArgs e)
        {
            if (!Form.IsConnected)
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
                            Form.txtKillsValue.Text = Form.Ship.Kills.ToString();
                            Form.txtDeathsValue.Text = Form.Ship.Deaths.ToString();
                            Form.txtPointsValue.Text = (Form.Ship.Points).ToString();

                            Map.Objects.RemoveAll(t => t.Visible == false);
                            break;
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
                                Map.Objects.RemoveAll(t => t == null);
                                Form.txtKillsValue.Text = Form.Ship.Kills.ToString();
                                Form.txtDeathsValue.Text = Form.Ship.Deaths.ToString();
                                Form.txtPointsValue.Text = (Form.Ship.Kills * 10 - Form.Ship.Deaths * 5).ToString();

                                Map.Objects.RemoveAll(t => t.Visible == false);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
