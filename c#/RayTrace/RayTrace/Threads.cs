using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTrace {
    public class Threads {
        public static void Trace(float minRange, float maxRange) {
            float distance;
            P3 d;
            Ray r;
            SceneObject s;
            for (int i = 0; i < Form1.width; i++) {
                for (int j = (int)minRange; j < (int)maxRange; j++) {
                    d = new P3(i / Form1.width * 2 - 1, 0, j / Form1.height * 2 - 1);
                    r = new Ray(Form1.cameraPos, d.Sub(Form1.cameraPos));
                    s = Form1.shootRay(r, out distance);
                    if (s != null) {
                        try {
                            Form1.cs[i, j] = s.ColorAt(r.Travel(distance), r);

                        } catch (FormatException e) { //Set pixel to black if there are any errors
                            Console.WriteLine(e);
                            Form1.cs[i, j] = new RColor(0, 0, 0);
                        }
                    }
                }
            }
        }
    }
}
