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

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Image EntireBitmap = Bitmap.FromFile("cloneskin.bmp");

        int currface = 0, flags = 0, time = 0;
        bool isgamenotover = true;
        bool showfield = true;
        int difficulty1 = 5;
        /*
                           DECLARATION OF BITMAP
          0 = Smiling, 1 = Shock, 2 = Sad, 3 = Cool, 4 = Happypressed
          *NEW PART*
          0 = Empty tile, Number 1 = 1, Number 2 = 2, ...
          8 = Full tile, 9 = UNUSED, 10 = Bomb, ...
          *END OF NEW PART*
         */
        int sizex;
        int sizey;
        int[,] LowerLayer; //LowerLayer is used for bombs, numbers and empty tiles
        int[,] TopLayer;



        public Form1(int height, int width, int difficulty)
        {
            // --> Check main program, input comes from "Form2" the input form. 
            sizex = height;
            sizey = width;
            difficulty1 = difficulty;
            LowerLayer = new int[height, width]; //Initialization
            TopLayer = new int[height, width];  //Initialization
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateField(difficulty1); //Generate a field
            pictureBox1.Width = sizex*16; //Tiles are 16x16 pixels*
            pictureBox1.Height = sizey*16; //*
            Size = new Size(pictureBox1.Width+50, pictureBox1.Height+160); //50 and 160 so that the text fits on-screen
            //NOT TEMPORARY
            FlagLabel.Text = "Flags left: " + flags;
            TimeSpentLabel.Text = "Time spent: " + time;
        }

        private void GenerateField(int difficulty) //Difficulty = the chance that a mine appears ...-1 (Easy to hard)
        {
            int totalbombs = 0;
            Random random = new Random();
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    int ran = random.Next(difficulty);
                    if (ran == 1) //If the current number == 1 then place a bomb, the chance decreases with each increase
                    {
                        totalbombs++;
                        LowerLayer[x, y] = 10;
                    }
                }
            }
            flags = totalbombs; //You only have a flag amounting to the total bombs.
            FlagLabel.Text = "Flags left: " + flags;
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    /*
                     * Usage of this for loop is to generate the numbers, 
                     * it counts every bomb in it's 3x3 radius then changes 
                     * the tile to that number.
                    
                     Start from the 1st position and scan downwards
                     |*--|      |-*-| -->
                     |-#-| -->  |-#-|    |
                     |---|      |---|    * 
                     */
                    int startpositionX = x - 1;
                    int startpositionY = y - 1;
                    int mines = 0;

                    if (LowerLayer[x, y] != 10)
                    {
                        for (int yScan = startpositionY; yScan < startpositionY+3; yScan++) //Y-grid scan
                        {
                            for (int xScan = startpositionX; xScan < startpositionX+3; xScan++) //X-grid scan
                            {
                                if (yScan >= 0 && yScan < sizey && xScan >= 0 && xScan < sizex) //Make sure it's not out of bounds, or the current number position.
                                {
                                    if (LowerLayer[xScan, yScan] == 10) //Is it a bomb? Add that to the list.
                                    {
                                        mines++;
                                    }
                                }
                            }
                        }
                        LowerLayer[x, y] = mines; //Look at table up above
                    }
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            //264; 254
            //UNUSED
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /*
             The use of this function is to draw the board, with interpolation, so that it looks better.
             */
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    int fieldv = LowerLayer[x, y];
                    int upperl = TopLayer[x, y];
                    int bmpX = 0;
                    int bmpY = 0;

                    //These if's are used to see if it is the most upper or most down layer of tiles (inside the bitmap).
                    if (fieldv > 8)
                    {
                        bmpY++;
                        fieldv = fieldv - 8;
                    }
                    bmpX = fieldv;
                    if (upperl == 0 && showfield)
                    {
                        bmpX = 0;
                        bmpY = 1;
                    } else if (showfield && upperl != 1)
                    {
                        bmpY = 1;
                        bmpX = upperl;
                    }
                    //Draw the tile
                    e.Graphics.DrawImage(EntireBitmap, new Rectangle(x*16, y*16, 16, 16), new Rectangle(bmpX*16, bmpY*16, 16, 16), GraphicsUnit.Pixel);
                }
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isgamenotover)
            {
                currface = 1; //Show the :O on the screen.
                SmilyPicture.Refresh();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isgamenotover)
            {
                currface = 0; //Show the :) on the screen
                SmilyPicture.Refresh();
            }
        }

        private void SmilyPicture_Click(object sender, EventArgs e)
        {
            //This restarts the game. Calls all of it's functions (please check documentation on all of them)
            time = 0;
            timer1.Start();
            cleanup();
            GenerateField(difficulty1);
            currface = 0;
            isgamenotover = true;
            SmilyPicture.Refresh();
        }

        private void SmilyPicture_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                currface = 4; //Show that the smily is pressed; when holding down the button.
                SmilyPicture.Refresh();
            }
        }

        private void SmilyPicture_MouseLeave(object sender, EventArgs e)
        {
           currface = 0; //Did the mouse leave the screen, clear it's emotion.
           SmilyPicture.Refresh();
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = (e.X / 16);
            int mouseY = (e.Y / 16);
            if (isgamenotover)
            {

                if (e.Button == MouseButtons.Left)
                {
                    if (TopLayer[mouseX, mouseY] != 3 && TopLayer[mouseX, mouseY] != 6)
                    {
                        TopLayer[mouseX, mouseY] = 1;
                        if (LowerLayer[mouseX, mouseY] == 10) //If clicked on a bomb.
                        {
                            showall(); //Show all bombs
                            LowerLayer[mouseX, mouseY] = 13;
                            isgamenotover = false;
                            timer1.Stop(); //Stop the timer
                            TimeSpentLabel.Text = "Game over!";
                            currface = 2;
                            SmilyPicture.Refresh();
                        }
                        else if (LowerLayer[mouseX, mouseY] == 0 && TopLayer[mouseX, mouseY] != 0)
                        {
                            LookForEmptySpaces(mouseX, mouseY); //If theres empty spaces (around the cursor), show them
                        }
                    }
                } else if (e.Button == MouseButtons.Right && TopLayer[mouseX, mouseY] != 1 && flags > 0)
                {
                    //Kind of a dumb way to do this but this is the best I can think of at the moment.
                    int topv = TopLayer[mouseX, mouseY];
                    if (topv == 0)
                    {
                        flags--;
                        TopLayer[mouseX, mouseY] = 3;
                    } else if (topv == 3)
                    {
                        flags++;
                        TopLayer[mouseX, mouseY] = 6;
                    } else
                    {
                        TopLayer[mouseX, mouseY] = 0;
                    }
                    FlagLabel.Text = "Flags left: " + flags;
                }

                int totaltiles = 0;
                for (int x = 0; x < sizex; x++)
                {
                    for (int y = 0; y < sizey; y++)
                    {
                        if (TopLayer[x, y] == 0 || TopLayer[x, y] == 6)
                        {
                            totaltiles++; //Check the amounts of tiles for a win. (Excluding not-yet-shown-tiles, and question mark tiles --> "?") 
                        }
                    }
                }
                if (totaltiles <= 0)
                {
                    FlagLabel.Text = "You won!"; //Nicely done!
                    isgamenotover = false;
                    currface = 3;
                    SmilyPicture.Refresh();
                }

                pictureBox1.Refresh(); //Refresh field
            }
        }

        private void LookForEmptySpaces(int xpos,int ypos)
        {
            /*
             Check the spaces around the tiles, then if they are NOT a number, mine, etc...
             ... show them!
             If theres a number around an empty tile, you should show them so that the player at least has a clue.
             */

            int startX = xpos-1;
            int startY = ypos-1;


            for (int yScan = startY; yScan < startY + 3; yScan++)
            {
                for (int xScan = startX; xScan < startX+3; xScan++)
                {
                    if (xScan >= 0 && xScan < sizex && yScan >= 0 && yScan < sizey)
                    {
                        if (LowerLayer[xScan, yScan] == 0 && TopLayer[xScan,yScan] == 0)
                        {
                            TopLayer[xScan, yScan] = 1; 
                            LookForEmptySpaces(xScan, yScan); //Show other empty tiles
                        } else if (LowerLayer[xScan, yScan] != 10 && TopLayer[xScan, yScan] == 0) //10 = Bomb
                        {
                            TopLayer[xScan, yScan] = 1; //Show numbers but don't show other tiles.
                        }
                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Every second counts, down.
            time++;
            TimeSpentLabel.Text = "Time spent: " + time;
        }

        public void showall()
        {
            //For the cheaters, you can see where the mines are. Well and also for debug.
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    if (LowerLayer[x, y] == 10)
                    {
                        TopLayer[x, y] = 1;
                    }
                }
            }
            pictureBox1.Refresh();
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Debug purposes.
            PositionLabel.Text = (e.X / 16) + ", " + (e.Y / 16);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Change if they can see the field or not, for debug.
            showfield = !showfield;
            pictureBox1.Refresh();
        }

        public void cleanup()
        {
            //Cleanup the mess the player has made, AKA clean the field to prepare to generate a new one.
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    LowerLayer[x, y] = 0;
                    TopLayer[x, y] = 0;
                }
            }
            pictureBox1.Refresh();
        }

        private void SmilyPicture_Paint(object sender, PaintEventArgs e)
        {
            //25x26
            //50x52
            int offset = currface * 25;
            if (currface != 0) offset += (currface*2);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(EntireBitmap, new Rectangle(0, 0, 25, 26), new Rectangle(offset, 55, 25, 26), GraphicsUnit.Pixel); //Draw the face from the bitmap coordinates
        }
    }
}
