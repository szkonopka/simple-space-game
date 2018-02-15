using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Klasa Speceship implementująca interfejs ISpaceObject (metoda Draw()) do renderowania i sterowania obiektem X-Winga
/// </summary>
namespace SimpleSpaceGame
{
    public class Spaceship : ISpaceObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int LastX { get; set; }
        public int LastY { get; set; }
        public int MoveValue { get; set; } = 10;

        // Zmienne Image, w których przechowujemy kolejne klatki animowanego statku - poklatkowość dwóch sprowadza się do animowania ogni z wydechu pojazdu
        public Image StayImg { get; set; } = Image.FromFile(@"..\..\img\spaceship-stay.png");
        public Image RunImgFirst { get; set; } = Image.FromFile(@"..\..\img\spaceship-run-1.png");
        public Image RunImgSecond { get; set; } = Image.FromFile(@"..\..\img\spaceship-run-2.png");
        public Image CurrentImg { get; set; }

        /// <summary>
        /// Konstruktor przekazujący form i ustawiający wycentrowany statek na dole ekranu
        /// </summary>
        /// <param name="form"></param>
        public Spaceship(Form form)
        {
            X = form.Size.Width / 2 - StayImg.Height / 5 / 2;
            Y = form.Size.Height - StayImg.Size.Height / 4;
            CurrentImg = StayImg;
        }

        /// <summary>
        /// Funkcja Draw() dla statku wczytuje obiekt CurrentImg i renderuje go na scenie - CurrentImg w czasie zmieniane jest w odpowiednim timerze
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(CurrentImg, this.X, this.Y, CurrentImg.Width / 5, CurrentImg.Height / 5);
        }

        /// <summary>
        /// Prototyp funkcji dla strzału - kiedyś rozwinę
        /// </summary>
        /// <param name="e"></param>
        public void Shoot(PaintEventArgs e)
        {
            
        }
    }
}
