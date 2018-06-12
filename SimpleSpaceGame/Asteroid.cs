using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSpaceGame
{
    /// <summary>
    /// Klasa tworząca obiekt asteroidy - wieloboku, których będzie musiał unikać statek na bazie wykrywania kolizji
    /// </summary>
    class Asteroid : SpaceObject
    {
        readonly int MaxRadius = 50;
        readonly int MinRadius = 30;

        readonly int MinAmountOfVertex = 5;
        readonly int MaxAmountOfVertex = 8;

        public int Radius { get; set; }
        public int AmountOfVertex { get; set; }
        private Color AsteroidColor { get; set; }
        public Point[] AsteroidPoints { get; set; }

        /// <summary>
        /// Konstruktor z losowymi parametrami - losujemy ilość wierzchołków wieloboka, jego kolor oraz zakres w jakim będzie rysowany od punkta centralnego
        /// </summary>
        /// <param name="rndGen"></param>
        /// <param name="form"></param>
        public Asteroid(Random rndGen, Form form)
        {
            this.AmountOfVertex = rndGen.Next(MinAmountOfVertex, MaxAmountOfVertex);
            AsteroidPoints = new Point[this.AmountOfVertex];
            this.Radius = rndGen.Next(MinRadius, MaxRadius);
            X = rndGen.Next(-(int)Math.Floor((double)form.Size.Width), (int)Math.Floor((double)form.Size.Width));
            Y = 0;
            MoveValue = rndGen.Next(10, 20);

            AsteroidColor = Color.FromArgb(rndGen.Next(100, 255), rndGen.Next(100, 255), rndGen.Next(100, 255));
           
            for (int i = 0; i < AmountOfVertex; i++)
                AsteroidPoints[i] = new Point(rndGen.Next(X - this.Radius, this.X + this.Radius), rndGen.Next(this.Y - this.Radius, this.Y + this.Radius));
        }

        /// <summary>
        /// Rysowanie i wypełnienie polygonu na bazie parametrów obiektu
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            SolidBrush brush = new SolidBrush(AsteroidColor);
            FillMode newFillMode = FillMode.Winding;

            e.Graphics.FillPolygon(brush, AsteroidPoints, newFillMode);
        }
    }
}
