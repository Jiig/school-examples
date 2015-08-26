using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Life
{
    class Threads
    {
        public static void advance(int min = 0, int max = 50, string name = "")
        {
            for (int i = 0; i < Form1.worldlength; i++)
            {
                for (int j = min; j < max; j++)
                {
                    int ln = Form1.checkNeighbors(i, j);
                    if (Form1.world[i, j] == true)
                    {
                        if (ln < 2 || ln > 3) Form1.newworld[i, j] = false;
                    }
                    else if (Form1.world[i, j] == false)
                    {
                        if (ln == 3) Form1.newworld[i, j] = true;
                    }
                }
            }
        }

        public static void popCount(int min, int max, ref int alive)
        {
            for (int i = 0; i < Form1.worldlength; i++)
            {
                for (int j = min; j < max; j++)
                {
                    if (Form1.world[i, j])
                    {
                        alive++;
                    }
                }
            }
        }

        public static void display(float cellSize, int worldlength, int panx, int pany, float zoom, PictureBox worldBox, int minRange, int maxRange)
        {
            Form1.worldImage = new Bitmap(500, 500);
            Graphics g = Graphics.FromImage(Form1.worldImage);
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), panx, pany, 500 * zoom, 500 * zoom);
            for (int i = 0; i < worldlength; i++)
            {
                for (int j = minRange; j < maxRange; j++)
                {
                    if (Form1.world[i, j])
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), (i * cellSize) + panx, (j * cellSize) + pany, cellSize, cellSize);
                    }
                    else if (Form1.displayGrid)
                    {
                        g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), (i * cellSize) + panx, (j * cellSize) + pany, cellSize, cellSize);
                    }
                }
            }
        }
    }
}
