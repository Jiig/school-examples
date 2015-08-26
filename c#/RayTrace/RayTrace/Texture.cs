using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace
{
    public interface Texture
    {
        RColor Color(P2 p);
    }
}
