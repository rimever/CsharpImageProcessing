using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3_2.Properties;

namespace WindowsFormsApp3_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += Form1Paint;
        }

        private void Form1Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            const int Width = 320, Height = 240;
            int x0 = 10, y0 = 10;
            int x1 = Width + 20, y1 = y0;
            int x2 = x0, y2 = Height + 20;
            int x3 = x1, y3 = y2;
            Color color0, color1, color2, color3;
            byte r0, g0, b0, r1, g1, b1, r2, g2, b2, r3, g3, b3;
            var bitmap1 = new Bitmap(Width,Height);
            var bitmap2 = new Bitmap(Width,Height);
            var bitmap3 = new Bitmap(Width,Height);

            // 低濃度の拡張
            byte[] lowExpand = new byte[256];
            // 高濃度の拡張
            byte[] highExpand = new byte[256];
            // 中濃度の拡張
            byte[] midExpand = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                lowExpand[i] = (byte) (255 * Math.Sqrt(i / 255d));
                highExpand[i] = (byte) (255 * Math.Pow(i / 255d, 2));
                midExpand[i] = (byte) (255 / 2d * (1 - Math.Cos(Math.PI / 255d * i)));
            }

            var bitmap0 = Resources.sample;
            g.DrawImage(bitmap0, x0, y0, Width, Height);
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    color0 = bitmap0.GetPixel(i, j);
                    r0 = color0.R;
                    g0 = color0.G;
                    b0 = color0.B;

                    r1 = lowExpand[r0];
                    g1 = lowExpand[g0];
                    b1 = lowExpand[b0];
                    color1 = Color.FromArgb(r1, g1, b1);
                    bitmap1.SetPixel(i, j, color1);

                    r2 = highExpand[r0];
                    g2 = highExpand[g0];
                    b2 = highExpand[b0];
                    color2 = Color.FromArgb(r2, g2, b2);
                    bitmap2.SetPixel(i, j, color2);

                    r3 = midExpand[r0];
                    g3 = midExpand[g0];
                    b3 = midExpand[b0];
                    color3 = Color.FromArgb(r3, g3, b3);
                    bitmap3.SetPixel(i, j, color3);

                }
                g.DrawImage(bitmap1,x1,y1);
                g.DrawImage(bitmap2,x2,y2);
                g.DrawImage(bitmap3,x3,y3);
            }
        }
    }
}
