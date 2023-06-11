using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacija_gravitacije__Maturski_rad_
{
    public class PointD
    {
        public double x;
        public double y;

        public PointD()
        {
            x = 0;
            y = 0;
        }

        public PointD(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public PointD(PointD d)
        {
            this.x = d.x;
            this.y = d.y;
        }

        public double mag()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public PointD add(PointD p)
        {
            return add(p.x,p.y);
        }

        public PointD sub(PointD p)
        {
            return sub(p.x,p.y);
        }

        public PointD add(double x, double y)
        {
            return new PointD(this.x + x, this.y + y);
        }

        public PointD sub(double x, double y)
        {
            return new PointD(this.x - x, this.y - y);
        }
    }
}
