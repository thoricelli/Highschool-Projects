using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace The_Game_Of_Life
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //SETUP
        public int generations = 0;
        public int bitmapWidth = 300;
        public int bitmapHeight = 300;
        public int[,] pixels = new int[300, 300];
        public int[,] pixels2 = new int[300, 300];
        Bitmap playground = new Bitmap(300, 300);


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = playground;
            RandomizeBoard();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }



        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!paused)
            {
                //EXTRA
                generations++;
                GenerationLabel.Text = "Generations: " + generations;
                //EXTRA

                //Create second array that doesn't get changed to check (pixels2 gets checked pixels gets changed)
                for (int y = 0; y < bitmapHeight; y++)
                {
                    for (int x = 0; x < bitmapWidth; x++)
                    {
                        pixels2[x, y] = pixels[x, y];
                    }
                }

                //Check pixels (neighbours, actions)
                for (int y = 0; y < bitmapHeight; y++)
                {
                    for (int x = 0; x < bitmapWidth; x++)
                    {
                        //COUNT
                        int neighbours = CalculateNeighbours(x, y);
                        //CHECK
                        if (neighbours < 2)
                        {
                            //DIES
                            pixels[x, y] = 0;
                        }
                        /*if (neighbours >= 3)
                        {
                            //LIVES (unneeded)
                        }*/
                        if (neighbours == 3)
                        {
                            //LIVES/BIRTH
                            pixels[x, y] = 1;
                        }
                        if (neighbours > 3)
                        {
                            //DIES; OVERPOPULATION
                            pixels[x, y] = 0;
                        }
                    }
                }

                //DRAW TO SCREEN
                for (int y = 0; y < bitmapHeight; y++)
                {
                    for (int x = 0; x < bitmapWidth; x++)
                    {
                        if (pixels[x, y] == 1)
                        {
                            ((Bitmap)pictureBox1.Image).SetPixel(x, y, Color.Black);
                        }
                        else
                        {
                            ((Bitmap)pictureBox1.Image).SetPixel(x, y, Color.White);
                        }

                    }
                }
                pictureBox1.Refresh();
            }
        }

        private int CalculateNeighbours(int xpos, int ypos) //XPOS and YPOS are the current position of the pixel.
        {
            int neighbours = 0, newxpos, newypos;
            neighbours -= pixels2[xpos, ypos]; //If the current pixel is lit then don't count it (is +'ed again by the check for loops).
            xpos -= 1; //Start from -1
            ypos -= 1; //Start from -1

            /*
             Count the pixels. Starting from -1,-1
             -> 000
                010 
                000
             */

            //Check 3x3 tiles
            for (int newy = 0; newy < 3; newy++)
            {
                for (int newx = 0; newx < 3; newx++)
                {
                    //Increments for counting (see schematic above)è
                    newxpos = xpos + newx; // BeginPositionX (given through function) + AddX (0,1,2)
                    newypos = ypos + newy;// BeginPositionY (given through function) + AddY (0,1,2)
                    //Increments for counting

                    if (newxpos > -1 && newxpos < bitmapWidth && newypos > -1 && newypos < bitmapHeight) //Check if it isn't outside the boundary
                    {
                        if (pixels2[newxpos, newypos] == 1) //If pixel is lit
                        {
                            neighbours++; //Add neighbour
                        }
                    }
                }
            }

            return neighbours;
        }

        private void RandomizeBoard()
        {
            Random random = new Random();
            //RANDOMIZE BOARD
            for (int y = 0; y < bitmapHeight; y++)
            {
                for (int x = 0; x < bitmapWidth; x++)
                {
                    pixels[x, y] = random.Next(0, 2); //Randomizing from 0 to 1
                }
            }
        }

        //EXTRA
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

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            label5.Text = trackBar1.Value.ToString();
        }

        bool paused = false;

        private void Button1_Click(object sender, EventArgs e)
        {
            paused = !paused;
            if (paused)
            {
                button1.Text = "PLAY";
            } else
            {
                button1.Text = "PAUSED";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            generations = 0;
            RandomizeBoard();
        }
    }
}
