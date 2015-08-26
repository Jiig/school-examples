using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class SceneObject {
        public Geometry Geo;
        public Texture Texture;
        public Skin Skin;
        public SceneObject(Geometry geo, Texture texture, Skin skin) {
            this.Geo = geo;
            this.Texture = texture;
            this.Skin = skin;
        }

        public float Distance(Ray r) {
            return Geo.Intersect(r);
        }

        public RColor ColorAt(P3 p, Ray r) {
            return Skin.Color(p, r, this);
        }
    }
}
