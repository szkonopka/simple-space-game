using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Klasa Star implementująca interfejs ISpaceObject (metoda Draw()) do renderowania efektu tła - losowe smugi, będące reprezentacją gwiazd na ekranie
/// </summary>
namespace SimpleSpaceGame
{
    public class Star : ISpaceObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }

        /// <summary>
        /// Konstruktor z predefinowanymi parametrami
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Speed"></param>
        public Star(int X, int Y, int Speed)
        {
            this.X = X;
            this.Y = Y;
            this.Speed = Speed;
        }

        /// <summary>
        /// Konstruktor z losowymi parametrami
        /// </summary>
        /// <param name="rndGen"></param>
        /// <param name="form"></param>
        public Star(Random rndGen, Form form)
        {
            X = rndGen.Next(-(int)Math.Floor((double)form.Size.Width), (int)Math.Floor((double)form.Size.Width));
            Y = rndGen.Next(-(int)Math.Floor((double)form.Size.Height), (int)Math.Floor((double)form.Size.Height));
            Speed = rndGen.Next(20, 50);
        }

        /// <summary>
        /// Metoda gwiazd dla klasy Star renderuje prostokąty, które stworzą ciekawy efekt na ekranie
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(222, 222, 222)), new Rectangle(X, Y, 1, 50));
        }
    }
}
