using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Library_Streamer
{
    public static class NVConverter
    {
        public static byte[] BytesFromBitmap(Bitmap b)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                b.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        public static Bitmap BitmapFromBytes(byte[] arr)
        {
            using (MemoryStream stream = new MemoryStream(arr))
            {
                Bitmap b = new Bitmap(stream);
                return b;
            }
        }

        public static Bitmap GetScreen()
        {
            Point point = System.Windows.Forms.Control.MousePosition;

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            Bitmap bitmap = new Bitmap(400, 400);
            Graphics graphics = Graphics.FromImage(bitmap as System.Drawing.Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);


            SolidBrush br = new SolidBrush(Color.Red);
            SolidBrush br1 = new SolidBrush(Color.Green);
            SolidBrush br2 = new SolidBrush(Color.Yellow);
            SolidBrush br3 = new SolidBrush(Color.Blue);

            //LinearGradientBrush br = new LinearGradientBrush(new Point(0,0), new Point(0, 0), Color.Blue, Color.Green);

            //Pen p = new Pen(br, 5);



            graphics.FillEllipse(br, new Rectangle(point.X, point.Y, 20, 20));
            graphics.FillEllipse(br1, new Rectangle(point.X, point.Y + 20, 20, 20));
            graphics.FillEllipse(br2, new Rectangle(point.X + 20, point.Y, 20, 20));
            graphics.FillEllipse(br3, new Rectangle(point.X + 20, point.Y + 20, 20, 20));

            return bitmap;
        }

    }
}
