using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulacija_gravitacije__Maturski_rad_
{
   public abstract class Particle
    {
        public PointD pos;
        public PointI size;
        public PointD speed;
        public PointD acc;
        public Color c;

        public abstract void draw(Graphics g, Color c);
    }
}
