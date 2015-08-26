using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Life
{
    public partial class Form1 : Form
    {
        public static bool donut = true;
        public bool going = false;
        public static bool[,] world, newworld;
        public static int worldlength = 50;
        public int steps;
        public int panx, pany;
        static float zoom = 1.0f;
        public int startx = 0, starty = 0;
        public bool pan;
        public int numThreads = Environment.ProcessorCount * 4;
        Threads ts = new Threads();
        public float cellSize;
        public static int population;
        public static Bitmap worldImage;
        public bool pasteing = false;
        public bool[,] pasteObj;
        public static bool displayGrid = false;
        public delegate void AdvanceDelegate();
        AdvanceDelegate adv;
        AdvanceDelegate display;
        int frameCount = 0;

        public static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }


        public void reset()
        {
            world = new bool[worldlength, worldlength];
            world[worldlength / 2, worldlength / 2] = true;
            world[worldlength / 2 - 1, worldlength / 2] = true;
            world[worldlength / 2, worldlength / 2 + 1] = true;
            world[worldlength / 2, worldlength / 2 - 1] = true;
            world[worldlength / 2 + 1, worldlength / 2 - 1] = true;
            steps = 0;
            display();
            worldBox.Refresh();
            if (going)
            {
                startstop.Text = "Start";
                going = false;
                timer.Stop();
            }
        }

        public void getPasteObj(String fileName)
        {
            String[] lines = File.ReadAllLines(fileName);
            pasteObj = new bool[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == ' ')
                    {
                        pasteObj[i, j] = false;
                    }
                    else pasteObj[i, j] = true;
                }
            }
        }

        public void paintPaste(int x, int y)
        {
            display();
            using (Graphics g = Graphics.FromImage(worldImage))
            {
                for (int i = 0; i < pasteObj.GetLength(0); i++)
                {
                    for (int j = 0; j < pasteObj.GetLength(1); j++)
                    {
                        if (pasteObj[i, j])
                        {
                            g.FillRectangle(new SolidBrush(Color.Blue), (i * cellSize) + x, (j * cellSize) + y, cellSize, cellSize);
                        }
                    }
                }
                worldBox.Image = worldImage;
                worldBox.Refresh();
            }
        }

        public void paste(int x, int y)
        {
            //Array of bools is the object to be placed
            //x, y is the position in the current world where the object is going to be placed
            //top left corner [x,y] = obj[0,0]
            int xsize = pasteObj.GetLength(0);
            int ysize = pasteObj.GetLength(1);
            for (int i = 0; i < xsize; i++)
            {
                for (int j = 0; j < ysize; j++)
                {
                    world[mod(i + x, worldlength), mod(j + y, worldlength)] = pasteObj[i, j];
                }
            }
            if (Control.ModifierKeys != Keys.Shift)
            {
                pasteing = false;
            }
            display();
        }

        public void threadedAdvance()
        {
            newworld = (bool[,])world.Clone();
            Task[] tasks = new Task[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                var i2 = i;
                int minRange = worldlength / numThreads * i;
                int maxRange = worldlength / numThreads * (i + 1);
                tasks[i] = (Task.Factory.StartNew(() => Threads.advance(min: minRange, max: maxRange, name: i2.ToString())));
            }
            Task.WaitAll(tasks);
            //All threads have run, time to update the world
            world = (bool[,])newworld.Clone();
        }

        public void advance()
        {
            newworld = (bool[,])world.Clone();
            for (int i = 0; i < worldlength; i++)
            {
                for (int j = 0; j < worldlength; j++)
                {
                    int ln = checkNeighbors(i, j);
                    if (world[i, j] == true)
                    {
                        //Console.WriteLine(String.Format("i: {0} j: {1} ln: {2}", i, j, ln));
                        if (ln < 2 || ln > 3) newworld[i, j] = false;
                    }
                    else if (world[i, j] == false)
                    {
                        if (ln == 3) newworld[i, j] = true;
                    }
                }
            }
            world = (bool[,])newworld.Clone();
        }

        public static int checkNeighbors(int x, int y)
        {
            int ln = 0;
            if (donut)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (world[mod(x + i, worldlength), mod(y + j, worldlength)])
                        {
                            if (i != 0 || j != 0)
                            {
                                ln++;
                            }
                        }
                    }
                }
            } //Do taurus things above
            else
            {
                for (int i = (x > 0 ? -1 : 0); i <= (x < worldlength - 1 ? 1 : 0); i++)
                {
                    for (int j = (y > 0 ? -1 : 0); j <= (y < worldlength - 1 ? 1 : 0); j++)
                    {
                        //Console.WriteLine(String.Format("x + i: {0}, y + j: {1}", x +i, y +j));
                        if (world[x + i, y + j])
                        {
                            if (i != 0 || j != 0)
                            {
                                ln++;
                            }
                        }
                    }
                }
            }
            return ln;
        }

        public static float getCellSize()
        {
            float c = 1000 / worldlength * zoom;
            if (c < 1) c = 1;
            return c;
        }

        public void ntdisplay()
        {
            cellSize = getCellSize();
            worldImage = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(worldImage);
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), panx, pany, 1000 * zoom, 1000 * zoom);
            for (int i = 0; i < worldlength; i++)
            {
                for (int j = 0; j < worldlength; j++)
                {
                    if (world[i, j])
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), (i * cellSize) + panx, (j * cellSize) + pany, cellSize, cellSize);
                    }
                    else if (displayGrid)
                    {
                        g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), (i * cellSize) + panx, (j * cellSize) + pany, cellSize, cellSize);
                    }
                }
            }
            worldBox.Image = worldImage;
            worldBox.Refresh();
        }

        public void tdisplay()
        {
            Task[] tasks = new Task[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                var i2 = i;
                int minRange = worldlength / numThreads * i;
                int maxRange = worldlength / numThreads * (i + 1);
                tasks[i] = (Task.Factory.StartNew(() => Threads.display(getCellSize(), worldlength, panx, pany, zoom, worldBox, minRange, maxRange)));
            }
            Task.WaitAll(tasks);
            worldBox.Image = worldImage;
            worldBox.Refresh();
        }

        public Form1()
        {
            InitializeComponent();
            adv = threadedAdvance;
            display = ntdisplay;
            worldImage = new Bitmap(1000, 1000);
            worldBox.MouseWheel += new MouseEventHandler(worldBox_MouseWheel);
            world = new bool[worldlength, worldlength];
            newworld = new bool[worldlength, worldlength];
            populationLabel.Text = String.Format("Population: {0} - Generation: {1} - World size: {2}x{2}",
                                        getPop(), steps, worldlength);
        }

        public void worldBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomBar.Value += 1;
            }
            else
            {
                if (zoomBar.Value > 2)
                {
                    zoomBar.Value -= 1;
                }
            }
            zoom = zoomBar.Value / 10.0f;
            worldBox.Refresh();
        }

        private void resetB_Click(object sender, EventArgs e)
        {
            reset();
            worldBox.Refresh();
        }

        private void advanceB_Click(object sender, EventArgs e)
        {
            advance();
            worldBox.Refresh();
        }

        private void worldBox_Paint(object sender, PaintEventArgs e)
        {
            //display(e.Graphics);
        }

        public int getPop()
        {
            int alive = 0;
            Task[] tasks = new Task[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                var i2 = i;
                int minRange = worldlength / numThreads * i;
                int maxRange = worldlength / numThreads * (i + 1);
                tasks[i] = (Task.Factory.StartNew(() => Threads.popCount(minRange, maxRange, ref alive)));
            }
            Task.WaitAll(tasks);
            return alive;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            adv();
            display();
            populationLabel.Text = String.Format("Population: {0} - Generation: {1} - World size: {2}x{2}",
                                        getPop(), steps, worldlength);
            steps++;
        }

        private void startstop_Click(object sender, EventArgs e)
        {
            if (going)
            {
                startstop.Text = "Start";
                going = false;
                timer.Stop();
            }
            else
            {
                startstop.Text = "Pause";
                going = true;
                timer.Start();
            }
        }

        public void startStop(String mode)
        {
            if (mode == "stop" || mode == "Stop")
            {
                startstop.Text = "Start";
                going = false;
                timer.Stop();
            }
            else if (mode == "Start" || mode == "start")
            {
                startstop.Text = "Stop";
                going = true;
                timer.Start();
            }
        }

        private void worldBox_MouseClick(object sender, MouseEventArgs e)
        {

            float i = (e.X - panx) / (cellSize);
            float j = (e.Y - pany) / (cellSize);
            Console.WriteLine(e.X - panx);
            Console.WriteLine(i + " " + j);
            if (!pasteing)
            {
                if (i >= 0 && i < worldlength && j >= 0 && j < worldlength)
                {
                    if (world[(int)i, (int)j])
                    {
                        world[(int)i, (int)j] = false;
                    }
                    else
                    {
                        world[(int)i, (int)j] = true;
                    }
                }
            }
            else
            {
                paste((int)i, (int)j);
            }
            display();
        }

        private void speedBar_Scroll(object sender, EventArgs e)
        {
            timer.Interval = speedBar.Value;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        public void saveFile()
        {
            try
            {
                saveFileDialog.Filter = "Text Files|*.txt";
                saveFileDialog.ShowDialog();
                string[] lines = new string[worldlength];
                for (int i = 0; i < worldlength; i++)
                {
                    for (int j = 0; j < worldlength; j++)
                    {
                        if (world[i, j])
                        {
                            lines[i] += "*";
                        }
                        else
                        {
                            lines[i] += " ";
                        }
                    }
                }
                File.WriteAllLines(saveFileDialog.FileName, lines);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("No file selected");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("No file selected");
            }
        }


        private void loadButton_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        public void loadFile()
        {
            try
            {
                openFileDialog.Filter = "Text Files|*.txt";
                openFileDialog.ShowDialog();
                String[] lines = File.ReadAllLines(openFileDialog.FileName);
                for (int i = 0; i < worldlength; i++)
                {
                    for (int j = 0; j < worldlength; j++)
                    {
                        if (lines[i][j] == ' ')
                        {
                            world[i, j] = false;
                        }
                        else if (lines[i][j] == '*')
                        {
                            world[i, j] = true;
                        }
                        else
                        {
                            Console.WriteLine("Unkown character in file, setting its position to false");
                            world[i, j] = false;
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("No file selected");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("No file selected");
            }
            display();
        }
        //Resize center math
        // m-n = growth
        // add g/2 to i and j
        private void sizeButton_Click(object sender, EventArgs e)
        {
            //int newSize = Int32.Parse(sizeText.Text);
            int newSize;
            try
            {
                newSize = Int32.Parse(sizeText.Text);
            }
            catch (FormatException f)
            {
                Console.WriteLine("World size is not a number, setting to 500");
                sizeText.Text = "Enter an integer";
                newSize = 50;
            }
            int g = newSize - worldlength;
            Console.WriteLine(String.Format("G: {0}, newSize: {1}", g, newSize));
            newworld = new bool[newSize, newSize];
            if (newSize >= worldlength)
            {
                for (int i = 0; i < worldlength; i++)
                {
                    for (int j = 0; j < worldlength; j++)
                    {
                        try
                        {
                            newworld[i + g / 2, j + g / 2] = world[i, j];
                        }
                        catch (IndexOutOfRangeException f)
                        {
                            newworld[i, j] = false;
                        }
                    }
                }
                //Console.WriteLine(newworld[250, 250]);
                world = newworld;
                //Console.WriteLine(world[250, 250]);
                worldlength = newSize;
            }
            else
            {
                for (int i = 0; i < newSize; i++)
                {
                    for (int j = 0; j < newSize; j++)
                    {
                        newworld[i, j] = world[i - g / 2, j - g / 2];
                    }
                }
                world = newworld;
                worldlength = newSize;
            }
            display();
        }

        private void worldBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pan)
            {
                panx += e.X - startx;
                pany += e.Y - starty;
                startx = e.X;
                starty = e.Y;
                display();
            }
            if (pasteing)
            {
                paintPaste(e.X, e.Y);
            }
        }

        private void worldBox_MouseDown(object sender, MouseEventArgs e)
        {
            startx = e.X;
            starty = e.Y;
            pan = true;
        }

        private void worldBox_MouseUp(object sender, MouseEventArgs e)
        {
            pan = false;
        }

        private void zoomBar_Scroll(object sender, ScrollEventArgs e)
        {
            zoom = zoomBar.Value / 10.0f;
            display();
        }

        private void worldBox_MouseEnter(object sender, EventArgs e)
        {
            worldBox.Focus();
        }

        private void donutBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (donutBox.SelectedIndex == 0)
            {
                donut = true;
            }
            else
            {
                donut = false;
            }
        }

        private void worldPanel_Paint(object sender, PaintEventArgs e)
        {
            display();
            e.Graphics.DrawImageUnscaled(worldImage, Point.Empty);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void displayGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayGridToolStripMenuItem.Checked)
            {
                displayGridToolStripMenuItem.Checked = false;
                displayGrid = false;
            }
            else
            {
                displayGridToolStripMenuItem.Checked = true;
                displayGrid = true;
            }
            display();
        }

        private void threadedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (threadedToolStripMenuItem.Checked)
            {
                threadedToolStripMenuItem.Checked = false;
                adv = advance;
            }
            else
            {
                threadedToolStripMenuItem.Checked = true;
                adv = threadedAdvance;
            }
        }

        private void gliderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteing = true;
            startStop("stop");
            getPasteObj("..\\..\\Prefabs\\glider.txt");
        }

        private void runTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Text Files|*.txt";
            saveFileDialog.ShowDialog();
            String[] lines = new String[22];
            Stopwatch sw = new Stopwatch();
            int[] worldlengths = { 50, 100, 500, 1000 };
            int g = 0;
            int linesIndex = 0;
            //non Threaded test
            lines[0] = "No Threading: ";
            
            foreach (int wl in worldlengths) {
                linesIndex++;
                worldlength = wl;
                reset();
                sw = Stopwatch.StartNew();
                while (g < 1000) {
                    advance();
                    g++;
                }
                sw.Stop();
                Console.WriteLine("Doing things");
                lines[linesIndex] = String.Format("Array size: {0} Time: {1}", worldlength, sw.Elapsed);                
                g = 0;
            }
            lines[++linesIndex] = "Multi Threading: ";
            foreach (int wl in worldlengths)
            {
                linesIndex++;
                worldlength = wl;
                reset();
                sw = Stopwatch.StartNew();
                while (g < 1000)
                {
                    threadedAdvance();
                    g++;
                }
                sw.Stop();
                Console.WriteLine("Doing threaded things");
                lines[linesIndex] = String.Format("Array size: {0} Time: {1}", worldlength, sw.Elapsed);
                g = 0;
            }
            File.WriteAllLines(saveFileDialog.FileName, lines);
        }

        private void gosperGliderGunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteing = true;
            startStop("stop");
            getPasteObj("..\\..\\Prefabs\\ggg.txt");
        }

        private void lightWeightSpaceShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteing = true;
            startStop("stop");
            getPasteObj("..\\..\\Prefabs\\lwss.txt");
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteing = true;
            startStop("stop");
            getPasteObj("..\\..\\Prefabs\\line.txt");
        }

        private void dieHardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteing = true;
            startStop("stop");
            getPasteObj("..\\..\\Prefabs\\diehard.txt");
        }


    }
}
