using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            int x0 = 50, y0 = 20;
            int size = 40;
            float xx_old =  0F,yy_old = 0F;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(Brushes.LightGray, x0, y0, size * 10, size * 10);
            var pen1 = new Pen(Color.Black, 2);
            g.DrawLine(pen1, x0, y0 + 5 * size, x0 + 10 * size, y0 + 5 * size);
            g.DrawLine(pen1, x0 + 5 * size, y0, x0 + 5 * size, y0 + 10 * size);
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(Pens.Black, x0, y0 + i * size, x0 + 10 * size, y0 + i * size);
                g.DrawLine(Pens.Black, x0 + i * size, y0, x0 + i * size, y0 + 10 * size);
            }

            for (int i = -5; i <= 5; i++)
            {
                var text = $"{i,3:D}";
                g.DrawString(text, Font, Brushes.Black, x0 - 17 + ((i + 5) * size), y0 + 13 + 10 * size);
                g.DrawString(text, Font, Brushes.Black, x0 - 30, y0 - 5 + (5 - i) * size);
            }

            for (float x = -5; x <= 5; x += 0.02F)
            {
                var y = x * x + 2 * x - 2;
                var xx = x0 + (x + 5) * size;
                var yy = y0 + (5 - y) * size;
                if (y < 5 && y > -5)
                {
                    g.FillRectangle(Brushes.Red, xx, yy, 1, 1);
                }
            }

            for (float x = -5; x <= 5; x+= 0.02F)
            {
                var y = x * x - 2 * x - 2;
                var xx = x0 + (x + 5) * size;
                var yy = y0 + (5 - y) * size;
                if (x != -5F && y < 5F && y > -5F)
                {
                    g.DrawLine(Pens.Green, xx_old, yy_old, xx, yy);
                }

                xx_old = xx;
                yy_old = yy;
            }
        }
    }
}
