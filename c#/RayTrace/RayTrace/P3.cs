using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class P3 {
        public float x, y, z;
        public P3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public P3 Add(P3 p) {
            return new P3(this.x + p.x, this.y + p.y, this.z + p.z);
        }

        public P3 Sub(P3 p) {
            return new P3(this.x - p.x, this.y - p.y, this.z - p.z);
        }

        public P3 Scale(float s) {
            return new P3(this.x * s, this.y * s, this.z * s);
        }

        public float Magnitude() {
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public P3 Normalize() {
            if (Magnitude() != 0) {
                return new P3(this.x / Magnitude(), this.y / Magnitude(), this.z / Magnitude());
            } else {
                return this;
            }
        }

        public float Dot(P3 p) {
            return ((this.x * p.x) + (this.y * p.y) + (this.z * p.z));
        }

        public P3 Cross(P3 p) {
            return new P3((this.y * p.z) - (this.z * p.y), (this.z * p.x) - (this.x * p.z), (this.x * p.y) - (this.y * p.x));
        }

        public float Theta(P3 p) {
            return (float)Math.Acos(Dot(p) / p.Magnitude() * this.Magnitude());
        }

        public static P3 fromSphere(float theta, float phi) {
            return new P3((float) (Math.Cos(theta) * Math.Sin(phi)), (float)(Math.Sin(theta) * Math.Cos(phi)), (float)Math.Cos(phi));
        }
    }
}
