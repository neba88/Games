using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpaceInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, invader, ship, bullet;
        Texture2D start, end, win;
        bool startScreen = true, endScreen = false, winScreen = false;
        Rectangle rectShip, rectBullet, mainFrame;
        Rectangle screen;
        Rectangle[,] rectInvader;
        String[,] invaderAlive;
        int invaderSpeed = 3;
        int rows = 5;
        int cols = 10;
        String direction = "RIGHT";
        String bulletvisible = "NO";
        HUD hud;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.AllowUserResizing = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Background music
            Song song = Content.Load<Song>("song");  
            MediaPlayer.Play(song);

            hud = new HUD();
            hud.Font = Content.Load<SpriteFont>("Segoe UI Mono");
            

            end = Content.Load<Texture2D>("gameOver");
            start = Content.Load<Texture2D>("start");
            win = Content.Load<Texture2D>("youWin");
            screen = new Rectangle(0,0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            background = Content.Load<Texture2D>("background");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            invader = Content.Load<Texture2D>("invader");
            rectInvader = new Rectangle[rows, cols];
            invaderAlive = new String[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    rectInvader[r, c].Width = invader.Width;
                    rectInvader[r, c].Height = invader.Height;
                    rectInvader[r, c].X = 60 * c;
                    rectInvader[r, c].Y = 60 * r;
                    invaderAlive[r, c] = "YES";
                }
            ship = Content.Load<Texture2D>("ship");
            rectShip.Width = ship.Width;
            rectShip.Height = ship.Height;
            rectShip.X = GraphicsDevice.Viewport.Width / 2 - ship.Width;
            rectShip.Y = 425;

            bullet = Content.Load<Texture2D>("bullet");
            rectBullet.Width = bullet.Width;
            rectBullet.Height = bullet.Height;
            rectBullet.X = 0;
            rectBullet.Y = 0;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState CurrentKeyboardState = Keyboard.GetState();

            // Allows the game to exit
            if (CurrentKeyboardState.IsKeyDown(Keys.Escape))
                this.Exit();

            if (startScreen == true)
            {
                if (CurrentKeyboardState.IsKeyDown(Keys.Enter))
                {
                    startScreen = false;
                }
            }

            if (endScreen == true)
            {
                if (CurrentKeyboardState.IsKeyDown(Keys.Enter))
                {
                    startScreen = true;
                    endScreen = false;
                }
                if (CurrentKeyboardState.IsKeyDown(Keys.Escape))
                    this.Exit();
            }

            if (winScreen == true)
            {
                //if (CurrentKeyboardState.IsKeyDown(Keys.Enter))
                //{
                //    startScreen = true;
                //    winScreen = false;
                    
                //}
                if (CurrentKeyboardState.IsKeyDown(Keys.Escape))
                    this.Exit();
            }

            if (startScreen == false && endScreen == false && winScreen == false)
            {

                int rightside = graphics.GraphicsDevice.Viewport.Width;
                int leftside = 0;

                // moving aliens
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                    {
                        if (direction.Equals("RIGHT"))
                            rectInvader[r, c].X = rectInvader[r, c].X + invaderSpeed;
                        if (direction.Equals("LEFT"))
                            rectInvader[r, c].X = rectInvader[r, c].X - invaderSpeed;
                    }

                // check boundaries of screen
                String changeDirection = "N";
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                    {
                        if (invaderAlive[r, c].Equals("YES"))
                        {
                            if (rectInvader[r, c].X + rectInvader[r, c].Width > rightside)
                            {
                                direction = "LEFT";
                                changeDirection = "Y";
                            }
                            if (rectInvader[r, c].X < leftside)
                            {
                                direction = "RIGHT";
                                changeDirection = "Y";
                            }
                        }
                    }
                // posle desno levo, aliens dole
                if (changeDirection.Equals("Y"))
                {
                    for (int r = 0; r < rows; r++)
                        for (int c = 0; c < cols; c++)
                            rectInvader[r, c].Y = rectInvader[r, c].Y + 3;
                }

                // pomeranje ship-a
                if (CurrentKeyboardState.IsKeyDown(Keys.Left))
                    rectShip.X = rectShip.X - 3;
                if (CurrentKeyboardState.IsKeyDown(Keys.Right))
                    rectShip.X = rectShip.X + 3;
                if (CurrentKeyboardState.IsKeyDown(Keys.Space) && bulletvisible.Equals("NO"))
                {
                    bulletvisible = "YES";
                    rectBullet.X = rectShip.X + (rectShip.Width / 2) - (rectBullet.Width / 2);
                    rectBullet.Y = rectShip.Y - rectBullet.Height;
                }

                // move bullet
                if (bulletvisible.Equals("YES"))
                    rectBullet.Y = rectBullet.Y - 6;

                // bullet coalision
                if (bulletvisible.Equals("YES"))
                    for (int r = 0; r < rows; r++)
                        for (int c = 0; c < cols; c++)
                        {
                            if (invaderAlive[r, c].Equals("YES"))
                                if (rectBullet.Intersects(rectInvader[r, c]))
                                {
                                    bulletvisible = "NO";
                                    invaderAlive[r, c] = "NO";
                                    hud.Score += 10;
                                }
                        }

                // ako bullet ode iznad aliena tj ekrana
                if (rectBullet.Y + rectBullet.Height < 0)
                    bulletvisible = "NO";

                int count = 0;
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                        if (invaderAlive[r, c].Equals("YES"))
                            count = count + 1;

                // ako je polovina mrtva ubrzati ostale
                if (rows * cols / 2 == count)
                    invaderSpeed = 5;

                // provera GAMEOVER-a
                // ako je rectInvader prenisko onda je GAMEOVER
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                    {
                        if (invaderAlive[r, c].Equals("YES"))
                            if (rectInvader[r, c].Y + rectInvader[r, c].Height > rectShip.Y)
                                endScreen = true;
                    }

                // pobijem govna i gotova stvar
                if (rows * cols - 50 == count)
                {
                    winScreen = true;
                }
                    
            }
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            if (startScreen == true)
            {
                spriteBatch.Draw(start, screen, Color.White);
            }
            if (endScreen == true)
            {
                spriteBatch.Draw(end, screen, Color.White);
            }
            
            if (startScreen == false && endScreen == false)
            {
                spriteBatch.Draw(background, mainFrame, Color.White);
                // Draw Score and lives..
                hud.DrawScore(spriteBatch);
                hud.DrawLives(spriteBatch);

                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                        if (invaderAlive[r, c].Equals("YES"))
                            spriteBatch.Draw(invader, rectInvader[r, c], Color.White);
                spriteBatch.Draw(ship, rectShip, Color.White);
                if (bulletvisible.Equals("YES"))
                    spriteBatch.Draw(bullet, rectBullet, Color.White);
                if (winScreen == true)
                {
                    spriteBatch.Draw(win, screen, Color.White);
                    hud.DrawScoreWin(spriteBatch);
                    hud.DrawExit(spriteBatch);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
