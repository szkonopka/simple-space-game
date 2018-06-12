using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
/// <summary>
/// Klasa Speceship implementująca interfejs ISpaceObject (metoda Draw()) do renderowania i sterowania obiektem X-Winga
/// </summary>
namespace SimpleSpaceGame
{
    public class Spaceship : SpaceObject
    {
        public readonly int MinHP = 0;
        public readonly int MaxHP = 100;
        string[] WeaponState { get; set; } = { "READY", "RELOADING" };
        public string CurrentWeaponState { get; set; }
        public int CurrentHP { get; set; }
        public float ReloadTimeMs { get; set; }
        public bool IsAbleToShoot { get; set; }
        // Zmienne Image, w których przechowujemy kolejne klatki animowanego statku - poklatkowość dwóch sprowadza się do animowania ogni z wydechu pojazdu
        public Image StayImg { get; set; } = Image.FromFile(@"..\..\img\spaceship-stay.png");
        public Image RunImgFirst { get; set; } = Image.FromFile(@"..\..\img\spaceship-run-1.png");
        public Image RunImgSecond { get; set; } = Image.FromFile(@"..\..\img\spaceship-run-2.png");
        public Image CurrentImg { get; set; }
        public List<Bullet> Bullets { get; set; } = new List<Bullet>();

        /// <summary>
        /// Konstruktor przekazujący form i ustawiający wycentrowany statek na dole ekranu
        /// </summary>
        /// <param name="form"></param>
        public Spaceship(Form form)
        {
            CurrentHP = MaxHP;
            X = form.Size.Width / 2 - StayImg.Height / 5 / 2;
            Y = form.Size.Height - StayImg.Size.Height / 4;
            CurrentImg = StayImg;
            IsAbleToShoot = true;
            ReloadTimeMs = 2000;
            CurrentWeaponState = WeaponState[0];
        }

        public void MoveBullets()
        {
            foreach (var bullet in Bullets)
            {
                bullet.MoveForward();
            }
        }

        /// <summary>
        /// Funkcja Draw() dla statku wczytuje obiekt CurrentImg i renderuje go na scenie - CurrentImg w czasie zmieniane jest w odpowiednim timerze
        /// </summary>
        /// <param name="e"></param>
        public virtual void Draw(PaintEventArgs e, Directions dir)
        {
            if (dir.down) this.Y += this.MoveValue;
            if (dir.up) this.Y -= this.MoveValue;
            if (dir.left) this.X -= this.MoveValue;
            if (dir.right) this.X += this.MoveValue;
            if (dir.shoot) Shoot(e);

            foreach (var bullet in Bullets)
            {
                bullet.Draw(e);
                if(bullet.Y < 0)
                {
                    CurrentWeaponState = WeaponState[1];
                    Bullets.Remove(bullet);
                    Thread reloading = new Thread(Reload);
                    reloading.Start();
                    break;
                }
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(CurrentImg, this.X, this.Y, CurrentImg.Width / 5, CurrentImg.Height / 5);
        }

        public void Reload()
        {
            Thread.Sleep(2000);
            IsAbleToShoot = true;
            CurrentWeaponState = WeaponState[0];
        }

        /// <summary>
        /// Prototyp funkcji dla strzału - kiedyś rozwinę
        /// </summary>
        /// <param name="e"></param>
        public void Shoot(PaintEventArgs e)
        {
            if(IsAbleToShoot)
            {
                Bullet btleft = new Bullet(this.X, this.Y, 1, 70);
                Bullet btright = new Bullet(this.X + CurrentImg.Width / 5, this.Y, 1, 70);
                Bullets.Add(btleft);
                Bullets.Add(btright);
                IsAbleToShoot = false;
            }
        }
    }
}
