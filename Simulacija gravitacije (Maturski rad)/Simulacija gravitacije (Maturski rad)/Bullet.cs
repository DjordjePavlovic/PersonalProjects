using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulacija_gravitacije__Maturski_rad_
{
    public class Bullet : Particle
    {
        static Random r = new Random();
        
        public Bullet(PointD pos, PointD speed, Color c)
        {
            this.pos = pos;
            this.speed = speed;
            double d = 6 + ((100*r.NextDouble() )/ 10D);
            int a = Convert.ToInt32(r.Next(50));
            this.size = new PointI(a, a);
            this.acc = new PointD(0, 0);
            this.c = c;
            
        }

        public override void draw(Graphics g, Color c)
        {
            Brush b = new SolidBrush(c);
            g.FillEllipse(b,
                (int)(pos.x - size.x / 2),
                (int)(pos.y - (size.y / 2)), 
                (int)size.x, (int)size.y);
        }
    }
}
