namespace SimpleSpaceGame
{
    partial class SpaceWars
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
            this.engineTimer = new System.Windows.Forms.Timer(this.components);
            this.starsTimer = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTimeValue = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.labelEndGame = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // engineTimer
            // 
            this.engineTimer.Enabled = true;
            this.engineTimer.Tick += new System.EventHandler(this.engineTimer_Tick);
            // 
            // starsTimer
            // 
            this.starsTimer.Enabled = true;
            this.starsTimer.Interval = 10;
            this.starsTimer.Tick += new System.EventHandler(this.starsTimer_Tick);
            // 
            // labelTime
            // 
            this.labelTime.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTime.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTime.ForeColor = System.Drawing.Color.DeepPink;
            this.labelTime.Location = new System.Drawing.Point(679, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(46, 23);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "Czas";
            // 
            // labelTimeValue
            // 
            this.labelTimeValue.AutoSize = true;
            this.labelTimeValue.ForeColor = System.Drawing.Color.DeepPink;
            this.labelTimeValue.Location = new System.Drawing.Point(731, 9);
            this.labelTimeValue.Name = "labelTimeValue";
            this.labelTimeValue.Size = new System.Drawing.Size(13, 13);
            this.labelTimeValue.TabIndex = 1;
            this.labelTimeValue.Text = "0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // labelEndGame
            // 
            this.labelEndGame.AutoSize = true;
            this.labelEndGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEndGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEndGame.ForeColor = System.Drawing.Color.DeepPink;
            this.labelEndGame.Location = new System.Drawing.Point(135, 306);
            this.labelEndGame.Name = "labelEndGame";
            this.labelEndGame.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelEndGame.Size = new System.Drawing.Size(552, 33);
            this.labelEndGame.TabIndex = 0;
            this.labelEndGame.Text = "Zderzyłes sie z asteroida, restartuje gre...";
            this.labelEndGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpaceWars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.labelEndGame);
            this.Controls.Add(this.labelTimeValue);
            this.Controls.Add(this.labelTime);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "SpaceWars";
            this.Text = "Space Wars";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpaceWars_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceWars_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer engineTimer;
        private System.Windows.Forms.Timer starsTimer;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTimeValue;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label labelEndGame;
    }
}

