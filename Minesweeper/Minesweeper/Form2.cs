using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GlobalVariables.width = Convert.ToInt32(WidthBox.Text);
            GlobalVariables.height = Convert.ToInt32(HeightBox.Text);

            int difficulty = 0;

            //Hard coded.
            switch (DiffBox.Text)
            {
                case "Easy":
                    difficulty = 8;
                break;
                case "Normal":
                    difficulty = 6;
                break;
                case "Hard":
                    difficulty = 4;
                break;
                case "Impossible":
                    difficulty = 2;
                break;
            }

            GlobalVariables.difficulty = difficulty;

            if (GlobalVariables.height <= 35 && GlobalVariables.width <= 80)
            {
                GlobalVariables.ButtonPressed = true;
                this.Hide(); //Hide first, then close. Otherwise the form will be a ghost form.
                this.Close();
            }
        }
    }
}
