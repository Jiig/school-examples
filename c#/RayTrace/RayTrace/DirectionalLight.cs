using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class DirectionalLight : Light {
        RColor c;
        P3 p;
        public DirectionalLight(RColor c, P3 p) {
            this.c = c;
            this.p = p;
        }

        public DirectionalLight(RColor c, float theta, float phi) {
            this.c = c;
            this.p = P3.fromSphere(theta, phi);
        }

        public RColor illumination(P3 point, P3 normal) {
            float inten = this.p.Dot(normal);
            RColor color = new RColor(0, 0, 0);
            if (inten > 0) {
                color = c.Scale(inten);
                float d;
                SceneObject s = Form1.shootRay(new Ray(point, this.p), out d);
                if (s != null) {
                    return new RColor(0, 0, 0);
                }
            }
            return color;
        }
    }
}
