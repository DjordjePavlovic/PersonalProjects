using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacija_gravitacije__Maturski_rad_
{
    public partial class Form1 : Form
    {
        
        
        public static Graphics g;
        
        static Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        
        public static void spawnRandom()
        {
            for (int i = 0; i < 10; i++)
            {
                Engine.addParticle(new Bullet(new PointD(r.Next(1920), r.Next(1080)), new PointD(0, 0), Color.FromArgb(r.Next(255), r.Next(255), r.Next(255))));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            numericUpDown1.Enabled = false;
            timer2.Interval = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            spawnRandom();
            Graphics g;
            g = panel1.CreateGraphics();
            numericUpDown1.Maximum = Engine.particles.Count;
            hScrollBar1.Value = (int)Engine.particles[(int)numericUpDown1.Value - 1].size.x;
            panel2.BackColor = Engine.particles[(int)numericUpDown1.Value - 1].c;
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            Engine.update();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Particle p in Engine.particles)
            {
                p.draw(g, p.c);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            hScrollBar1.Value = (int)Engine.particles[(int)numericUpDown1.Value-1].size.x;
            panel2.BackColor = Engine.particles[(int)numericUpDown1.Value - 1].c;
            if (numericUpDown1.Value == numericUpDown1.Maximum+1)
            {
                numericUpDown1.Value = numericUpDown1.Minimum;
            }
            textBox1.Text = "X: " + Engine.particles[(int)numericUpDown1.Value - 1].speed.x.ToString();
            textBox2.Text = "Y: " + Engine.particles[(int)numericUpDown1.Value - 1].speed.y.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Engine.particles[(int)numericUpDown1.Value-1 ].c = colorDialog1.Color;
                Engine.particles[(int)numericUpDown1.Value - 1].draw(g, Engine.particles[(int)numericUpDown1.Value-1].c);
                panel2.BackColor = Engine.particles[(int)numericUpDown1.Value - 1].c;
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Engine.removeParticle(Engine.particles[(int)numericUpDown1.Value - 1]);
            numericUpDown1.Maximum = Engine.particles.Count;
            numericUpDown1_ValueChanged(sender, e);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            hScrollBar1.Enabled = !hScrollBar1.Enabled;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            spawnRandom();
            Graphics g;
            g = panel1.CreateGraphics();
            Engine.render(g);
            numericUpDown1.Maximum = Engine.particles.Count;
            hScrollBar1.Value = (int)Engine.particles[(int)numericUpDown1.Value - 1].size.x;
            panel2.BackColor = Engine.particles[(int)numericUpDown1.Value - 1].c;
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Engine.render(g);
            panel1.Refresh();
            if (Engine.particles.Count > 0)
            {
                Engine.particles[(int)numericUpDown1.Value - 1].size.x = hScrollBar1.Value;
                Engine.particles[(int)numericUpDown1.Value - 1].size.y = hScrollBar1.Value;
                textBox1.Text = "X: " + Engine.particles[(int)numericUpDown1.Value - 1].speed.x.ToString();
                textBox2.Text = "Y: " + Engine.particles[(int)numericUpDown1.Value - 1].speed.y.ToString();
            }
        }
    }
    }
    

