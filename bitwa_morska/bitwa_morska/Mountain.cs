using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bitwa_morska
{
    public class Mountain : MapObject
    {
        public bool IsIceMountain { get; set; }

        public Mountain(Map map, int x, int y, bool isIce) : base(map,x,y)
        {
            this.Name = "mountain" + (map.MountainId + 1).ToString();
            map.MountainId++;
            this.IsIceMountain = isIce;
            this.Enabled = true;
            if (isIce)
            {
                this.Image = Properties.Resources.icon_ice;
            }
            else
            {
                this.Image = Properties.Resources.icon_mountain;
            }
        }

        public Mountain(Map map, int x, int y, bool isIce, string name) : base(map, x, y)
        {
            this.Name = name;
            map.MountainId++;
            this.Map.Mountains.Add(this);
            this.IsIceMountain = isIce;
            this.Enabled = true;
            if (isIce)
            {
                this.Image = Properties.Resources.icon_ice;
            }
            else
            {
                this.Image = Properties.Resources.icon_mountain;
            }
        }

    }
}
