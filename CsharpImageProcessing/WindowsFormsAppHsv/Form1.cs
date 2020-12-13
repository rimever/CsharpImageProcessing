using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppHsv.Properties;

namespace WindowsFormsAppHsv
{
    public partial class Form1 : Form
    {
        private bool firstFlag = true;
        private const int HEIGHT = 240, WIDTH = 320;
        float[,] hue = new float[WIDTH, HEIGHT];
        float[,] saturation = new float[WIDTH, HEIGHT];
        float[,] value = new float[WIDTH, HEIGHT];
        Bitmap bitmap = new Bitmap(WIDTH, HEIGHT);
        public Form1()
        {
            InitializeComponent();
            Paint += Form1OnPaint;
            buttonReset.Click += ButtonResetClick;
            hScrollBar1.ValueChanged += HScrollBarValueChanged;
            hScrollBar2.ValueChanged += HScrollBarValueChanged;
            hScrollBar3.ValueChanged += HScrollBarValueChanged;
        }

        private void HScrollBarValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void ButtonResetClick(object sender, EventArgs e)
        {
            hScrollBar1.Value = 0;
            hScrollBar2.Value = 100;
            hScrollBar3.Value = 100;
            Invalidate();
        }

        private void Form1OnPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            int x0 = 10, y0 = 10;
            int x1 = 10, y1 = HEIGHT + 20;
            var bitmap1 = new Bitmap(WIDTH, HEIGHT);
            if (firstFlag)
            {
                bitmap = Resources.tower;
                for (int j = 0; j < HEIGHT; j++)
                {
                    for (int i = 0; i < WIDTH; i++)
                    {
                        var color = bitmap.GetPixel(i, j);
                        int r = color.R;
                        int g = color.G;
                        int b = color.B;
                        var hsv = ConvertToHsv(r, g, b);
                        hue[i, j] = hsv[0];
                        saturation[i, j] = hsv[1];
                        value[i, j] = hsv[2];
                    }

                    firstFlag = false;
                }
            }

            float hueRotate = hScrollBar1.Value;
            float saturationPercent = hScrollBar2.Value / 100F;
            float valuePercent = hScrollBar3.Value / 100F;
            labelHue.Text = $@"{hScrollBar1.Value}°";
            labelSaturation.Text = $@"{hScrollBar2.Value - 100}%";
            labelValue.Text = $@"{hScrollBar3.Value - 100}%";

            graphics.DrawImage(bitmap, x0, y0, WIDTH, HEIGHT);
            for (int j = 0; j < HEIGHT; j++)
            {
                for (int i = 0; i < WIDTH; i++)
                {
                    var h = hue[i, j] + hueRotate;
                    var s = saturation[i, j] * saturationPercent;
                    var v = value[i, j] * valuePercent;
                    var color = CreateColorFromHsv(h, s, v);
                    bitmap1.SetPixel(i, j, color);
                }

            }

            graphics.DrawImage(bitmap1, x1, y1, WIDTH, HEIGHT);
        }

        private Color CreateColorFromHsv(float h, float s, float v)
        {
            int r = 0, g = 0, b = 0;
            if (h >= 360) h -= 360;
            else if (h < 0) h += 360;
            var high = (int)(255 * v);
            if (high > 255) high = 255;
            else if (high < 0) high = 0;
            if (s == 0)
            {
                r = high;
                g = high;
                b = high;
            }
            else
            {
                var h6 = (int)(h / 60);
                var f = h / 60 - h6;
                var low = (int)(high * (1 - s));
                var down = (int)(high * (1 - f * s));
                var up = (int)(high * (1 - (1 - f) * s));
                if (low > 255) low = 255;
                else if (low < 0) low = 0;
                if (down > 255) down = 255;
                else if (down < 0) down = 0;
                if (up > 255) up = 255;
                else if (up < 0) up = 0;
                switch (h6)
                {
                    case 0:
                        r = high;
                        g = up;
                        b = low;
                        break;
                    case 1:
                        r = down;
                        g = high;
                        b = low;
                        break;
                    case 2:
                        r = low;
                        g = high;
                        b = up;
                        break;
                    case 3:
                        r = low;
                        g = down;
                        b = high;
                        break;
                    case 4:
                        r = up;
                        g = low;
                        b = high;
                        break;
                    case 5:
                        r = high;
                        g = low;
                        b = down;
                        break;
                }
            }

            return Color.FromArgb(r, g, b);
        }

        private float[] ConvertToHsv(int r, int g, int b)
        {
            var hsv = new float[3];
            float h = 0, s;
            int max = Math.Max(r, Math.Max(g, b));
            int min = Math.Min(r, Math.Min(g, b));
            int diff = max - min;
            if (diff != 0)
            {
                if (max == r) h = 60 * (g - b) / (float)diff;
                if (max == g) h = 60 * (b - r) / (float)diff + 120;
                if (max == b) h = 60 * (r - g) / (float)diff + 240;
            }
            else h = 0;

            if (max != 0) s = diff / (float)max;
            else s = 0;
            var v = max / 255F;
            hsv[0] = h;
            hsv[1] = s;
            hsv[2] = v;
            return hsv;
        }
    }
}
