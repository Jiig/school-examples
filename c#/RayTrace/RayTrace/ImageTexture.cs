using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayTrace {
    public class ImageTexture : Texture {
        public Bitmap image;

        public ImageTexture(Bitmap image) {
            this.image = image;
            //Console.WriteLine(image.GetPixel(50, 50));
        }

        public RColor Color(P2 p) {
            //Console.WriteLine(p.X * image.Width + " " + p.Y * image.Height);
            Color c;
            lock (image) {
                c = image.GetPixel((int)(p.X < 1.0f ? p.X * image.Width : image.Width - 1), (int)(p.Y < 1.0f ? p.Y * image.Height: image.Height - 1));
            }
            //Console.WriteLine(c.R / 255.0f);
            return new RColor(c.R / 255.0f, c.G / 255.0f, c.B / 255.0f);
        }
    }
}
