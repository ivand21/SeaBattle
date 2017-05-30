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
    [Serializable]
    public class Rocket : MapObject
    {
        public Ship Owner { get; set; }

        public Rocket(Map Map, Ship owner, Direction direction) : base(Map, owner.Location.X, owner.Location.Y)
        {
            switch (direction)
            {
                case Direction.Up:
                    SpeedX = 0;
                    SpeedY = -Constants.ROCKET_SPEED;
                    break;
                case Direction.Down:
                    SpeedX = 0;
                    SpeedY = Constants.ROCKET_SPEED;
                    break;
                case Direction.Left:
                    SpeedX = -Constants.ROCKET_SPEED;
                    SpeedY = 0;
                    break;
                case Direction.Right:
                    SpeedX = Constants.ROCKET_SPEED;
                    SpeedY = 0;
                    break;
            }

            this.Map.Objects.Add(this);
            this.Owner = owner;
            this.Image = Properties.Resources.icon_bullet;
            this.Name = "rocket" + (Map.RocketId + 1).ToString();
            Map.RocketId++;
        }

        public Rocket(Map Map, int x, int y, string name) : base(Map, x, y)
        {
            this.Map.Objects.Add(this);
            this.Image = Properties.Resources.icon_bullet;
            this.Name = name;
            Map.RocketId++;
        }


        public void CollisionWithMountain(int mIndex)
        {
            this.IsAlive = false;

            if (Map.Mountains[mIndex].IsIceMountain)
            {
                Map.Mountains[mIndex].IsAlive = false;
            }
        }

        public void CollisionWithRocket(int rIndex)
        {
            this.IsAlive = false;
            Map.Objects[rIndex].IsAlive = false;
        }

        public void CollisionWithShip(int sIndex)
        {
            var ship = Map.Objects[sIndex] as Ship;

            if (this.Owner != ship)
            {

                this.Owner.Kills++;

                if (ship.IsSteerable)
                {
                    ship.Respawn();
                }

                ship.Deaths++;
                ship.IsAlive = false;

                this.IsAlive = false;

            }
        }

        public override void OnMove(object sender, EventArgs e)
        {
            if (!Form.IsConnected)
            {
                for (int j = Map.Objects.Count - 1; j >= 0; j--)
                {
                    if (Map.Objects[j].IsAlive)
                    {
                        if (this.CheckCollision(Map.Objects[j]))
                        {
                            var obj = Map.Objects[j];
                            if (obj is Rocket)
                            {
                                this.CollisionWithRocket(j);
                            }
                            else if (obj is Ship)
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
                                Map.Objects.RemoveAll(t => t.IsAlive == false);
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

