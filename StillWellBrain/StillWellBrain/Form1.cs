using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StillWellBrain
{
    public partial class Form1 : Form
    {
        //MODEL BY Chris Eliasmith (2018)
        int[,] model =
        { //STARTS AT 26
        {1,2,3},
        {2,3,4},
        {3,4,5},
        {6,7,8},
        {7,8,9},
        {8,9,10},
        {11,12,13},
        {12,13,14},
        {13,14,15},
        {16,17,18},
        {17,18,19},
        {18,19,20},
        {21,22,23},
        {22,23,24},
        {23,24,25},
        {1,6,11},
        {6,11,16},
        {11,16,21},
        {2,7,12},
        {7,12,17},
        {12,17,22},
        {3,8,13},
        {8,13,18},
        {13,18,23},
        {4,9,14},
        {9,14,19},
        {14,19,24},
        {5,10,15},
        {10,15,20},
        {15,20,25},
        {0,0,0},
        {6,12,18},
        {0,0,0},
        {0,0,0},
        {7,13,19},
        {0,0,0},
        {0,0,0},
        {8,14,20},
        {0,0,0},
        {15,19,23},
        {10,14,18},
        {14,18,22},
        {5,9,13},
        {9,13,17},
        {13,17,21},
        {4,8,12},
        {8,12,16},
        {3,7,11},
        {8,12,18},
        {9,13,19},
        {10,14,20},
        {26,41,0},
        {26,47,0},
        {32,41,0},
        {32,47,0},
        {32,43,0},
        {32,49,0},
        {38,43,0},
        {38,49,0},
        {27,44,0},
        {27,50,0},
        {33,44,0},
        {33,50,0},
        {33,46,0},
        {33,52,0},
        {39,46,0},
        {39,52,0},
        {47,28,0},
        {53,28,0},
        {34,47,0},
        {34,53,0},
        {34,49,0},
        {34,55,0},
        {40,49,0},
        {40,55,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {41,42,0},
        {42,43,0},
        {44,45,0},
        {45,46,0},
        {47,48,0},
        {48,49,0},
        {50,51,0},
        {51,52,0},
        {53,54,0},
        {54,55,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {26,57,0},
        {26,72,0},
        {38,57,0},
        {38,72,0},
        {27,60,0},
        {27,69,0},
        {39,60,0},
        {39,69,0},
        {28,63,0},
        {28,66,0},
        {40,63,0},
        {40,66,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {29,70,0},
        {30,67,0},
        {31,65,0},
        {32,73,0},
        {33,71,0},
        {34,68,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {47,74,0},
        {50,75,0},
        {53,76,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {78,81,83},
        {86,89,91},
        {94,97,99},
        {130,132,0},
        {134,136,0},
        {138,140,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {78,82,84},
        {86,90,92},
        {94,98,100},
        {78,84,153},
        {86,92,154},
        {94,100,155},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {79,116,0},
        {87,118,0},
        {95,120,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {77,82,84},
        {85,90,92},
        {93,98,100},
        {129,131,0},
        {133,135,0},
        {137,140,0},
        {0,0,0},
        {79,83,84},
        {87,91,92},
        {95,99,100},
        {82,83,147},
        {90,91,148},
        {98,99,149},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {78,115,0},
        {86,117,0},
        {94,119,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {130,131,0},
        {134,135,0},
        {138,139,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {78,79,116},
        {86,87,118},
        {94,95,120},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {0,0,0},
        {77,88,118},
        {85,96,120},
        {0,0,0},
        {77,83,115},
        {85,91,117},
        {93,99,119},
        };


        int[,] compex_cells = {
            {111,113,115,117,119,0},
            {112,114,116,118,120,0},
            {130,134,138,144,145,146},
        }; //STARTS AT 291

        int[,] IT = {
            {245,246,247,248,249,0,0,0,0,0,0,0,0,0,0}, //0
            {156,157,158,159,160,291,292,0,0,0,0,0,0,0,0}, //1
            {171,172,173,174,175,176,179,288,289,290,0,0,0,0,0}, //2
            {181,182,183,184,185,186,189,271,272,273,0,0,0,0,0}, //3
            {190,191,192,193,194,195,265,266,267,268,269,270,285,286,287}, //4
            {196,197,198,199,200,201,0,0,0,0,0,0,0,0,0}, //5
            {203,204,205,206,207,208,0,0,0,0,0,0,0,0,0}, //6
            {216,217,218,274,275,276,293,0,0,0,0,0,0,0,0}, //7
            {227,228,229,230,231,277,278,279,280,281,0,0,0,0,0}, //8
            {233,234,235,242,243,261,262,263,0,0,0,0,0,0,0}, //9

        }; //STARTS AT 251

        int pointer = -1; //Too lazy to use lists
        int[] activatedcells = new int[293]; //293 Total cells

        Bitmap playground = new Bitmap(5, 5);
        bool holdingdraw = false;
        bool holdingerase = false;

        public Form1()
        {
            InitializeComponent();
            for (int x = 0; x < playground.Height; x++)
            {
                for (int y = 0; y < playground.Width; y++)
                {
                    playground.SetPixel(x, y, Color.White);
                }
            }
            pictureBox1.Image = playground;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(playground, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
            0,
            0,
            playground.Width,
            playground.Height,
            GraphicsUnit.Pixel);
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            holdingdraw = false;
            holdingerase = false;
            if (e.Button == MouseButtons.Left)
            {
                holdingdraw = true;
            } else
            {
                holdingerase = true;
            }
            Draw(e);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                holdingdraw = false;
            }
            else
            {
                holdingerase = false;
            }
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            holdingdraw = false;
            holdingerase = false;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Draw(e);
        }

        public void Draw(MouseEventArgs e)
        {
            if (holdingdraw || holdingerase)
            {
                //219; 190
                double dcalculatedX = (Convert.ToDouble(e.X) / 219 * playground.Width), dcalculatedY = (Convert.ToDouble(e.Y) / 190 * playground.Height);
                int calculatedX = Convert.ToInt32(dcalculatedX), calculatedY = Convert.ToInt32(dcalculatedY);
                if (calculatedX > -1 && calculatedX < playground.Width && calculatedY > -1 && calculatedY < playground.Height)
                {
                    Color holdingcolor = Color.White;
                    if (holdingerase)
                    {
                        holdingcolor = Color.White;
                    }
                    else if (holdingdraw)
                    {
                        holdingcolor = Color.Black;
                    }
                    ((Bitmap)pictureBox1.Image).SetPixel(calculatedX, calculatedY, holdingcolor);
                    pictureBox1.Refresh();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < activatedcells.Length; i++)
            {
                activatedcells[i] = 0;
            }
            pointer = -1;
            //RETNA (EYES)
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Color pixelcolor = ((Bitmap)pictureBox1.Image).GetPixel(x, y);
                    if (pixelcolor.Name == "ff000000")
                    {
                        pointer++;
                        activatedcells[pointer] = (x + (y * 5))+1;
                    }
                }
            }
            if (pointer <= -1) {
                pointer = 0;
            }

            /*foreach (var item in activatedcells)
            {
                Debug.WriteLine(item);
            }
            /*int[] retina = {0, 1, 1, 1, 0,
                            0, 0, 0, 1, 0,
                            0, 1, 1, 1, 0,
                            0, 0, 0, 1, 0,
                            0, 1, 1, 1, 0};

            for (int i = 0; i < retina.Length; i++)
            {
                if (retina[i] == 1) {
                    pointer++;
                    activatedcells[pointer] = 1 + i;
                }
            }*/
            //V1-V2
            ProcessCells(ref model, 222, 3, 26, 1);
            //V3 (COMPLEX CELLS)
            ProcessCells(ref compex_cells, 3, 6, 291, 0);
            //FINAL ANSWER (IT)
            int prioritycell = 0;
            bool found = false;
            int[] sortarray = { 259, 260, 251, 253, 254, 258, 257, 255 };
            ProcessCells(ref IT, 10, 15, 251, 0);
            /*
             PRIORITY LIST
             1.259 (8)
             2.260 (9)
             3.251 (0)
             4.253 (2)
             5.254 (3)
             6.258 (7)
             7.257 (6)
             8.255 (4)
             */
            string celltext = "";
            for (int i = 0; i < sortarray.Length; i++)
            {
                if (activatedcells.Contains(sortarray[i]) && found == false)
                {
                    found = true;
                    prioritycell = sortarray[i];
                    i = sortarray.Length;
                }
            }
            if (found == false)
            {
                prioritycell = activatedcells[pointer];
            }
            if ((prioritycell - 251) > 0)
            {
                celltext = (prioritycell - 251).ToString();
            } else
            {
                celltext = "Not a number";
            }
            label2.Text = "I think your number is: " + celltext;
            label2.Visible = true;
        }

        public void ProcessCells(ref int[,] tArray, int sizeX, int sizeY, int start, int method)
        {
            for (int i = 0; i < sizeX; i++)
            {
                bool should_fire = true;
                for (int j = 0; j < sizeY; j++)
                {
                    if (tArray[i, j] != 0)
                    {
                        if (!activatedcells.Contains(tArray[i, j]) && method == 1)
                        {
                            should_fire = false;
                        }
                        else if (activatedcells.Contains(tArray[i, j]) && method == 0)
                        {
                            pointer++;
                            activatedcells[pointer] = start + i;
                            j = sizeY;
                        }   
                    }
                }
                if (should_fire && method == 1 && tArray[i,0] != 0)
                {
                    pointer++;
                    activatedcells[pointer] = start + i;
                }
            }
        }

        public void clean()
        {
            for (int i = 0; i < activatedcells.Length; i++)
            {
                activatedcells[i] = 0;
            }
        }
    }
}
