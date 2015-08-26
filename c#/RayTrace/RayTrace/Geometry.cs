using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace
{
    public interface Geometry
    {
        float Intersect(Ray r);
        P3 Normal(P3 p);
        P2 ToP2(P3 p);
    }
}
