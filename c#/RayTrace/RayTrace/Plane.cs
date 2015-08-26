using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class Plane : Geometry{
        public P3 p, n;
        float d;
        public Plane(P3 p, P3 n) {
            this.p = p;
            this.n = n;
            d = -p.Dot(n);
        }

        public float Intersect(Ray r) {
            float t = -(d + n.Dot(r.start)) / n.Dot(r.direction);
            return t;
        }

        public P3 Normal(P3 p) {
            return n;
        }

        public P2 ToP2(P3 p) {
            return new P2(0, 0);
        }
    }
}
