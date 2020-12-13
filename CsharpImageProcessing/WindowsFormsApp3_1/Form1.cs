using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3_1
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap0;
        private bool imageFlag;
        private int _processType;
        private Bitmap bitmap1;
        private Bitmap bitmap2;
        private string _fileName;

        public Form1()
        {
            InitializeComponent();
            openToolStripMenuItem.Click += OpenToolStripMenuItemClick;
            monochromeToolStripMenuItem.Click += MonochromeToolStripMenuItemOnClick;
            reverseColorToolStripMenuItem.Click += ReverseColorToolStripMenuItemClick;
            saveToolStripMenuItem.Click += SaveToolStripMenuItemClick;
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItemOnClick;
            undoToolStripMenuItem.Click += UndoToolStripMenuItemClick;
            Paint += Form1Paint;
        }

        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            SwitchProcess(0);
        }

        private void ReverseColorToolStripMenuItemClick(object sender, EventArgs e)
        {
            SwitchProcess(2);
        }

        private void SaveAsToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            if (!imageFlag)
            {
                MessageBox.Show("画像がありません", "エラー");
                return;
            }

            using (var saveFileDialog = new SaveFileDialog()
            {
                Title = "画像の保存",
                Filter = "JpgFile|*.jpg|PngFile|*.png|GifFile|*.gif|BmpFile|*.bmp",
                OverwritePrompt = true,
                AddExtension = true
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                SaveImage(saveFileDialog.FileName);
            }
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!imageFlag)
            {
                MessageBox.Show("画像がありません", "エラー");
                return;
            }
            SaveImage(_fileName);
        }

        private void SaveImage(string fileName)
        {
            var imageFormat = ImageFormat.Jpeg;
            string extension = Path.GetExtension(fileName);
            if (extension == ".jpg") imageFormat = ImageFormat.Jpeg;
            else if (extension == ".png") imageFormat = ImageFormat.Png;
            else if (extension == ".gif") imageFormat = ImageFormat.Gif;
            else if (extension == "bmp") imageFormat = ImageFormat.Bmp;
            var bitmapSave = new Bitmap(bitmap0.Width, bitmap0.Height);
            if (_processType == 0) bitmapSave = bitmap0;
            else if (_processType == 1) bitmapSave = bitmap1;
            else if (_processType == 2) bitmapSave = bitmap2;
            bitmapSave.Save(fileName, imageFormat);
        }

        private void Form1Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            int x0 = 10, y0 = 30;
            if (imageFlag)
            {
                Color color0;
                switch (_processType)
                {
                    case 0:
                        g.DrawImage(bitmap0, x0, y0);
                        break;
                    case 1:
                        bitmap1 = new Bitmap(bitmap0.Width, bitmap0.Height);
                        for (int j = 0; j < bitmap0.Height; j++)
                        {
                            for (int i = 0; i < bitmap0.Width; i++)
                            {
                                color0 = bitmap0.GetPixel(i, j);
                                int r0 = color0.R;
                                int g0 = color0.G;
                                int b0 = color0.B;
                                var y = (r0 * 2 + g0 * 4 + b0) / 7;
                                var color1 = Color.FromArgb(y, y, y);
                                bitmap1.SetPixel(i, j, color1);
                            }
                        }

                        g.DrawImage(bitmap1, x0, y0);
                        break;
                    case 2:
                        bitmap2 = new Bitmap(bitmap0.Width, bitmap0.Height);
                        for (int j = 0; j < bitmap0.Height; j++)
                        {
                            for (int i = 0; i < bitmap0.Width; i++)
                            {
                                color0 = bitmap0.GetPixel(i, j);
                                var r2 = 255 - color0.R;
                                var g2 = 255 - color0.G;
                                var b2 = 255 - color0.B;
                                var color2 = Color.FromArgb(r2, g2, b2);
                                bitmap2.SetPixel(i, j, color2);
                            }
                        }

                        g.DrawImage(bitmap2, x0, y0);
                        break;
                }
            }
        }

        private void MonochromeToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            SwitchProcess(1);
        }

        private void SwitchProcess(int processType)
        {
            if (!imageFlag) return;
            _processType = processType;
            Invalidate();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog()
            {
                Title = "画像の読み込み",
                Filter = "JpgFile|*.jpg|PngFile|*.png|GifFile|*.gif|BmpFile|*.bmp"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fileName = openFileDialog.FileName;
                    using (var bitmap = new Bitmap(openFileDialog.FileName))
                    {
                        bitmap0 = new Bitmap(bitmap);
                        imageFlag = true;
                        _processType = 0;
                        Invalidate();
                    }
                }
            }
        }

    }
}
