using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppHistogram.Properties;

namespace WindowsFormsAppHistogram
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
            const int height = 240, width = 320;
            int x0 = 10, y0 = 10;
            int x1 = 350, y1 = 260;
            byte d, level05, level95;
            int integral;
            var bitmap1 = new Bitmap(width, height);
            int[,] histogram = new int[4, 256];
            var bitmap = Resources.sample;
            g.DrawImage(bitmap, x0, y0, width, height);
            histogram = CreateHistogram(bitmap);
            integral = 0;
            d = 0;
            do
            {
                integral += histogram[3, d];
                d++;
            } while (integral < 3840);
            level05 = (byte)(d - 1);
            integral = 0;
            d = 255;
            do
            {
                integral += histogram[3, d];
                d--;
            } while (integral < 3840);

            level95 = (byte)(d + 1);
            //            DrawHistogram(x1, y0, histogram, level05, level95);
            //            bitmap1 = StretchHistogram(bitmap, level05, level95);
            DrawHistogram(x1, y0, histogram);
            bitmap1 = EqualizeHistogram(bitmap, histogram);

            g.DrawImage(bitmap1, x0, y1, width, height);
            histogram = CreateHistogram(bitmap1);
            DrawHistogram(x1, y1, histogram);
        }

        private Bitmap EqualizeHistogram(Bitmap bitmap, int[,] histogram)
        {
            Bitmap bitmap1 = new Bitmap(bitmap.Width, bitmap.Height);
            byte[] table = new byte[256];
            int sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += histogram[3, i];
            }

            var average = (int)Math.Ceiling(sum / 256d);
            var integral = 0;
            int v = 0;
            for (int i = 0; i < 256; i++)
            {
                integral += histogram[3, i];
                v += integral / average;
                integral %= average;
                table[i] = (byte)v;
            }

            for (int j = 0; j < bitmap.Height; j++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    var color1 = bitmap.GetPixel(i, j);
                    var r = color1.R;
                    var g = color1.G;
                    var b = color1.B;
                    var r1 = table[r];
                    var g1 = table[g];
                    var b1 = table[b];
                    color1 = Color.FromArgb(r1, g1, b1);
                    bitmap1.SetPixel(i, j, color1);
                }
            }
            return bitmap1;
        }

        private void DrawHistogram(int x, int y, int[,] histogram)
        {
            var g = CreateGraphics();
            int maximum = 0;

            for (int i = 1; i <= 254; i++)
            {
                if (histogram[3, i] > maximum)
                {
                    maximum = histogram[3, i];
                }
            }

            var scale = 50d / maximum;
            for (int i = 0; i < 4; i++)
            {
                g.DrawRectangle(Pens.Black, x, y + 60 * i, 256, 60);
            }

            for (int i = 1; i <= 254; i++)
            {
                g.DrawLine(Pens.Red, x + i, y + 59, x + i, y + 60 - (int)(histogram[0, i] * scale));
                g.DrawLine(Pens.Green, x + i, y + 119, x + i, y + 120 - (int)(histogram[1, i] * scale));
                g.DrawLine(Pens.Blue, x + i, y + 179, x + i, y + 180 - (int)(histogram[2, i] * scale));
                g.DrawLine(Pens.Gray, x + i, y + 239, x + i, y + 240 - (int)(histogram[3, i] * scale));
            }
        }

        private int[,] CreateHistogram(Bitmap bitmap)
        {
            int[,] histogram = new int[4, 256];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    histogram[i, j] = 0;
                }
            }

            for (int j = 0; j < bitmap.Height; j++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    var color1 = bitmap.GetPixel(i, j);
                    var r = color1.R;
                    var g = color1.G;
                    var b = color1.B;
                    histogram[0, r]++;
                    histogram[1, g]++;
                    histogram[2, b]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                histogram[3, i] = Math.Max(Math.Max(histogram[0, i], histogram[1, i]), histogram[2, i]);
            }

            return histogram;
        }

        private Bitmap StretchHistogram(Bitmap bitmap, byte low, byte high)
        {
            var bitmap1 = new Bitmap(bitmap.Width, bitmap.Height);
            float p = 255F / (high - low);
            for (int j = 0; j < bitmap.Height; j++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    var color1 = bitmap.GetPixel(i, j);
                    var r = color1.R;
                    var g = color1.G;
                    var b = color1.B;
                    byte r1;
                    if (r < low) r1 = 0;
                    else if (r > high) r1 = 255;
                    else r1 = (byte)(p * (r - low));
                    byte g1;
                    if (g < low) g1 = 0;
                    else if (g > high) g1 = 255;
                    else g1 = (byte)(p * (g - low));
                    byte b1;
                    if (b < low) b1 = 0;
                    else if (b > high) b1 = 255;
                    else b1 = (byte)(p * (b - low));
                    color1 = Color.FromArgb(r1, g1, b1);
                    bitmap1.SetPixel(i, j, color1);
                }
            }

            return bitmap1;
        }
    }
}
