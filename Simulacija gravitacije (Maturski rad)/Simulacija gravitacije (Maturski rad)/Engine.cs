using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulacija_gravitacije__Maturski_rad_
{
    public class Engine
    {
        
        public static List<Particle> particles = new List<Particle>();

        public Graphics g;
		public static int l;

		public Engine() 
		{
		
		}
		public static void update()
		{
			foreach (Particle a in particles)
			{
				a.speed = a.speed.add(a.acc);

				a.speed.x *= 0.9999;
				a.speed.y *= 0.9999;

				if (a.pos.x < 0 || a.pos.x > 1920)
				{
					a.speed.x *= -1;
				}
				if (a.pos.y < 0 || a.pos.y > 1080)
				{
					a.speed.y *= -1;
				}

				a.pos = a.pos.add(a.speed);
			}

			foreach (Particle a in particles)
			{
				PointD acc = new PointD(0, 0);
				foreach (Particle b in particles)
				{
					if (a == b) { continue; }

					double angle = Math.Atan((b.pos.y - a.pos.y) / Math.Abs((b.pos.x - a.pos.x)));
					double accX = Math.Cos(angle) / 50000 * Math.Sign((b.pos.x - a.pos.x));
					double accY = Math.Sin(angle) / 50000;

					accY *= a.size.x * b.size.x;
					accX *= a.size.x * b.size.x;

					acc = acc.add(accX, accY);
				}
				a.acc = acc;
			}
		}

		static public void render(Graphics g)
        {
            foreach(Particle p in particles)
            {
                p.draw(g, p.c);
            }
        }
        
        static public void addParticle(Particle b)
        {
            particles.Add(b);
        }

        static public void removeParticle(Particle p)
        {
            particles.Remove(p);
        }
    }
}
