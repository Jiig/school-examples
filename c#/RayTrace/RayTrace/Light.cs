using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public interface Light {
        RColor illumination(P3 p, P3 normal);
    }
}
