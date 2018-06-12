namespace SimpleSpaceGame
{
    partial class Startup
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
            this.labelNewGame = new System.Windows.Forms.Label();
            this.labelScoreBoard = new System.Windows.Forms.Label();
            this.labelExitGame = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNewGame
            // 
            this.labelNewGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNewGame.AutoSize = true;
            this.labelNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNewGame.ForeColor = System.Drawing.Color.DeepPink;
            this.labelNewGame.Location = new System.Drawing.Point(343, 57);
            this.labelNewGame.Name = "labelNewGame";
            this.labelNewGame.Size = new System.Drawing.Size(72, 33);
            this.labelNewGame.TabIndex = 0;
            this.labelNewGame.Text = "Play";
            this.labelNewGame.Click += new System.EventHandler(this.labelNewGame_Click);
            // 
            // labelScoreBoard
            // 
            this.labelScoreBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelScoreBoard.AutoSize = true;
            this.labelScoreBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelScoreBoard.ForeColor = System.Drawing.Color.DeepPink;
            this.labelScoreBoard.Location = new System.Drawing.Point(295, 204);
            this.labelScoreBoard.Name = "labelScoreBoard";
            this.labelScoreBoard.Size = new System.Drawing.Size(168, 33);
            this.labelScoreBoard.TabIndex = 1;
            this.labelScoreBoard.Text = "Best scores";
            this.labelScoreBoard.Click += new System.EventHandler(this.labelScoreBoard_Click);
            // 
            // labelExitGame
            // 
            this.labelExitGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelExitGame.AutoSize = true;
            this.labelExitGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelExitGame.ForeColor = System.Drawing.Color.DeepPink;
            this.labelExitGame.Location = new System.Drawing.Point(347, 351);
            this.labelExitGame.Name = "labelExitGame";
            this.labelExitGame.Size = new System.Drawing.Size(64, 33);
            this.labelExitGame.TabIndex = 2;
            this.labelExitGame.Text = "Exit";
            this.labelExitGame.Click += new System.EventHandler(this.labelExitGame_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.labelNewGame, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelExitGame, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelScoreBoard, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 92);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.48416F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.25792F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 442);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "Startup";
            this.Text = "Startup";
            this.Load += new System.EventHandler(this.Startup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Startup_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNewGame;
        private System.Windows.Forms.Label labelScoreBoard;
        private System.Windows.Forms.Label labelExitGame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
