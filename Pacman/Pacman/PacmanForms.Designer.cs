using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using Timer = System.Windows.Forms.Timer;
using PacmanLibrary;
using System.Reflection;
using System.Media;


namespace Pacman
{
    partial class PacmanForms
    {
        static readonly Timer PacmanMoving = new Timer();

        static readonly Timer ghostMove = new Timer();

        static readonly Timer startMenu = new Timer();

        static readonly Timer startDeathMenu = new Timer();

        static readonly Timer powerUp = new Timer();

        static readonly Timer deathPenalty = new Timer();

        static readonly Timer pacmanAnimation = new Timer();

        static readonly Timer ghostAnimation = new Timer();

        PacmanP pacman = new PacmanP();

        Ghost[] ghosts = new Ghost[4];

        bool freeMove = false;

        int preMove = 0;

        byte dotsNumber = 0;

        int animationFrame = 0;

        int ghostFrame = 0;

        int currentScore = 0;

        int highScore;

        private SoundPlayer deathSound;
        private SoundPlayer eatbonus;
        private SoundPlayer eatdot;

        Random rnd = new Random();

        Element[,] objectMap = new Element[31, 28];

        Bitmap[] nums = new Bitmap[10];

        byte[,] map = new byte[31, 28] {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },// 1 - стінка, 2 - монетки, 3 - бонус, 0 - пусто
            {1,2,2,2,2,2,2,2,2,2,2,2,2,1,1,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            {1,2,1,1,1,1,2,1,1,1,1,1,2,1,1,2,1,1,1,1,1,2,1,1,1,1,2,1 },
            {1,3,1,1,1,1,2,1,1,1,1,1,2,1,1,2,1,1,1,1,1,2,1,1,1,1,3,1 },
            {1,2,1,1,1,1,2,1,1,1,1,1,2,1,1,2,1,1,1,1,1,2,1,1,1,1,2,1 },
            {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            {1,2,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,2,1 },
            {1,2,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,2,1 },
            {1,2,2,2,2,2,2,1,1,2,2,2,2,1,1,2,2,2,2,1,1,2,2,2,2,2,2,1 },
            {1,1,1,1,1,1,2,1,1,1,1,1,0,1,1,0,1,1,1,1,1,2,1,1,1,1,1,1 },
            {0,0,0,0,0,1,2,1,1,1,1,1,0,1,1,0,1,1,1,1,1,2,1,0,0,0,0,0 },
            {0,0,0,0,0,1,2,1,1,0,0,0,0,0,0,0,0,0,0,1,1,2,1,0,0,0,0,0 },
            {0,0,0,0,0,1,2,1,1,0,1,1,1,1,1,1,1,1,0,1,1,2,1,0,0,0,0,0 },
            {1,1,1,1,1,1,2,1,1,0,1,0,0,0,0,0,0,1,0,1,1,2,1,1,1,1,1,1 },
            {0,0,0,0,0,0,2,0,0,0,1,0,1,1,1,1,0,1,0,0,0,2,0,0,0,0,0,0 },
            {1,1,1,1,1,1,2,1,1,0,1,0,0,0,0,0,0,1,0,1,1,2,1,1,1,1,1,1 },
            {0,0,0,0,0,1,2,1,1,0,1,1,1,1,1,1,1,1,0,1,1,2,1,0,0,0,0,0 },
            {0,0,0,0,0,1,2,1,1,0,0,0,0,0,0,0,0,0,0,1,1,2,1,0,0,0,0,0 },
            {0,0,0,0,0,1,2,1,1,0,1,1,1,1,1,1,1,1,0,1,1,2,1,0,0,0,0,0 },
            {1,1,1,1,1,1,2,1,1,0,1,1,1,1,1,1,1,1,0,1,1,2,1,1,1,1,1,1 },
            {1,2,2,2,2,2,2,2,2,2,2,2,2,1,1,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            {1,2,1,1,1,1,2,1,1,1,1,1,2,1,1,2,1,1,1,1,1,2,1,1,1,1,2,1 },
            {1,2,1,1,1,1,2,1,1,1,1,1,2,1,1,2,1,1,1,1,1,2,1,1,1,1,2,1 },
            {1,3,2,2,1,1,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,1,1,2,2,3,1 },
            {1,1,1,2,1,1,2,1,1,2,1,1,1,1,1,1,1,1,2,1,1,2,1,1,2,1,1,1 },
            {1,1,1,2,1,1,2,1,1,2,1,1,1,1,1,1,1,1,2,1,1,2,1,1,2,1,1,1 },
            {1,2,2,2,2,2,2,1,1,2,2,2,2,1,1,2,2,2,2,1,1,2,2,2,2,2,2,1 },
            {1,2,1,1,1,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,1,1,1,2,1 },
            {1,2,1,1,1,1,1,1,1,1,1,1,2,1,1,2,1,1,1,1,1,1,1,1,1,1,2,1 },
            {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        };
        public class MapCollisionHandler
        {
            private const int Obstacle = 1;
            private const int CollisionRadius = 16;

            public bool MapColl(MovingPoint entity)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == Obstacle && IsCollision(entity, i, j))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            private bool IsCollision(MovingPoint entity, int x, int y)
            {
                return entity.CheckCollision(objectMap[x, y].X, objectMap[x, y].Y, CollisionRadius);
            }
        }

        public bool MapColl(MovingPoint entity, int dx, int dy)
        {

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                    {
                        if (entity.CheckCollision(objectMap[i, j].X, objectMap[i, j].Y, dx, dy) == true)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        bool gameOverProcessed = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush dotBrush = new SolidBrush(Color.Yellow);

            string score = currentScore.ToString();
            char[] chScore = score.ToCharArray();

            for (int i = 0; i < chScore.Length; i++)
            {
                e.Graphics.DrawImage(nums[(int)char.GetNumericValue(chScore[i])], 150 + 12 * i, 60);
            }

            score = highScore.ToString();
            chScore = score.ToCharArray();

            for (int i = 0; i < chScore.Length; i++)
            {
                e.Graphics.DrawImage(nums[(int)char.GetNumericValue(chScore[i])], 250 + 12 * i, 60);
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 2)
                    {
                        e.Graphics.FillEllipse(dotBrush, objectMap[i, j].X + 35, objectMap[i, j].Y + 93, 6, 6);
                    }

                    if (map[i, j] == 3)
                    {
                        e.Graphics.FillEllipse(dotBrush, objectMap[i, j].X + 32, objectMap[i, j].Y + 90, 12, 12);
                    }
                }
            }

            e.Graphics.DrawImage(pacman.Sprite, pacman.X + 27, pacman.Y + 82);

            for (int i = 0; i < ghosts.Length; i++)
            {
                e.Graphics.DrawImage(ghosts[i].Sprite, ghosts[i].X + 27, ghosts[i].Y + 82);
            }

            e.Graphics.DrawImage(Properties.Resources.result, 100, 20, 250, 25);

            for (int i = 0; i < pacman.Lives; i++)
            {
                e.Graphics.DrawImage(Properties.Resources.live, 35 + 27 * i, 680, 25, 25);
            }

            if (pacman.Lives < 0 && !gameOverProcessed)
            {
                gameOverProcessed = true;

                if (currentScore > highScore)
                {
                    highScore = currentScore;
                    Properties.Settings.Default.HighScore = highScore;
                    Properties.Settings.Default.Save();
                }

                GameOverForm gameOverForm = new GameOverForm(currentScore, highScore);
                gameOverForm.ShowDialog();

                currentScore = 0;
            }

            if (showBonusText)
            {
                using (Font font = new Font("Arial", 14, FontStyle.Bold))
                {
                    e.Graphics.DrawString(bonusText, font, Brushes.Red, bonusTextLocation);
                }
            }
        }


        private void PowerUp(object sender, EventArgs e)
        {
            pacman.IsPowered = false;
        }

        private Timer bonusTextTimer;
        private string bonusText;
        private Point bonusTextLocation;
        private bool showBonusText; 


        private void DeathPenalty(object sender, EventArgs e)
        {
            int target = -1;

            for (int i = 0; i < ghosts.Length; i++)
            {
                if (ghosts[i].IsDead == true)
                {
                    
                    target = i;
                    currentScore += 200;

                }
            }

            if (target >= 0)
            {
                ghosts[target].Respawn();
            }
            else
            {
                deathPenalty.Stop();
            }
        }

        private void StartMenu(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Keys.Up) || Keyboard.IsKeyDown(Keys.Down) || Keyboard.IsKeyDown(Keys.Left) || Keyboard.IsKeyDown(Keys.Right))
            {
                startMenu.Stop();
                ghostMove.Start();
                PacmanMoving.Start();
                pacmanAnimation.Start();
                ghostAnimation.Start();
                this.Invalidate();
            }
            this.Invalidate();
        }

