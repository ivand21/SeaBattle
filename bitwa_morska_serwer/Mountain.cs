using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitwaMorska;

namespace bitwa_morska_serwer
{
    public class Mountain : MapObject
    {
        public bool IsIceMountain { get; set; }

        public Mountain(Map map, int x, int y, bool isIce) : base(map, x, y)
        {
            this.Name = "mountain" + (map.MountainId + 1).ToString();
            map.MountainId++;
            this.IsIceMountain = isIce;
            this.IsAlive = true;
            if (IsIceMountain)
            {
                this.Type = ObjectType.IceMountain;
            }
            else this.Type = ObjectType.Mountain;

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
