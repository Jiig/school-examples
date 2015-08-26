using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace RayTrace {
    public partial class Form1 : Form {
        //public static float size = 250;
        public static float height = 600, width = 600;
        public static List<SceneObject> objects = new List<SceneObject>();
        public static List<Light> lights = new List<Light>();
        public float theta = 3, phi = 3;
        public static float cameraY = -5f;
        public static P3 cameraPos = new P3(0, cameraY, 0);
        public static RColor[,] cs;
        public static int numThreads = 24;
        Random rng = new Random();
        public Form1() {
            InitializeComponent();
            cs = new RColor[(int)width, (int)height];
            for (int i = 0; i < cs.GetLength(0); i++) {
                for (int j = 0; j < cs.GetLength(1); j++) {
                    cs[i, j] = new RColor(0, 0, 0);
                }
            }
            /*
            objects = new List<SceneObject> {
                new SceneObject(new Sphere(new P3(-0.4f,0,0), 0.5f),
                    new ImageTexture(RayTrace.Properties.Resources.Earth_texture),
                    new NonReflective()),
                new SceneObject(new Sphere(new P3(0.4f,-.2f,0), 0.3f),
                    new SolidTexture(new RColor(0,1,0)),
                    new NonReflective()),
                new SceneObject(new Sphere(new P3(0.5f,-0.4f,-0.5f), 0.2f, ve: new P3(1, 0, 0)),
                    new ImageTexture(RayTrace.Properties.Resources.Earth_texture),
                    new NonReflective()),
                new SceneObject(new Plane(new P3(0,0,0.5f), new P3(0,0,-1)),
                   new SolidTexture(new RColor(1,0,0)),
                   new Mirror())};
            lights = new List<Light> {
                new AmbientLight(new RColor(0.3f, 0.3f, 0.3f)),
                new DirectionalLight(new RColor(1,1,1), new P3(1,  -.2f, -.3f).Normalize())};
             * */
            objects = new List<SceneObject>();
            for (int i = -8; i < 9; i++) {
                for (int j = -8; j < 1; j++) {
                    objects.Add(new SceneObject(new Sphere(new P3(i, 50, j), 0.5f),
                                new ImageTexture(RayTrace.Properties.Resources.Earth_texture), new NonReflective()));
                }
            }
            objects.Add(new SceneObject(new Plane(new P3(0, 0, 0.5f), new P3(0, 0, -1)),
                   new SolidTexture(new RColor(1, 0, 0)),
                   new Mirror()));
            lights = new List<Light> { new AmbientLight(new RColor(0.2f, 0.2f, 0.2f)), 
                                        new DirectionalLight(new RColor(1, 1, 1), new P3(1, -.2f, -.3f).Normalize())};

            Trace();
            worldBox.Refresh();
        }

        public static SceneObject shootRay(Ray r, out float d) {
            d = -1;
            SceneObject close = null;
            foreach (SceneObject s in objects) {
                float ds = s.Distance(r);
                if (ds != -1 && ds > 0.01) {
                    if (d != -1) {
                        if (ds < d) {
                            d = ds;
                            close = s;
                        }
                    } else {
                        d = ds;
                        close = s;
                    }
                }
            }
            return close;
        }

        public static RColor getLight(P3 p, P3 normal) {
            RColor c = new RColor(0, 0, 0);
            foreach (Light l in lights) {
                c = c.Add(l.illumination(p, normal));
            }
            return c;
        }

        public void Trace() {
            Task[] tasks = new Task[numThreads];
            for (int i = 0; i < numThreads; i++) {
                float minRange = height / numThreads * i;
                float maxRange = height / numThreads * (i + 1);
                tasks[i] = (Task.Factory.StartNew(() => Threads.Trace(minRange, maxRange)));
            }
            Task.WaitAll(tasks);
            NormalizeColors(cs);
        }

        public void nonThreadedTrace() {
            float distance;
            P3 d;
            Ray r;
            SceneObject s;
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    d = new P3(i / Form1.width * 2 - 1, 0, j / Form1.height * 2 - 1);
                    r = new Ray(Form1.cameraPos, d.Sub(Form1.cameraPos));
                    s = Form1.shootRay(r, out distance);
                    if (s != null) {
                        try {
                            Form1.cs[i, j] = s.ColorAt(r.Travel(distance), r);
                        } catch (Exception e) { //Set pixel to black if there are any errors                            
                            Form1.cs[i, j] = new RColor(0, 0, 0);
                        }
                    }
                }
            }
        }

        public void NormalizeColors(RColor[,] cs) {
            float max = 0;
            for (int i = 0; i < cs.GetLength(0); i++) {
                for (int j = 0; j < cs.GetLength(1); j++) {
                    max = Math.Max(max, cs[i, j].Intensity());
                }
            }
            for (int i = 0; i < cs.GetLength(0); i++) {
                for (int j = 0; j < cs.GetLength(1); j++) {
                    cs[i, j] = cs[i, j].Normalize(max);
                }
            }
        }

        public P3 Normal(P3 p, P3 x) {
            return x.Sub(p).Scale((1 / (x.Magnitude() - p.Magnitude())));
        }

        private void thetaBar_Scroll(object sender, EventArgs e) {
            theta = thetaBar.Value;
            thetaLabel.Text = "Theta: " + thetaBar.Value;
            Trace();
        }

        private void worldBox_Paint(object sender, PaintEventArgs e) {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    int[] rgb = cs[i, j].toRGB();
                    //try {
                    e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb((int)rgb[0], (int)rgb[1], (int)rgb[2])), i, j, 1, 1);
                    //} catch (Exception f) {
                    //e.Graphics.FillRectangle(new SolidBrush(Color.Black), i, j, 1, 1);
                    //}
                }
            }
        }

        private void cameraBar_Scroll(object sender, EventArgs e) {
            cameraY = cameraBar.Value;
            cameraLabel.Text = "CameraY: " + cameraY;
            Trace();
        }

        private void phiBar_Scroll(object sender, EventArgs e) {
            phi = phiBar.Value;
            phiLabel.Text = "Phi: " + phiBar.Value;
            Trace();
        }

        private void runTestToolStripMenuItem_Click(object sender, EventArgs e) {
            saveFileDialog.Filter = "Text Files|*.txt";
            saveFileDialog.ShowDialog();
            String[] lines = new String[22];
            Stopwatch sw = new Stopwatch();
            lines[0] = "No Threading: ";
            sw = Stopwatch.StartNew();
            nonThreadedTrace();
            sw.Stop();
            lines[1] = "" + sw.Elapsed;
            lines[2] = "Threading: ";
            sw = Stopwatch.StartNew();
            Trace();
            sw.Stop();
            lines[3] = "" + sw.Elapsed;
            File.WriteAllLines(saveFileDialog.FileName, lines);
        }
    }
}
