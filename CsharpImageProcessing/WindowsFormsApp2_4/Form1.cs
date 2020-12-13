using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2_4
{
    public partial class Form1 : Form
    {
        private bool showFlag = false;

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            numericUpDownFrequencyX.ValueChanged += NumericUpDownFrequencyX_ValueChanged;
            numericUpDownFrequencyY.ValueChanged += NumericUpDownFrequencyY_ValueChanged;
            hScrollBar1.Scroll += HScrollBar1_Scroll;
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            showFlag = true;
            Invalidate();
        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        private void NumericUpDownFrequencyY_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void NumericUpDownFrequencyX_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            int x0 = 10, y0 = 60;
            int x1 = 190, y1 = 60;
            int x2 = 20, y2 = 240;
            const int SIZE = 16;

            float xx0_old = 0, yy0_old = 0;
            float xx1_old = 0, yy1_old = 0;
            float xx2_old = 0, yy2_old = 0;

            var frequencyX = (int)numericUpDownFrequencyX.Value;
            var frequencyY = (int)numericUpDownFrequencyY.Value;
            var omegaX = (float)(2 * Math.PI * frequencyX);
            var omegaY = (float)(2 * Math.PI * frequencyY);
            var phi1 = hScrollBar1.Value / 100F;
            var phi = (float)(phi1 * Math.PI);

            if (phi1 == 0F) label6.Text = "  0";
            else if (phi1 == 1.0) label6.Text = "  π";
            else if (phi1 == -1.0) label6.Text = "  -π";
            else label6.Text = $"{phi1}π";

            g.FillRectangle(Brushes.Black, x0, y0, 10 * SIZE, 10 * SIZE);
            g.FillRectangle(Brushes.Black, x1, y1, 10 * SIZE, 10 * SIZE);
            g.FillRectangle(Brushes.Black, x2, y2, 20 * SIZE, 20 * SIZE);

            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(Pens.LightGray, x0 + i * SIZE, y0, x0 + i * SIZE, y0 + 10 * SIZE);
                g.DrawLine(Pens.LightGray, x0, y0 + i * SIZE, x0 + 10 * SIZE, y0 + i * SIZE);

                g.DrawLine(Pens.LightGray, x1 + i * SIZE, y1, x1 + i * SIZE, y1 + 10 * SIZE);
                g.DrawLine(Pens.LightGray, x1, y1 + i * SIZE, x1 + 10 * SIZE, y1 + i * SIZE);

                g.DrawLine(Pens.LightGray, x2 + i * 2 * SIZE, y2, x2 + i * 2 * SIZE, y2 + 20 * SIZE);
                g.DrawLine(Pens.LightGray, x2, y2 + i * 2 * SIZE, x2 + 20 * SIZE, y2 + i * 2 * SIZE);
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i <= 10 * SIZE; i++)
            {
                var time = i / (10.0F * SIZE);
                var x = (float) Math.Sin(omegaX * time);
                var y = (float) Math.Sin(omegaY * time + phi);
                var xx0 = x0 + i;
                var yy0 = y0 + ( 5 - 4 * x) * SIZE;
                var xx1 = x1 + i;
                var yy1 = y1 + (5 - 4 * y) * SIZE;
                var xx2 = x2 + (5 - 4 * x) * SIZE * 2;
                var yy2 = y2 + (5 + 4 * y) * SIZE * 2;
                if (i != 0)
                {
                    g.DrawLine(Pens.LightGreen, xx0_old, yy0_old, xx0, yy0);
                    g.DrawLine(Pens.LightGreen, xx1_old, yy1_old, xx1, yy1);
                    g.DrawLine(Pens.LightGreen, xx2_old, yy2_old, xx2, yy2);
                }

                xx0_old = xx0;
                yy0_old = yy0;
                xx1_old = xx1;
                yy1_old = yy1;
                xx2_old = xx2;
                yy2_old = yy2;
                if (showFlag)
                {
                    Thread.Sleep(20);
                }

                showFlag = false;
            }
        }
    }
}
