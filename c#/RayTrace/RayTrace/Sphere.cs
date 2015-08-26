using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class Sphere : Geometry {
        public P3 center;
        public float r;
        public P3 vn, ve;

        public Sphere(P3 p, float r, P3 vn = null, P3 ve = null) {
            this.center = p;
            this.r = r;
            this.vn = vn == null ? new P3(0, 0, 1) : vn;
            this.ve = ve == null ? new P3(-1, 0, 0) : ve;
        }

        public float Intersect(Ray E) {
            P3 P;
            P3 EO = center.Sub(E.start);
            float d;
            float v = EO.Dot(E.direction);
            float disc = (r * r) - ((EO.Dot(EO) - (v * v)));
            if (disc < 0) {
                return -1;
            } else {
                d = (float)Math.Sqrt(disc);
                P = E.start.Add(E.direction.Scale(v - d));
            }
            if (v - d < 0 && v + d < 0) {
                return -1;
            } else if (v - d > 0) return v - d;
            else return v + d;
        }

        public P3 Normal(P3 x) {
            return x.Sub(this.center).Scale(1 / r);
        }

        public P2 ToP2(P3 p) {            
            P3 vp = p.Sub(center).Normalize();
            //Console.WriteLine(-vn.Dot(vp));
            float vndot = -vn.Dot(vp);
            if (vndot < -1) vndot = -1;
            else if (vndot > 1) vndot = 1;
            float phi = (float)Math.Acos(vndot);
            float v = phi / (float)Math.PI;
            float u;
            float vpdotsin = vp.Dot(ve) / (float)Math.Sin(phi);
            if (vpdotsin < -1) vpdotsin = -1;
            else if (vpdotsin > 1) vpdotsin = 1;
            //theta = ( arccos( dot_product( Vp, Ve ) / sin( phi )) ) / ( 2 * PI) 
            float theta = ((float)Math.Acos(vpdotsin) / (2 * (float)Math.PI));
            if (vp.Dot(vn.Cross(ve)) > 0) {
                u = theta;
            } else {
                u = 1 - theta;
            }
            //Console.WriteLine(u + " " + v);
            return new P2(u, v);
        }
    }
}
