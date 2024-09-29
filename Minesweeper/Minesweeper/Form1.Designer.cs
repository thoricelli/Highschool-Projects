namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimeSpentLabel = new System.Windows.Forms.Label();
            this.FlagLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SmilyPicture = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PositionLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmilyPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeSpentLabel
            // 
            this.TimeSpentLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TimeSpentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeSpentLabel.Location = new System.Drawing.Point(12, 301);
            this.TimeSpentLabel.Name = "TimeSpentLabel";
            this.TimeSpentLabel.Size = new System.Drawing.Size(264, 25);
            this.TimeSpentLabel.TabIndex = 1;
            this.TimeSpentLabel.Text = "Time spent:";
            this.TimeSpentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlagLabel
            // 
            this.FlagLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FlagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlagLabel.Location = new System.Drawing.Point(12, 326);
            this.FlagLabel.Name = "FlagLabel";
            this.FlagLabel.Size = new System.Drawing.Size(264, 25);
            this.FlagLabel.TabIndex = 3;
            this.FlagLabel.Text = "Flags left:";
            this.FlagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(17, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // SmilyPicture
            // 
            this.SmilyPicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SmilyPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SmilyPicture.Location = new System.Drawing.Point(131, 12);
            this.SmilyPicture.Name = "SmilyPicture";
            this.SmilyPicture.Size = new System.Drawing.Size(26, 26);
            this.SmilyPicture.TabIndex = 4;
            this.SmilyPicture.TabStop = false;
            this.SmilyPicture.Click += new System.EventHandler(this.SmilyPicture_Click);
            this.SmilyPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.SmilyPicture_Paint);
            this.SmilyPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SmilyPicture_MouseDown);
            this.SmilyPicture.MouseLeave += new System.EventHandler(this.SmilyPicture_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // PositionLabel
            // 
            this.PositionLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(251, 351);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(25, 13);
            this.PositionLabel.TabIndex = 6;
            this.PositionLabel.Text = "0, 0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Show field";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(289, 373);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.SmilyPicture);
            this.Controls.Add(this.FlagLabel);
            this.Controls.Add(this.TimeSpentLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmilyPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TimeSpentLabel;
        private System.Windows.Forms.Label FlagLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox SmilyPicture;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Button button1;
    }
}

