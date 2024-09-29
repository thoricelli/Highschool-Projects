using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{

    public static class GlobalVariables
    {
        public static int width = 16;
        public static int height = 16;
        public static int difficulty = 5;
        public static bool ButtonPressed = false;
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form StartupForm = new Form2();

            StartupForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormIsClosed); //Append the close function.

            Application.Run(StartupForm);

            void FormIsClosed(Object sender, FormClosingEventArgs e)
            {
                Form FieldForm = new Form1(GlobalVariables.width, GlobalVariables.height, GlobalVariables.difficulty); //Give the paramaters with the form.
                if (GlobalVariables.ButtonPressed) FieldForm.ShowDialog(); //Show the field on close.
            }
        }

    }
}
