using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class NonReflective : Skin{

        public RColor Color(P3 p, Ray r, SceneObject s) {
            RColor light = Form1.getLight(p, s.Geo.Normal(p));
            return light.Mul(s.Texture.Color(s.Geo.ToP2(p)));
        }
    }
}
