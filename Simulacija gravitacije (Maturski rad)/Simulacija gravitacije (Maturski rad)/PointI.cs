using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacija_gravitacije__Maturski_rad_
{
    public class PointI
    {
        public double x;
        public double y;

        public PointI()
        {
            x = 0;
            y = 0;
        }

        public PointI(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public PointI(PointI d)
        {
            this.x = d.x;
            this.y = d.y;
        }

        public double mag()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public PointI add(PointI p)
        {
            return add(p.x, p.y);
        }

        public PointI sub(PointI p)
        {
            return sub(p.x, p.y);
        }

        public PointI add(double x, double y)
        {
            return new PointI(this.x + x, this.y + y);
        }

        public PointI sub(double x, double y)
        {
            return new PointI(this.x - x, this.y - y);
        }
    }
}
