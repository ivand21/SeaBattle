using BitwaMorska;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bitwa_morska
{
    [Serializable]
    public class MapObject : PictureBox
    {
        protected Panel Panel { get; set; }
        protected Map Map { get; set; }
        protected mainForm Form { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public ObjectType Type { get; set; }

        public bool IsAlive
        {
            get
            {
                return _IsAlive;
            }
            set
            {
                _IsAlive = value;
                if (!_IsAlive)
                {
                    if (this as Ship == null)
                        this.Image = null;
                    this.Visible = false;
                }
                    
            }
        }
        protected Rectangle Rect;


        private bool _IsAlive;

        public MapObject()
        {
            IsAlive = true;
        }




        public MapObject(Map map, int x, int y)
        {
            this.IsAlive = true;
            this.Map = map;
            this.Form = map.Form;
            this.Panel = map.Panel;
            this.BackColor = Color.Transparent;
            this.Location = new Point(x, y);
            this.Size = new Size(Constants.IMG_SIZE, Constants.IMG_SIZE);
            this.Rect = new Rectangle(new Point(x, y), new Size(Constants.IMG_SIZE, Constants.IMG_SIZE));
            this.Move += new EventHandler(OnMove);

            if (Panel.InvokeRequired)
            {
                Panel.Invoke((Action)delegate
                {
                    this.Panel.Controls.Add(this);
                });
            }
            else
                this.Panel.Controls.Add(this);
        }

        public MapObject(Map Map, int x, int y, ObjectType type)
        {
            this.IsAlive = true;
            this.Map = Map;
            this.Form = Map.Form;
            this.Panel = Map.Panel;
            this.BackColor = Color.Transparent;
            this.Location = new Point(x, y);
            this.Size = new Size(Constants.IMG_SIZE, Constants.IMG_SIZE);
            this.Rect = new Rectangle(new Point(x, y), new Size(Constants.IMG_SIZE, Constants.IMG_SIZE));
            this.Type = type;

            if (Panel.InvokeRequired)
            {
                Panel.Invoke((Action)delegate
                {
                    this.Panel.Controls.Add(this);
                });
            }
            else
                this.Panel.Controls.Add(this);
        }

        public bool CheckCollision(MapObject obj)
        {
            var _rect = obj.Rect;
            if (_rect.IntersectsWith(this.Rect) && this != obj && obj.IsAlive) return true;
            else return false;
        }

        public void DoMove()
        {
            if (this.IsAlive && (this as Mountain == null))
            {
                int new_x = this.Location.X;
                if (new_x + SpeedX >= 0 && new_x + SpeedX <= Panel.Width - this.Width)
                    new_x += SpeedX;

                int new_y = this.Location.Y;
                if (new_y + SpeedY >= 0 && new_y + SpeedY <= Panel.Height - this.Height)
                    new_y += SpeedY;

                Rect.Location = new Point(new_x, new_y);
                this.Location = new Point(new_x, new_y);
            }
        }

        public virtual void OnMove(object sender, EventArgs e) { }

        //public void Destroy()
        //{
        //    this.IsAlive = false;
        //    this.Visible = false;
        //    this.Enabled = false;
        //}



    }
}
