using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class SolidTexture :Texture {
        public RColor c;

        public SolidTexture(RColor c) {
            this.c = c;
        }

        public RColor Color(P2 p) {
            return c;
        }
    }
}
