using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using BitwaMorska;

namespace bitwa_morska_serwer
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
            this.Type = ObjectType.Rocket;
            Map.RocketId++;

            DataPacket data = new DataPacket
            {
                Command = ServerCommands.Spawn,
                ClientId = (int)owner.Color,
                Type = ObjectType.Rocket,
                Location = this.Location,
                Color = owner.Color,
                Direction = Direction.None,
                Name = this.Name
            };
            Form.SendData(data);
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

            if (this.Owner.Color != ship.Color)
            {
                ship.IsVulnerable = false;
                ship.Respawn();

                this.Owner.Kills++;

                var killPacket = new DataPacket
                {
                    ClientId = (int)this.Owner.Color,
                    Command = ServerCommands.UpdatePoints,
                    Name = "kill",
                    Color = this.Owner.Color,
                    Location = new Point(0, 0),
                    Direction = this.Owner.Direction,
                    Type = ObjectType.Rocket
                };

                if (Form.Clients != null)
                    Form.SendData(killPacket);

                ship.Deaths++;

                var deathPacket = new DataPacket
                {
                    ClientId = (int)ship.Color,
                    Command = ServerCommands.UpdatePoints,
                    Name = "death",
                    Color = ship.Color,
                    Location = new Point(0, 0),
                    Direction = ship.Direction,
                    Type = ObjectType.Rocket
                };

                if (Form.Clients != null)
                    Form.SendData(deathPacket);


                this.IsAlive = false;

            }
        }

        public override void OnMove(object sender, EventArgs e)
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
                            if ((obj as Ship).IsVulnerable)
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
                            Map.Objects.RemoveAll(t => (t.Type != ObjectType.Ship) && !t.IsAlive);
                            //Form.killsValue.Text = Form.Ship.Kills.ToString();
                            //Form.deathsValue.Text = Form.Ship.Deaths.ToString();
                            //Form.pointsValue.Text = (Form.Ship.Kills * 10 - Form.Ship.Deaths * 5).ToString();

                            Map.Mountains.RemoveAll(t => !t.IsAlive);
                            return;
                        }
                    }
                }
            }
        }



    }
}
