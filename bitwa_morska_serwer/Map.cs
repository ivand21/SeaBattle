using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using BitwaMorska;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace bitwa_morska_serwer
{
    [Serializable]
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

        public Map(Panel panel, mainForm Form)
        {
            this.Panel = panel;
            this.Form = Form;

            Objects = new List<MapObject>();
            Mountains = new List<Mountain>();

            this.Timer = new Timer();
            this.Timer.Interval = Constants.TIMER_INTERVAL;
            this.Timer.Tick += new EventHandler(timer_Tick);
            this.Timer.Enabled = true;

            MapFromFile();
        }


        public void MapFromFile()
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"map.txt");
            Sea = File.ReadAllLines(path);

            this.Objects = new List<MapObject>
            {
                new Ship(this,ShipColor.Red),
                new Ship(this,ShipColor.Green),
                new Ship(this,ShipColor.Violet),
                new Ship(this,ShipColor.Yellow)
            };

            foreach (var s in Objects)
            {
                s.IsAlive = false;
                s.Visible = false;
            }



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
                            pb.Type = ObjectType.Mountain;
                        }
                        else if (c == 'I')
                        {
                            pb = new Mountain(this, Constants.IMG_SIZE * j, Constants.IMG_SIZE * i, true);
                            pb.Type = ObjectType.IceMountain;
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


        public Ship GetShipByName(string name)
        {
            var client = Objects.FirstOrDefault(s => s.Name == name);
            return client as Ship;
        }
        
        public void ShipStop(Ship obj)
        {
            if (obj.InvokeRequired)
            {
                obj.Invoke((Action)delegate ()
                {
                    obj.Stop();
                });
            }
            else
                obj.Stop();
        }

        public void DeleteShip(Ship ship)
        {
            ship.Invoke((Action)delegate ()
            {
                ship.Kills = 0;
                ship.Deaths = 0;
                ship.IsAlive = false;
                ship.Visible = false;
                ship.Enabled = false;
            });
        }

    }
}

