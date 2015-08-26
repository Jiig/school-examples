using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class Mirror : Skin{
        public RColor Color(P3 p, Ray r, SceneObject s) {
            P3 N = s.Geo.Normal(p);
            float c1 = -N.Dot(r.direction);
            P3 R1 = r.direction.Add(N.Scale(2).Scale(c1));
            float d;
            Ray r1 = new Ray(p, R1);
            SceneObject so = Form1.shootRay(r1, out d);
            if (so == null) {
                return new RColor(0, 0, 0);
            } else return so.ColorAt(r1.Travel(d), r1);
        }
    }
}