        private void StartDeathMenu(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Keys.Up)|| Keyboard.IsKeyDown(Keys.Down)|| Keyboard.IsKeyDown(Keys.Left)|| Keyboard.IsKeyDown(Keys.Right))
            {
                pacman.Lives = 3;

                currentScore = 0;

                ResetGame();

                startDeathMenu.Stop();

                startMenu.Start();

                this.Invalidate();
            }
            this.Invalidate();

        }

        private void GhostTick(object sender, EventArgs e)
        {
            foreach (var ghost in ghosts)
            {
                GhostMove(ghost);
            }
        }

        private void PacmanTick(object sender, EventArgs e)
        {

            if (Keyboard.IsKeyDown(Keys.Up))
            {
                preMove = 1;
            }
            if (Keyboard.IsKeyDown(Keys.Down))
            {
                preMove = 2;
            }
            if (Keyboard.IsKeyDown(Keys.Left))
            {
                preMove = 3;
            }
            if (Keyboard.IsKeyDown(Keys.Right))
            {
                preMove = 4;
            }

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                ghostMove.Stop();
                PacmanMoving.Stop();
                this.Invalidate();
            }

            switch (preMove)
            {
                case 0:
                    if (MapColl(pacman))
                    {
                        pacman.Move();
                    }
                    break;

                case 1:
                    MoveGen(0, -1);
                    break;

                case 2:
                    MoveGen(0, 1);
                    break;

                case 3:
                    MoveGen(-1, 0);
                    break;

                case 4:
                    MoveGen(1, 0);
                    break;
            }

            PacmanEat();

            if (dotsNumber == 0)
            {
                ResetGame();
            }

            this.Invalidate();
        }
        public void PacmanEat()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 2)
                    {
                        if (pacman.CheckCollision(objectMap[i, j].X + 4, objectMap[i, j].Y + 4, 8) == true)
                        {
                            map[i, j] = 4;
                            objectMap[i, j] = new Element(j, i);
                            dotsNumber--;
                            currentScore += 10;
                            eatdot.Play();

                        }
                    }

                    if (map[i, j] == 3)
                        if (pacman.CheckCollision(objectMap[i, j].X + 4, objectMap[i, j].Y + 4, 8) == true)
                        {
                            map[i, j] = 5;
                            objectMap[i, j] = new Element(j, i);
                            currentScore += 100;
                            eatbonus.Play();
                            powerUp.Stop();

                            pacman.IsPowered = true;

                            powerUp.Start();
                        }

                }
            }

            foreach (var ghost in ghosts)
            {
                if (pacman.CheckCollision(ghost.X, ghost.Y, 15) == true)
                {
                    if (pacman.IsPowered == false)
                    {
                        Reset();
                    }
                    else
                    {
                        Reset(ghost);
                    }
                }
            }
        }
        public void Reset()
        {
            System.Threading.Thread.Sleep(1000);
            
            foreach (var ghost in ghosts)
            {
                ghost.Respawn();
            }

            pacman.Die();

            if (pacman.Lives < 0)
            {
                if (currentScore > highScore)
                {
                    Properties.Settings.Default.HighScore = currentScore;
                    highScore = currentScore;
                    Properties.Settings.Default.Save();
                }
                ghostMove.Stop();
                PacmanMoving.Stop();
                startDeathMenu.Start();
                this.Invalidate();
            }
        }
        
        public void Reset(Ghost ghost)
        {

            currentScore += 200;

            ghost.X = 216;
            ghost.Y = 256;
            ghost.IsDead = true;
            for (int i = 0; i < ghosts.Length; i++)
            {
                if (ghosts[i].IsDead == true)
                {
                    deathSound.Play();
                    bonusTextTimer.Start();
                    bonusText = "+200";
                    bonusTextLocation = new Point(190, 55);
                    showBonusText = true;

                }
            }
            deathPenalty.Start();

        }

        public void GhostMove(MovingPoint entity)
        {
            freeMove = true;

            if (MapColl(entity) && !(MapColl(entity, entity.DirectionY, entity.DirectionX) || MapColl(entity, -entity.DirectionY, -entity.DirectionX)))
            {
                entity.Move();
            }
            else
            {
                freeMove = true;

                if (rnd.Next(0, 2) == 1)
                {
                    if (entity.DirectionX == 0)
                    {
                        entity.ChangeDirection(1, 0);

                        if (entity.X > pacman.X)
                        {
                            entity.ChangeDirection(-1, 0);
                        }

                        if (pacman.IsPowered == true)
                        {
                            entity.ChangeDirection(-entity.DirectionX, 0);
                        }

                        if (!MapColl(entity))
                        {
                            entity.ChangeDirection(entity.DirectionX * -1, 0);
                        }

                        entity.Move();

                    }
                    else
                    {
                        entity.ChangeDirection(0, 1);

                        if (entity.Y > pacman.Y)
                        {
                            entity.ChangeDirection(0, -1);
                        }

                        if (pacman.IsPowered == true)
                        {
                            entity.ChangeDirection(0, -entity.DirectionY);
                        }

                        if (!MapColl(entity))
                        {
                            entity.ChangeDirection(0, entity.DirectionY * -1);
                        }

                        entity.Move();
                    }
                }

                else if (MapColl(entity))
                {
                    entity.Move();
                }
            }

        }
        public void MoveGen(int dx, int dy)
        {
            if (!MapColl(pacman, dx, dy))
            {
                freeMove = false;
            }

            if (freeMove == true)
            {
                pacman.ChangeDirection(dx, dy);
                pacman.Move();
                preMove = 0;
            }
            else if (MapColl(pacman))
            {
                pacman.Move();
            }
        }



        public static class Keyboard
        {
            private static readonly HashSet<Keys> keys = new HashSet<Keys>();

            public static void OnKeyDown(object sender, KeyEventArgs e)
            {
                if (keys.Contains(e.KeyCode) == false)
                {
                    keys.Add(e.KeyCode);
                }
            }

            public static void OnKeyUp(object sender, KeyEventArgs e)
            {
                if (keys.Contains(e.KeyCode))
                {
                    keys.Remove(e.KeyCode);
                }
            }

            public static bool IsKeyDown(Keys key)
            {
                return keys.Contains(key);
            }
        }

        private void PacmanAnimation(object sender, EventArgs e)
        {
            switch (animationFrame)
            {
                case 0:
                    if (pacman.DirectionX == 1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanRight1);
                    }
                    if (pacman.DirectionX == -1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanLeft1);
                    }
                    if (pacman.DirectionY == 1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanDown1);
                    }
                    if (pacman.DirectionY == -1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanUp1);
                    }

                    animationFrame++;
                    break;

                case 1:
                    if (pacman.DirectionX == 1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanRight2);
                    }
                    if (pacman.DirectionX == -1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanLeft2);
                    }
                    if (pacman.DirectionY == 1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanDown2);
                    }
                    if (pacman.DirectionY == -1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanUp2);
                    }

                    animationFrame++;
                    break;

                case 2:
                    if (pacman.DirectionX == 1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanRight1);
                    }
                    if (pacman.DirectionX == -1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanLeft1);
                    }
                    if (pacman.DirectionY == 1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanDown1);
                    }
                    if (pacman.DirectionY == -1)
                    {
                        pacman.Sprite = new Bitmap(Properties.Resources.PacmanUp1);
                    }

                    animationFrame++;
                    break;

                case 3:
                    pacman.Sprite = new Bitmap(Properties.Resources.Pacman);
                    animationFrame = 0;
                    break;

            }

        }

        private void GhostAnimation(object sender, EventArgs e)
        {
            switch (ghostFrame)
            {
                case 0:

                    if (pacman.IsPowered == true)
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            ghosts[i].Sprite = new Bitmap(Properties.Resources.Ghost1);
                        }
                    }
                    else
                    {
                        if (ghosts[0].DirectionX == 1)
                        {
                            ghosts[0].Sprite = new Bitmap(Properties.Resources.PinkyRight1);
                        }
                        if (ghosts[0].DirectionX == -1)
                        {
                            ghosts[0].Sprite = new Bitmap(Properties.Resources.PinkyLeft1);
                        }
                        if (ghosts[0].DirectionY == 1)
                        {
                            ghosts[0].Sprite = new Bitmap(Properties.Resources.PinkyDown1);
                        }
                        if (ghosts[0].DirectionY == -1)
                        {
                            ghosts[0].Sprite = new Bitmap(Properties.Resources.PinkyUp1);
                        }
                        if (ghosts[1].DirectionX == 1)
                        {
                            ghosts[1].Sprite = new Bitmap(Properties.Resources.BlinkyRight1);
                        }
                        if (ghosts[1].DirectionX == -1)
                        {
                            ghosts[1].Sprite = new Bitmap(Properties.Resources.BlinkyLeft1);
                        }
                        if (ghosts[1].DirectionY == 1)
                        {
                            ghosts[1].Sprite = new Bitmap(Properties.Resources.BlinkyDown1);
                        }
                        if (ghosts[1].DirectionY == -1)
                        {
                            ghosts[1].Sprite = new Bitmap(Properties.Resources.BlinkyUp1);
                        }

                        if (ghosts[2].DirectionX == 1)
                        {
                            ghosts[2].Sprite = new Bitmap(Properties.Resources.InkyRight1);
                        }
                        if (ghosts[2].DirectionX == -1)
                        {
                            ghosts[2].Sprite = new Bitmap(Properties.Resources.InkyLeft1);
                        }
                        if (ghosts[2].DirectionY == 1)
                        {
                            ghosts[2].Sprite = new Bitmap(Properties.Resources.InkyDown1);
                        }
                        if (ghosts[2].DirectionY == -1)
                        {
                            ghosts[2].Sprite = new Bitmap(Properties.Resources.InkyUp1);
                        }

                        if (ghosts[3].DirectionX == 1)
                        {
                            ghosts[3].Sprite = new Bitmap(Properties.Resources.ClydeRight1);
                        }
                        if (ghosts[3].DirectionX == -1)
                        {
                            ghosts[3].Sprite = new Bitmap(Properties.Resources.ClydeLeft1);
                        }
                        if (ghosts[3].DirectionY == 1)
                        {
                            ghosts[3].Sprite = new Bitmap(Properties.Resources.ClydeDown1);
                        }
                        if (ghosts[3].DirectionY == -1)
                        {
                            ghosts[3].Sprite = new Bitmap(Properties.Resources.ClydeUp1);
                        }
                    }
                    ghostFrame++;
                    break;

                case 1:

                    if (pacman.IsPowered == true)
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            ghosts[i].Sprite = new Bitmap(Properties.Resources.Ghost2);
                        }
                    }
                    else
                    {
                        if (ghosts[0].DirectionX == 1)
                        {
                            ghosts[0].Sprite = new Bitmap(Properties.Resources.PinkyRight2);
                        }
                        if (ghosts[0].DirectionX == -1)
                        {
                            ghosts[0].Sprite = new Bitmap(Properties.Resources.PinkyLeft2);
                        }
                        if (ghosts[0].DirectionY == 1)
                        {
                            ghosts[0].Sprite = new Bitmap(Properties.Resources.PinkyDown2);
                        }
                        if (ghosts[0].DirectionY == -1)
                        {
                            ghosts[0].Sprite = new Bitmap(Properties.Resources.PinkyUp2);
                        }

                        if (ghosts[1].DirectionX == 1)
                        {
                            ghosts[1].Sprite = new Bitmap(Properties.Resources.BlinkyRight2);
                        }
                        if (ghosts[1].DirectionX == -1)
                        {
                            ghosts[1].Sprite = new Bitmap(Properties.Resources.BlinkyLeft2);
                        }
                        if (ghosts[1].DirectionY == 1)
                        {
                            ghosts[1].Sprite = new Bitmap(Properties.Resources.BlinkyDown2);
                        }
                        if (ghosts[1].DirectionY == -1)
                        {
                            ghosts[1].Sprite = new Bitmap(Properties.Resources.BlinkyUp2);
                        }

                        if (ghosts[2].DirectionX == 1)
                        {
                            ghosts[2].Sprite = new Bitmap(Properties.Resources.InkyRight2);
                        }
                        if (ghosts[2].DirectionX == -1)
                        {
                            ghosts[2].Sprite = new Bitmap(Properties.Resources.InkyLeft2);
                        }
                        if (ghosts[2].DirectionY == 1)
                        {
                            ghosts[2].Sprite = new Bitmap(Properties.Resources.InkyDown2);
                        }
                        if (ghosts[2].DirectionY == -1)
                        {
                            ghosts[2].Sprite = new Bitmap(Properties.Resources.InkyUp2);
                        }

                        if (ghosts[3].DirectionX == 1)
                        {
                            ghosts[3].Sprite = new Bitmap(Properties.Resources.ClydeRight2);
                        }
                        if (ghosts[3].DirectionX == -1)
                        {
                            ghosts[3].Sprite = new Bitmap(Properties.Resources.ClydeLeft2);
                        }
                        if (ghosts[3].DirectionY == 1)
                        {
                            ghosts[3].Sprite = new Bitmap(Properties.Resources.ClydeDown2);
                        }
                        if (ghosts[3].DirectionY == -1)
                        {
                            ghosts[3].Sprite = new Bitmap(Properties.Resources.ClydeUp2);
                        }
                    }
                    ghostFrame--;
                    break;
            }
        }
        public void ResetGame()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 4)
                    {
                        map[i, j] = 2;
                        objectMap[i, j] = new ScorePoint(j, i + 3);
                        dotsNumber++;
                    }
                    else if (map[i, j] == 5)
                    {
                        map[i, j] = 3;
                        objectMap[i, j] = new Bonus(j, i + 3);
                    }
                }
            }

            foreach (var ghost in ghosts)
            {
                ghost.Respawn();
            }

            pacman.X = 216;
            pacman.Y = 416;

            pacman.ChangeDirection(0, 0);
        }
        private void BonusTextTimer_Tick(object sender, EventArgs e)
        {
            showBonusText = false;
            bonusTextTimer.Stop();
            Invalidate();
        }

        public PacmanForms()
        {
            InitializeComponent();

            DoubleBuffered = true;
            KeyPreview = true;

            deathSound = new SoundPlayer(Properties.Resources.pacman_death);
            eatbonus = new SoundPlayer(Properties.Resources.pacman_eatfruit);
            eatdot = new SoundPlayer(Properties.Resources.pacman_chomp);

            ghosts[0] = new Ghost(192, 224);
            ghosts[1] = new Ghost(208, 224);
            ghosts[2] = new Ghost(224, 224);
            ghosts[3] = new Ghost(240, 224);

            bonusTextTimer = new Timer();
            bonusTextTimer.Interval = 1500;
            bonusTextTimer.Tick += BonusTextTimer_Tick;

            showBonusText = false;

            foreach (var ghost in ghosts)
            {
                ghost.ChangeDirection(1 - 2 * rnd.Next(0, 2), 0);
            }

            rnd = new Random();

            KeyDown += Keyboard.OnKeyDown;
            KeyUp += Keyboard.OnKeyUp;

            highScore = Properties.Settings.Default.HighScore;

            PacmanMoving.Tick += new EventHandler(PacmanTick);
            PacmanMoving.Interval = 1;

            ghostMove.Tick += new EventHandler(GhostTick);
            ghostMove.Interval = 1;

            startMenu.Tick += new EventHandler(StartMenu);
            startMenu.Interval = 1;
            startMenu.Start();

            startDeathMenu.Tick += new EventHandler(StartDeathMenu);
            startDeathMenu.Interval = 1;

            powerUp.Tick += new EventHandler(PowerUp);
            powerUp.Interval = 10000;

            deathPenalty.Tick += new EventHandler(DeathPenalty);
            deathPenalty.Interval = 10000;

            pacmanAnimation.Tick += new EventHandler(PacmanAnimation);
            pacmanAnimation.Interval = 60;

            ghostAnimation.Tick += new EventHandler(GhostAnimation);
            ghostAnimation.Interval = 60;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                    {
                        objectMap[i, j] = new Barrier(j, i + 3);
                    }

                    else if (map[i, j] == 2)
                    {
                        objectMap[i, j] = new ScorePoint(j, i + 3);
                        dotsNumber++;
                    }
                    else if (map[i, j] == 3)
                    {
                        objectMap[i, j] = new Bonus(j, i + 3);
                    }

                    else
                    {
                        objectMap[i, j] = new Element(j, i + 3);
                    }
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject("_" + i);
            }
        }
    }
}

