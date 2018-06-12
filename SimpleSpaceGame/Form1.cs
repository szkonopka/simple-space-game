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
   
    public struct Directions
    {
        public bool right;
        public bool left;
        public bool up;
        public bool down;
        public bool shoot;
    }

    public partial class SpaceWars : Form
    {
        // Database context
        // private DataScoreBoardDataContext ctx;

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

        private System.Threading.Timer starsUpdatingTimer;
        private System.Threading.Timer spaceshipUpdatingTimer;
        private System.Threading.Timer asteroidUpdatingTimer;
        public Directions dir = new Directions();

        float Bonus = 10;
        int CurrentPoints = 0;
        float Multiplier = 1.0f;
        int MultiplierUpgrade = 1000;
        int MultiplierCounter = 0;

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

            
            dir.right = false;
            dir.left = false;
            dir.up = false;
            dir.down = false;
            this.hpBar.Value = spaceship.CurrentHP;
            starsTimer.Start();
            //engineTimer.Start();
            //gameTimer.Start();
            

            starsUpdatingTimer = new System.Threading.Timer(new TimerCallback(this.UpdateStars), null, 0, 10);
            spaceshipUpdatingTimer = new System.Threading.Timer(new TimerCallback(this.updateSpaceship), null, 10, 10000);
            //asteroidUpdatingTimer = new System.Threading.Timer(new TimerCallback(this.UpdateAsteroids), null, 0, 10);
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
            this.labelTimeValue.Font = PixelFont;
            this.labelEndGame.Font = PixelFont;
            this.labelEndGame.Visible = false;
            this.labelWeaponState.Font = PixelFont;
        }

        private void SpaceWars_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) dir.up = false;

            if (e.KeyCode == Keys.S) dir.down = false;

            if (e.KeyCode == Keys.A) dir.left = false;

            if (e.KeyCode == Keys.D) dir.right = false;

            if (e.KeyCode == Keys.Space) dir.shoot = false;
        }

        /// <summary>
        /// Event handlers for spaceship moves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpaceWars_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W) dir.up = true;

            if (e.KeyCode == Keys.S) dir.down = true;

            if (e.KeyCode == Keys.A) dir.left = true;

            if (e.KeyCode == Keys.D) dir.right = true;

            if (e.KeyCode == Keys.Space) dir.shoot = true;

            /*
            if (e.KeyCode == Keys.Space)
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
            Invalidate();
            */

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
            spaceship.Draw(e, dir);
            spaceship.MoveBullets();
            this.labelWeaponState.Text = this.spaceship.CurrentWeaponState;
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
        private void UpdateStars(object StateObj)
        {
            foreach (Star star in starList)
            {
                star.Y += star.MoveValue;
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
        private void UpdateAsteroids(object StateObj)
        {
            bool leave = false;
            foreach(Asteroid asteroid in asteroidInRoundList)
            {   
                for(int i = 0; i < asteroid.AmountOfVertex; i++)
                {
                    asteroid.AsteroidPoints[i].Y += asteroid.MoveValue;

                    foreach (var bullet in this.spaceship.Bullets)
                    {
                        if (DetectBulletsCollision(asteroid, bullet, i))
                        {
                            //this.spaceship.Bullets.Remove(bullet);
                            Bonus = 100 * Multiplier;
                            leave = true;
                            break;
                        }
                    }

                    if (asteroid.AsteroidPoints[i].Y >= this.Width)
                    {
                        asteroidInRoundList.Remove(asteroid);
                        leave = true;
                        break;
                    }

                    if (leave) break;

                    if(DetectCollision(asteroid, i))
                    {
                        this.spaceship.CurrentHP -= 25;
                        if(spaceship.CurrentHP <= 0)
                        {
                            this.hpBar.Value = 0;
                            StopGame();
                            this.Visible = false;
                            SaveResult results = new SaveResult(this.CurrentPoints);
                            results.ShowDialog();
                            this.Close();
                            //System.Threading.Thread.Sleep(100);
                            //this.labelTimeValue.Text = "0 s";
                            //secondsAlive = 0;
                            //spaceship = new Spaceship(this);
                            //Restart();

                            leave = true;
                            break;
                        }
                        this.hpBar.Value = spaceship.CurrentHP;
                        leave = true;
                        break;
                    }   
                }
                if (leave) break;
            }
            if (asteroidInRoundList.Count() == 0)
                InitNewAsteroids();

            
            Invalidate();
        }

        private bool DetectBulletsCollision(Asteroid asteroid, Bullet bullet, int asteroidVertex)
        {
            if ((asteroid.AsteroidPoints[asteroidVertex].X < bullet.X + spaceship.CurrentImg.Width / 5) && (asteroid.AsteroidPoints[asteroidVertex].X > bullet.X))
            {
                if ((asteroid.AsteroidPoints[asteroidVertex].Y < bullet.Y + spaceship.CurrentImg.Height / 5) && (asteroid.AsteroidPoints[asteroidVertex].Y > bullet.Y))
                {
                    asteroidInRoundList.Remove(asteroid);
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool DetectCollision(Asteroid asteroid, int asteroidVertex)
        {
            if ((asteroid.AsteroidPoints[asteroidVertex].X < spaceship.X + spaceship.CurrentImg.Width / 5) && (asteroid.AsteroidPoints[asteroidVertex].X > spaceship.X))
            {
                if ((asteroid.AsteroidPoints[asteroidVertex].Y < spaceship.Y + spaceship.CurrentImg.Height / 5) && (asteroid.AsteroidPoints[asteroidVertex].Y > spaceship.Y))
                {
                    asteroidInRoundList.Remove(asteroid);
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
            this.hpBar.Value = this.spaceship.CurrentHP;
        }

        private void starsTimer_Tick(object sender, EventArgs e)
        {
            UpdateAsteroids(null);
            //UpdateStars(null);
        }

        private void updateObjects()
        {
            //UpdateAsteroids();
            //UpdateStars();
            //Thread.Sleep(100);
        }

        private void updateSpaceship(object StateObj)
        {
            SpaceShipAnim = !SpaceShipAnim;
            if (SpaceShipAnim)
                spaceship.CurrentImg = spaceship.RunImgSecond;
            else
                spaceship.CurrentImg = spaceship.RunImgFirst;
            //Thread.Sleep(100);
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
            MultiplierCounter += (int)(10 * Multiplier + Bonus);

            if (MultiplierCounter % MultiplierUpgrade == 0)
            {
                MultiplierCounter = 0;
                Multiplier += 0.1f;
            }

            CurrentPoints += (int) (10 * Multiplier + Bonus);
            Bonus = 0;
            this.labelTimeValue.Text = CurrentPoints.ToString();
        }
    }
}
