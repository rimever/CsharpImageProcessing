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

namespace WindowsFormsApp2_5
{
    public partial class Form1 : Form
    {
        private const int X0 = 50, Y0 = 60;
        private Rectangle graphArea = new Rectangle(X0, Y0, 600, 400);
        private const int MaxPoints = 20;
        private PointF[] data = new PointF[MaxPoints];
        private int dataNumber = 0;

        public Form1()
        {
            InitializeComponent();
            Paint += Form1Paint;
            MouseMove += Form1MouseMove;
            MouseClick += Form1MouseClick;
            buttonLine.Click += ButtonLineClick;
            buttonSpline.Click += ButtonSplineClick;
            buttonClearLine.Click += ButtonClearLineClick;
            buttonClearAll.Click += ButtonClearAllClick;
        }

        private void ButtonClearAllClick(object sender, EventArgs e)
        {
            dataNumber = 0;
            Invalidate();
        }

        private void ButtonClearLineClick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void ButtonSplineClick(object sender, EventArgs e)
        {
            if (dataNumber < 2) return;
            var g = CreateGraphics();
            var pointData = new PointF[dataNumber];
            for (int i = 0; i < dataNumber; i++)
            {
                pointData[i].X = X0 + data[i].X * 10;
                pointData[i].Y = Y0 + (40 - data[i].Y) * 10;
            }

            var pen = new Pen(Color.Black, 2F) {DashStyle = DashStyle.Dash};
            g.DrawCurve(pen, pointData);
        }

        private void ButtonLineClick(object sender, EventArgs e)
        {
            if (dataNumber < 2) return;
            var g = CreateGraphics();
            var pointData = new PointF[dataNumber];
            for (int i = 0; i < dataNumber; i++)
            {
                pointData[i].X = X0 + data[i].X * 10;
                pointData[i].Y = Y0 + (40 - data[i].Y) * 10;
            }
            var pen = new Pen(Color.Gray, 2F);
            g.DrawLines(pen, pointData);
        }

        private void Form1MouseClick(object sender, MouseEventArgs e)
        {
            var g = CreateGraphics();
            if (!graphArea.Contains(e.X, e.Y))
            {
                return;
            }

            var x = (e.X - X0) / 10F;
            var y = 40 - (e.Y - Y0) / 10F;
            try
            {
                data[dataNumber].X = x;
                data[dataNumber].Y = y;
                dataNumber++;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("入力点の数が多すぎます。", "エラー", MessageBoxButtons.OK);
            }
            var pen = new Pen(Color.Black,2F);
            g.DrawEllipse(pen, e.X - 3F, e.Y - 3F, 6F, 6F);
        }

        private void Form1MouseMove(object sender, MouseEventArgs e)
        {
            var g = CreateGraphics();
            g.FillRectangle(Brushes.White, X0 - 5, Y0 + 446, 180, 20);
            if (graphArea.Contains(e.X, e.Y))
            {
                var x = (e.X - X0) / 10F;
                var y = 40 - (e.Y - Y0) / 10F;
                g.DrawString($"X={x}, Y={y}", Font, Brushes.Black, X0, Y0 + 450);
            }
        }

        private void Form1Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            for (int i = 0; i <= 60; i++)
            {
                g.DrawLine(Pens.LightGray, X0 + 10 * i, Y0, X0 + 10 * i, Y0 + 400);
            }
            for (int i = 0; i <= 40; i++)
            {
                g.DrawLine(Pens.LightGray, X0, Y0 + 10 * i, X0 + 600, Y0 + 10 * i);
            }

            for (int i = 0; i <= 12; i++)
            {
                g.DrawLine(Pens.Gray, X0 + 50 * i, Y0, X0 + 50 * i, Y0 + 400);
                g.DrawString($"{5 * i}", Font, Brushes.Black, X0 - 15 + 50 * i, Y0 + 410);
            }

            for (int i = 0; i <= 8; i++)
            {
                g.DrawLine(Pens.Gray, X0, Y0 + 50 * i, X0 + 600, Y0 + 50 * i);
                g.DrawString($"{5 * (8 - i)}", Font, Brushes.Black, X0 - 30, Y0 - 6 + 50 * i);
            }

            var pen = new Pen(Color.Black, 2);
            for (int i = 0; i < dataNumber; i++)
            {
                var xx = X0 + data[i].X * 10;
                var yy = Y0 + (40 - data[i].Y) * 10;
                g.DrawEllipse(pen, xx - 3, yy - 3, 6F, 6F);
            }
        }
    }
}
