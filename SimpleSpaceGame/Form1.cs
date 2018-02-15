using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSpaceGame
{
    public partial class SpaceWars : Form
    {
        // Database context
        //private DataScoreBoardDataContext ctx;

        // Objects declaration
        private Spaceship spaceship;
        private List<Star> starList;
        private List<Asteroid> asteroidInRoundList;

        // Helpers
        private int starsAmount = 20;
        private int asteroidsInRound = 8;

        private Random rndGen;
        private bool SpaceShipAnim = true;

        private Font PixelFont;
        private int secondsAlive = 0;
        private bool gameStopped = false;

        public SpaceWars()
        {
            //ctx = new DataScoreBoardDataContext();
            TurnOnDoubleBuffering();
            this.Width = 800;
            this.Height = 800;
            this.KeyPreview = true;

            spaceship = new Spaceship(this);
            starList = new List<Star>();
            asteroidInRoundList = new List<Asteroid>();
            rndGen = new Random();

            InitNewStars();
            InitNewAsteroids();
           
            InitializeComponent();
            Styling();

            starsTimer.Start();
            engineTimer.Start();
            gameTimer.Start();
        }

        /// <summary>
        /// Turn on double buffering - prevent faltering
        /// </summary>
        private void TurnOnDoubleBuffering()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// Label styles, Pixel Art font declaration
        /// </summary>
        private void Styling()
        {
            InitCustomFont();
            this.labelTime.Font = PixelFont;
            this.labelTimeValue.Font = PixelFont;
            this.labelEndGame.Font = PixelFont;
            this.labelEndGame.Visible = false;
        }

        /// <summary>
        /// Event handlers for spaceship moves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpaceWars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                spaceship.LastY = spaceship.Y;
                spaceship.Y -= spaceship.MoveValue;
                Invalidate();
            } else if (e.KeyCode == Keys.S)
            {
                spaceship.LastY = spaceship.Y;
                spaceship.Y += spaceship.MoveValue;
                Invalidate();
            } else if (e.KeyCode == Keys.A)
            {
                spaceship.LastX = spaceship.X;
                spaceship.X -= spaceship.MoveValue;
                Invalidate();
            } else if (e.KeyCode == Keys.D)
            {
                spaceship.LastX = spaceship.X;
                spaceship.X += spaceship.MoveValue;
                Invalidate();
            } else if (e.KeyCode == Keys.Space)
            {
                gameStopped = !gameStopped;
                if(gameStopped)
                {
                    StopGame();
                } else
                {
                    ResumeGame();
                }
            }
           
        }

        /// <summary>
        /// Viewport refreshing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpaceWars_Paint(object sender, PaintEventArgs e)
        {
            RedrawStars(e);
            RedrawAsteroids(e);
            spaceship.Draw(e);
        }

        /// <summary>
        /// Redraw all stars by their current position
        /// </summary>
        /// <param name="e"></param>
        private void RedrawStars(PaintEventArgs e)
        {
            foreach(Star star in starList)
            {
                star.Draw(e);
            }
        }

        private void InitNewStars()
        {
            for (int i = 0; i < starsAmount; i++)
                starList.Add(new Star(rndGen, this));
        }

        /// <summary>
        /// Update all stars in axis Y position (axis X position is totally random)
        /// </summary>
        private void UpdateStars()
        {
            foreach (Star star in starList)
            {
                star.Y += star.Speed;
                if (star.Y >= this.Width)
                {
                    star.Y = 0;
                    star.X = rndGen.Next(-(int)Math.Floor((double)this.Size.Width), (int)Math.Floor((double)this.Size.Width));
                }
                    
                Invalidate();
            }
        }

        /// <summary>
        ///  Redraw all asteroids by their current position
        /// </summary>
        /// <param name="e"></param>
        private void RedrawAsteroids(PaintEventArgs e)
        {
            foreach(Asteroid asteroid in asteroidInRoundList)
            {
                asteroid.Draw(e);
            }
        }

        private void InitNewAsteroids()
        {
            for (int i = 0; i < asteroidsInRound; i++)
                asteroidInRoundList.Add(new Asteroid(rndGen, this));
        }

        /// <summary>
        /// Update all asteroids in axis Y position(axis X position is totally random) and detecting collision (if collision was detected then restart the game)
        /// </summary>
        private void UpdateAsteroids()
        {
            foreach(Asteroid asteroid in asteroidInRoundList)
            {
                for(int i = 0; i < asteroid.AmountOfVertex; i++)
                {
                    asteroid.AsteroidPoints[i].Y += asteroid.Speed;

                    if (asteroid.AsteroidPoints[i].Y >= this.Width)
                    {
                        asteroidInRoundList.Remove(asteroid);
                        return;
                    }
                    if(DetectCollision(asteroid, i))
                        return;
                }
            }
            if (asteroidInRoundList.Count() == 0)
                InitNewAsteroids();

            Invalidate();
        }

        private bool DetectCollision(Asteroid asteroid, int asteroidVertex)
        {
            if ((asteroid.AsteroidPoints[asteroidVertex].X < spaceship.X + spaceship.CurrentImg.Width / 5) && (asteroid.AsteroidPoints[asteroidVertex].X > spaceship.X))
            {
                if ((asteroid.AsteroidPoints[asteroidVertex].Y < spaceship.Y + spaceship.CurrentImg.Height / 5) && (asteroid.AsteroidPoints[asteroidVertex].Y > spaceship.Y))
                {
                    StopGame();

                    System.Threading.Thread.Sleep(100);
                    this.labelTimeValue.Text = "0 s";
                    secondsAlive = 0;
                    spaceship = new Spaceship(this);
                    Restart();
                    return true;
                }
                return false;
            }
            return false;
        }

        private void StopGame()
        {
            engineTimer.Stop();
            starsTimer.Stop();
            gameTimer.Stop();

            //this.KeyDown -= SpaceWars_KeyDown;
        }

        private void ResumeGame()
        {
            engineTimer.Start();
            starsTimer.Start();
            gameTimer.Start();

            //this.KeyDown += SpaceWars_KeyDown;
        }

        /// <summary>
        /// Restart game
        /// </summary>
        private void Restart()
        {
            starList.Clear();
            InitNewStars();
            asteroidInRoundList.Clear();
            InitNewAsteroids();
            //this.Refresh();
            this.KeyDown += SpaceWars_KeyDown;
            engineTimer.Start();
            starsTimer.Start();
            gameTimer.Start();
            this.labelEndGame.Visible = false;
        }

        private void starsTimer_Tick(object sender, EventArgs e)
        {
            UpdateAsteroids();
            UpdateStars();
        }

        private void engineTimer_Tick(object sender, EventArgs e)
        {
            SpaceShipAnim = !SpaceShipAnim;
            if(SpaceShipAnim)
                spaceship.CurrentImg = spaceship.RunImgSecond;
            else
                spaceship.CurrentImg = spaceship.RunImgFirst;
        }

        private void InitCustomFont()
        {
            PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(@"..\..\fonts\04B_03__.TTF");
            PixelFont = new Font(privateFonts.Families[0], 12);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            secondsAlive += 1;
            string timeDoDisplay;
            if (secondsAlive < 60)
                timeDoDisplay = secondsAlive.ToString() + " s";
            else
            {
                int minutes = secondsAlive / 60;
                int seconds = secondsAlive % 60;
                timeDoDisplay = minutes.ToString() + " m " + seconds.ToString() + " s";
            }
            this.labelTimeValue.Text = timeDoDisplay;
        }
    }
}
