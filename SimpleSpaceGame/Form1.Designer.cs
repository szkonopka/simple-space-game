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
            this.labelTimeValue = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.labelEndGame = new System.Windows.Forms.Label();
            this.hpBar = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelWeaponState = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // engineTimer
            // 
            this.engineTimer.Enabled = true;
            this.engineTimer.Interval = 1;
            this.engineTimer.Tick += new System.EventHandler(this.engineTimer_Tick);
            // 
            // starsTimer
            // 
            this.starsTimer.Enabled = true;
            this.starsTimer.Interval = 20;
            this.starsTimer.Tick += new System.EventHandler(this.starsTimer_Tick);
            // 
            // labelTimeValue
            // 
            this.labelTimeValue.AutoSize = true;
            this.labelTimeValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTimeValue.ForeColor = System.Drawing.Color.DeepPink;
            this.labelTimeValue.Location = new System.Drawing.Point(3, 0);
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
            // hpBar
            // 
            this.hpBar.BackColor = System.Drawing.Color.DeepPink;
            this.hpBar.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.hpBar.Location = new System.Drawing.Point(12, 12);
            this.hpBar.Name = "hpBar";
            this.hpBar.Size = new System.Drawing.Size(131, 10);
            this.hpBar.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.labelTimeValue);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(689, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(83, 28);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // labelWeaponState
            // 
            this.labelWeaponState.AutoSize = true;
            this.labelWeaponState.ForeColor = System.Drawing.Color.DeepPink;
            this.labelWeaponState.Location = new System.Drawing.Point(12, 27);
            this.labelWeaponState.Name = "labelWeaponState";
            this.labelWeaponState.Size = new System.Drawing.Size(0, 13);
            this.labelWeaponState.TabIndex = 4;
            // 
            // SpaceWars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.labelWeaponState);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.hpBar);
            this.Controls.Add(this.labelEndGame);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "SpaceWars";
            this.Text = "Space Wars";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpaceWars_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceWars_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceWars_KeyUp);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer engineTimer;
        private System.Windows.Forms.Timer starsTimer;
        private System.Windows.Forms.Label labelTimeValue;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label labelEndGame;
        private System.Windows.Forms.ProgressBar hpBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelWeaponState;
    }
}

