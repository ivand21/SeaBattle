using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using BitwaMorska;

namespace bitwa_morska
{
    public class Map
    {
        public mainForm Form { get; set; }
        public Panel Panel { get; set; }
        string[] Sea { get; set; }
        public Timer Timer { get; set; }
        public long RocketId = 0;
        public long MountainId = 0;

        public List<MapObject> Objects { get; set; }
        public List<Mountain> Mountains { get; set; }

        public Map() { }

        public Map(Panel panel, mainForm Form)
        {
            this.Panel = panel;
            this.Form = Form;

            Objects = new List<MapObject>();
            Mountains = new List<Mountain>();

            this.Timer = new Timer();
            this.Timer.Interval = Constants.TIMER_INTERVAL;
            this.Timer.Tick += new EventHandler(timer_Tick);

            if (!Form.IsConnected)
            {
                this.Timer.Enabled = true;
                MapFromFile();
            }
        }

        public void MapFromFile()
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"map.txt");
            Sea = File.ReadAllLines(path);

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    char c = Sea[i].ElementAt(j);

                    if (c == 'N')
                        continue;
                    else
                    {
                        Mountain pb = null;
                        if (c == 'M')
                        {
                            pb = new Mountain(this, Constants.IMG_SIZE * j, Constants.IMG_SIZE * i, false);
                        }
                        else if (c == 'I')
                        {
                            pb = new Mountain(this, Constants.IMG_SIZE * j, Constants.IMG_SIZE * i, true);
                        }
                        if (pb != null)
                        {
                            this.Panel.Controls.Add(pb);
                            Mountains.Add(pb);
                        }
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].DoMove();
            }
        }

        public MapObject GetObjectByName(string name)
        {
            if (name.StartsWith("m"))
            {
                foreach (var m in Mountains)
                {
                    if (m.Name == name) return m;
                }
                return null;
            }
            else
            {
                foreach (var o in Objects)
                {
                    if (o.Name == name) return o;
                }
                return null;
            }
        }

        //public Ship AddShip(Map map, int x, int y, ShipColor color, string name)
        //{
        //    Panel.Invoke((Func<Ship>)delegate ()
        //   {
        //       Ship ship = new Ship(map, x, y, true, color, name);

        //       Form.Ship = ship;

        //       return ship;
        //   });
        //    return null;
        //}

        public void AddObject(Map map, int x, int y, ObjectType type, string name, ShipColor color)
        {

            Panel.Invoke((Action)delegate ()
                   {
                       MapObject obj;

                       if (type == ObjectType.Mountain)
                       {
                           obj = new Mountain(map, x, y, false, name);
                           obj.Type = type;

                       }
                       else if (type == ObjectType.IceMountain)
                       {
                           obj = new Mountain(map, x, y, true, name);
                           obj.Type = type;

                       }
                       else if (type == ObjectType.Rocket)
                       {
                           obj = new Rocket(map, x, y, name);
                           obj.Type = type;

                       }
                       else
                       {
                           obj = new Ship(map, x, y, true, color, name);
                           obj.Type = type;
                       }
                   });
        }

        public void Destroy(MapObject obj)
        {
            if (obj == null) return;
            if (obj.InvokeRequired)
            {
                obj.Invoke((Action)delegate ()
                {
                    obj.IsAlive = false;
                    if (obj is Ship)
                    {
                        obj.Image = null;
                    }
                });
            }
            else
                obj.IsAlive = false;
        }

        public void Rotate(MapObject obj, Direction direction)
        {
            var ship = obj as Ship;
            if (ship == null) return;

            if (ship.Color == ShipColor.Red)
            {
                switch (direction)
                {
                    case Direction.Left:
                        ship.Image = Properties.Resources.icon_red_left;
                        break;
                    case Direction.Right:
                        ship.Image = Properties.Resources.icon_red_right;
                        break;
                    case Direction.Up:
                        ship.Image = Properties.Resources.icon_red_up;
                        break;
                    case Direction.Down:
                        ship.Image = Properties.Resources.icon_red_down;
                        break;
                }
            }
            else if (ship.Color == ShipColor.Green)
            {
                switch (direction)
                {
                    case Direction.Left:
                        ship.Image = Properties.Resources.icon_green_left;
                        break;
                    case Direction.Right:
                        ship.Image = Properties.Resources.icon_green_right;
                        break;
                    case Direction.Up:
                        ship.Image = Properties.Resources.icon_green_up;
                        break;
                    case Direction.Down:
                        ship.Image = Properties.Resources.icon_green_down;
                        break;
                }
            }
            else if (ship.Color == ShipColor.Violet)
            {
                switch (direction)
                {
                    case Direction.Left:
                        ship.Image = Properties.Resources.icon_violet_left;
                        break;
                    case Direction.Right:
                        ship.Image = Properties.Resources.icon_violet_right;
                        break;
                    case Direction.Up:
                        ship.Image = Properties.Resources.icon_violet_up;
                        break;
                    case Direction.Down:
                        ship.Image = Properties.Resources.icon_violet_down;
                        break;
                }
            }
            else if (ship.Color == ShipColor.Yellow)
            {
                switch (direction)
                {
                    case Direction.Left:
                        ship.Image = Properties.Resources.icon_yellow_left;
                        break;
                    case Direction.Right:
                        ship.Image = Properties.Resources.icon_yellow_right;
                        break;
                    case Direction.Up:
                        ship.Image = Properties.Resources.icon_yellow_up;
                        break;
                    case Direction.Down:
                        ship.Image = Properties.Resources.icon_yellow_down;
                        break;
                }
            }
        }

    }
}

