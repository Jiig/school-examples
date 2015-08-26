using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace
{
    public interface Skin
    {        
        RColor Color(P3 p, Ray r, SceneObject s);
    }
}
