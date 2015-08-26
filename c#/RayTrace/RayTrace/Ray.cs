using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class Ray {
        public P3 start, direction;
        public RColor color;

        public Ray(P3 start, P3 direction) {
            this.start = start;
            this.direction = direction.Normalize();
            color = new RColor(0, 0, 0);
        }

        public P3 Travel(float distance) {
            this.start = this.start.Add(direction.Scale(distance));
            return start;
        }
    }

}
