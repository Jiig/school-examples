using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class AmbientLight : Light {
        public RColor l;
        public AmbientLight(RColor l) {
            this.l = l;
        }

        public RColor illumination(P3 p, P3 normal) {
            return l;
        }
    }
}
