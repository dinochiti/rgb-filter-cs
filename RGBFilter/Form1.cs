using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGBFilter
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Stack<Image> undoImages = new Stack<Image>();
        private Stack<Image> redoImages = new Stack<Image>();

        public Form1()
        {
            InitializeComponent();
            this.toolStripMenuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
        }

        private void fileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image|*.png;*.jpg;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(@openFileDialog.FileName);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RGB Filter\n\n2024\n\nApply simple filters to the Red/Green/Blue pixel values to manipulate photos\n\nDemo C# WinForm application developed using Visual Studio Community Edition", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void filterPixels(Func<Color, Color> filterFunc)
        {
            if (pictureBox.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Image);
                for (int x = 0; x < bmp.Width; ++x)
                {
                    for (int y = 0; y < bmp.Height; ++y)
                    {
                        bmp.SetPixel(x, y, filterFunc(bmp.GetPixel(x, y)));
                    }
                }
                pictureBox.Image = bmp;
            }
        }

        // ChatGPT 3.5 suggested this less safe version of the pixel filtering
        //   function; it directly addresses and edits the pixel values in place
        //   (The safe version is quite slow; apparently GetPixel and SetPixel are
        //   "relatively slow for processing large images".)
        private unsafe void unsafeFilterPixels(Func<Color, Color> filterFunc)
        {
            if (pictureBox.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Image);
                int bytesPerPixel = Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                // this filtering approach is only appropriate for 24 and 32 bit pixel formats
                if (bytesPerPixel < 3 || bytesPerPixel > 4)
                {
                    // MessageBox.Show("Cannot filter pixels\n\n" + bytesPerPixel + " bytes-per-pixel format not compatible", "Filter Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    filterPixels(filterFunc);
                    return;
                }
                Rectangle bmpRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(bmpRect, ImageLockMode.ReadWrite, bmp.PixelFormat);

                byte* firstPixelPtr = (byte*)bmpData.Scan0;
                for (int y = 0; y < bmp.Height; ++y)
                {
                    byte* firstPixelInLinePtr = firstPixelPtr + y * bmpData.Stride;
                    for (int x = 0; x < bmp.Width; ++x)
                    {
                        int pixelIndex = x * bytesPerPixel;
                        Color newColor = filterFunc(Color.FromArgb(firstPixelInLinePtr[pixelIndex], firstPixelInLinePtr[pixelIndex + 1], firstPixelInLinePtr[pixelIndex + 2]));
                        firstPixelInLinePtr[pixelIndex] = newColor.R;
                        firstPixelInLinePtr[pixelIndex + 1] = newColor.G;
                        firstPixelInLinePtr[pixelIndex + 2] = newColor.B;
                    }
                }
                bmp.UnlockBits(bmpData);
                undoImages.Push(pictureBox.Image);
                redoImages.Clear();
                pictureBox.Image = bmp;
            }
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unsafeFilterPixels( (color) => {
                byte colorAve = (byte)(((int)color.R + (int)color.G + (int)color.B) / 3);
                return Color.FromArgb(colorAve, colorAve, colorAve);
            });
        }

        private void invertRedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unsafeFilterPixels((color) => {
                return Color.FromArgb(255 - color.R, color.G, color.B);
            });
        }

        private void invertGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unsafeFilterPixels((color) => {
                return Color.FromArgb(color.R, 255 - color.G, color.B);
            });
        }

        private void invertBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unsafeFilterPixels((color) => {
                return Color.FromArgb(color.R, color.G, 255 - color.B);
            });
        }

        private void invertAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unsafeFilterPixels((color) => {
                return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
            });
        }

        private byte scaleWithMax(byte value, double scaleFactor)
        {
            long newValue = (long)(value * scaleFactor);
            return newValue > 255 ? (byte)255 : (byte)newValue;
        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ScaleDialog scaleDialog = new ScaleDialog())
            {
                if (scaleDialog.ShowDialog() == DialogResult.OK)
                {
                    // retrieve the user settings for scaling
                    double scaleFactor = scaleDialog.scaleFactor;
                    double redScaleFactor = scaleDialog.scaleRed ? scaleFactor : 1.0;
                    double greenScaleFactor = scaleDialog.scaleGreen ? scaleFactor : 1.0;
                    double blueScaleFactor = scaleDialog.scaleBlue ? scaleFactor : 1.0;

                    unsafeFilterPixels((color) => {
                        return Color.FromArgb(scaleWithMax(color.R, redScaleFactor),
                                              scaleWithMax(color.G, greenScaleFactor),
                                              scaleWithMax(color.B, blueScaleFactor));
                    });
                }
            }
        }

        private void toolStripMenuItemUndo_Click(object sender, EventArgs e)
        {
            if (undoImages.Count > 0)
            {
                redoImages.Push(pictureBox.Image);
                pictureBox.Image = undoImages.Pop();
            }
        }

        private void toolStripMenuItemRedo_Click(object sender, EventArgs e)
        {
            if (redoImages.Count > 0)
            {
                undoImages.Push(pictureBox.Image);
                pictureBox.Image = redoImages.Pop();
            }
        }
    }
}
