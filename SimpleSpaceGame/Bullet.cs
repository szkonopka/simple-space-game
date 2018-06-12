using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimpleSpaceGame
{
    public class Bullet : SpaceObject
    {
        public int Height { get; set; }
        public int Width { get; set; }
        private System.Threading.Timer shootTimer;
        private PaintEventArgs e;
        public Bullet(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.MoveValue = 10;
        }

        public void MoveForward()
        {
            this.Y -= this.MoveValue;
        }

        public virtual void Draw(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(222, 0, 43));
            FillMode newFillMode = FillMode.Winding;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(brush, new Rectangle(X, Y, Width, Height));
        }

        private void Update(object StateObj)
        {
            this.Y += this.MoveValue;
            Draw(this.e);
        }

        public void Start(PaintEventArgs e)
        {
            this.e = e;
            shootTimer = new System.Threading.Timer(new TimerCallback(Update), null, 0, 1000);
        }
    }
}
