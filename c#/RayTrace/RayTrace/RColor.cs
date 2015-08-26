using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayTrace {
    public class RColor {
        public float R, G, B;

        public RColor(float r, float g, float b) {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public RColor Scale(float s) {
            return new RColor(R * s, G * s, B * s);
        }

        public RColor Add(RColor c) {
            return new RColor(this.R + c.R, this.G + c.G, this.B + c.B);
        }

        public RColor Mul(RColor c) {
            return new RColor(this.R * c.R, this.G * c.G, this.B * c.B);
        }

        public float Intensity() {
            return Math.Max(R, Math.Max(G, B));
        }

        public RColor Normalize(float inte) {
            return new RColor(R / inte, G / inte, B / inte);
        }

        public int[] toRGB() {
            return new int[] { (int)Math.Min(255, (R * 255)), (int)Math.Min(255, (G * 255)), (int)Math.Min(255, (B * 255)) };
        }

        public static RColor fromRGB(Color c) {
            float r = c.R / 255;
            float g = c.G / 255;
            float b = c.B / 255;            
            return new RColor(r, g, b);
        }
    }
}
