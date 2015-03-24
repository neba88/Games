/// <summary>
///███████╗██████╗  █████╗  ██████╗███████╗    ██╗███╗   ██╗██╗   ██╗ █████╗ ██████╗ ███████╗██████╗ 
///██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝    ██║████╗  ██║██║   ██║██╔══██╗██╔══██╗██╔════╝██╔══██╗
///███████╗██████╔╝███████║██║     █████╗      ██║██╔██╗ ██║██║   ██║███████║██║  ██║█████╗  ██████╔╝
///╚════██║██╔═══╝ ██╔══██║██║     ██╔══╝      ██║██║╚██╗██║╚██╗ ██╔╝██╔══██║██║  ██║██╔══╝  ██╔══██╗
///███████║██║     ██║  ██║╚██████╗███████╗    ██║██║ ╚████║ ╚████╔╝ ██║  ██║██████╔╝███████╗██║  ██║
///╚══════╝╚═╝     ╚═╝  ╚═╝ ╚═════╝╚══════╝    ╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝                                                                                               
/// By: Nebojša Kalanj 23.3.2015.
/// </summary>
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

namespace SpaceInvadersN
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle[] prviTalas; 
        Rectangle[,] drugiTalas, treciTalas;
        Texture2D alienOne, alienTwo, alienThree, bullet, ship, background;
        Texture2D start, end, win;
        Rectangle rectBullet, rectShip, screen;

        bool startScreen = true, endScreen = false, winScreen = false;

        String bulletvisible = "N";
        String[,] ziviAlieni2, ziviAlieni3;
        String[] ziviAlieni1;
        
        int aliens = 10;
        int red = 2, kolona = 10;
        int red1 = 2, kolona1 = 10;
        int brzina = 3;
        bool smerLevo = false, smerDesno = true;

        Display slova;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 650;
            graphics.ApplyChanges();
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
            Song song = Content.Load<Song>("Soundtrack");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            
            start = Content.Load<Texture2D>("start");
            end = Content.Load<Texture2D>("gameOver");
            win = Content.Load<Texture2D>("youWin");

            background = Content.Load<Texture2D>("background");
            screen = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            slova = new Display();
            slova.Font = Content.Load<SpriteFont>("Segoe");
            
            ziviAlieni1 = new String[aliens];
            ziviAlieni2 = new String[red, kolona];
            ziviAlieni3 = new String[red1, kolona1];
            
            alienOne = Content.Load<Texture2D>("alienOne");
            prviTalas = new Rectangle[aliens];
            for (int i = 0; i < aliens; i++)
            {
                prviTalas[i].Width = alienOne.Width;
                prviTalas[i].Height = alienOne.Height;
                prviTalas[i].X = 60 * i;
                prviTalas[i].Y = 30;
                ziviAlieni1[i] = "Y";

            }
            alienTwo = Content.Load<Texture2D>("alienTwo");
            drugiTalas = new Rectangle[red, kolona];
            for (int r = 0; r < red; r++)
                for (int k = 0; k < kolona; k++)
                {
                    drugiTalas[r, k].Width = alienTwo.Width;
                    drugiTalas[r, k].Height = alienTwo.Height;
                    drugiTalas[r, k].X = 60 * k;
                    drugiTalas[r, k].Y = (60 * r) + 90;
                    ziviAlieni2[r, k] = "Y";
                }
            alienThree = Content.Load<Texture2D>("alienThree");
            treciTalas = new Rectangle[red1, kolona1];
            for (int r = 0; r < red1; r++)
                for (int k = 0; k < kolona1; k++)
                {
                    treciTalas[r, k].Width = alienThree.Width;
                    treciTalas[r, k].Height = alienThree.Height;
                    treciTalas[r, k].X = 60 * k;
                    treciTalas[r, k].Y = (60 * r) + 210;
                    ziviAlieni3[r, k] = "Y";
                }
            

            ship = Content.Load<Texture2D>("ship");
            rectShip.Width = ship.Width;
            rectShip.Height = ship.Height;
            rectShip.X = GraphicsDevice.Viewport.Width / 2 - 35;
            rectShip.Y = 610;

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
             KeyboardState keys = Keyboard.GetState();

            if (keys.IsKeyDown(Keys.Escape))
                this.Exit();

            if (startScreen == true)
            {
                if (keys.IsKeyDown(Keys.Enter))
                {
                    startScreen = false;
                }
            }

            if (endScreen == true)
            {
                if (keys.IsKeyDown(Keys.Enter))
                {
                    startScreen = true;
                    endScreen = false;
                }
                if (keys.IsKeyDown(Keys.Escape))
                    this.Exit();
            }

            if (winScreen == true)
            {
                if (keys.IsKeyDown(Keys.Escape))
                    this.Exit();
            }
            if (startScreen == false && endScreen == false && winScreen == false)
            {
                int rightside = graphics.GraphicsDevice.Viewport.Width;
                int leftside = 0;

                // pomeranje ship-a
                if (keys.IsKeyDown(Keys.Left) && rectShip.X
                >= 0)
                {
                    rectShip.X = rectShip.X - 3;
                }
                if (keys.IsKeyDown(Keys.Right) && rectShip.X <
                ((graphics.GraphicsDevice.Viewport.Width) - (ship.Width)))
                {
                    rectShip.X = rectShip.X + 3;
                }
                if (keys.IsKeyDown(Keys.Space) && bulletvisible.Equals("N"))
                {
                    bulletvisible = "Y";
                    rectBullet.X = rectShip.X + (rectShip.Width / 2) - (rectBullet.Width / 2);
                    rectBullet.Y = rectShip.Y - rectBullet.Height;
                }

                // pomeranje bullet-a
                if (bulletvisible.Equals("Y"))
                    rectBullet.Y = rectBullet.Y - 6;

                // ako bullet ode iznad aliena tj ekrana
                if (rectBullet.Y + rectBullet.Height < 0)
                    bulletvisible = "N";

                // bullet coalision
                if (bulletvisible.Equals("Y"))
                    for (int i = 0; i < aliens; i++)
                    {
                        if (ziviAlieni1[i].Equals("Y"))
                        {
                            if (rectBullet.Intersects(prviTalas[i]))
                            {
                                bulletvisible = "N";
                                ziviAlieni1[i] = "N";
                                slova.Score += 50;
                            }
                        }
                    }
                if (bulletvisible.Equals("Y"))
                    for (int r = 0; r < red; r++)
                        for (int k = 0; k < kolona; k++)
                        {
                            if (ziviAlieni2[r, k].Equals("Y"))
                            {
                                if (rectBullet.Intersects(drugiTalas[r, k]))
                                {
                                    bulletvisible = "N";
                                    ziviAlieni2[r, k] = "N";
                                    slova.Score += 30;
                                }

                            }

                        }
                if (bulletvisible.Equals("Y"))
                    for (int r = 0; r < red1; r++)
                        for (int k = 0; k < kolona1; k++)
                        {
                            if (ziviAlieni3[r, k].Equals("Y"))
                            {
                                if (rectBullet.Intersects(treciTalas[r, k]))
                                {
                                    bulletvisible = "N";
                                    ziviAlieni3[r, k] = "N";
                                    slova.Score += 10;
                                }
                            }
                        }


                // pomeranje alien-a(prviTalas)
                for (int i = 0; i < aliens; i++)
                {
                    if (smerDesno == true)
                    {
                        prviTalas[i].X = prviTalas[i].X + brzina;
                    }
                    if (smerLevo == true)
                    {
                        prviTalas[i].X = prviTalas[i].X - brzina;
                    }
                }

                // pomeranje alien-a(drugiTalas)
                for (int r = 0; r < red; r++)
                    for (int k = 0; k < kolona; k++)
                    {
                        if (smerDesno == true)
                        {
                            drugiTalas[r, k].X = drugiTalas[r, k].X + brzina;
                        }
                        if (smerLevo == true)
                        {
                            drugiTalas[r, k].X = drugiTalas[r, k].X - brzina;
                        }
                    }

                // pomeranje alien-a(treciTalas)
                for (int r = 0; r < red1; r++)
                    for (int k = 0; k < kolona1; k++)
                    {
                        if (smerDesno == true)
                        {
                            treciTalas[r, k].X = treciTalas[r, k].X + brzina;
                        }
                        if (smerLevo == true)
                        {
                            treciTalas[r, k].X = treciTalas[r, k].X - brzina;
                        }
                    }
                String korakDole = "N";
                // granice ekrana(prviTalas)
                for (int i = 0; i < aliens; i++)
                {
                    if (prviTalas[i].X + prviTalas[i].Width > rightside)
                    {
                        smerDesno = false;
                        smerLevo = true;
                        korakDole = "D";
                    }
                    if (prviTalas[i].X < leftside)
                    {
                        smerLevo = false;
                        smerDesno = true;
                        korakDole = "D";
                    }
                }
                // granice ekrana(drugiTalas)
                for (int r = 0; r < red; r++)
                    for (int k = 0; k < kolona; k++)
                    {
                        if (drugiTalas[r, k].X + drugiTalas[r, k].Width > rightside)
                        {
                            smerDesno = false;
                            smerLevo = true;
                            korakDole = "D";
                        }
                        if (drugiTalas[r, k].X < leftside)
                        {
                            smerLevo = false;
                            smerDesno = true;
                            korakDole = "D";
                        }
                    }
                // granice ekrana(treciTalas)
                for (int r = 0; r < red1; r++)
                    for (int k = 0; k < kolona1; k++)
                    {
                        if (treciTalas[r, k].X + treciTalas[r, k].Width > rightside)
                        {
                            smerDesno = false;
                            smerLevo = true;
                            korakDole = "D";
                        }
                        if (treciTalas[r, k].X < leftside)
                        {
                            smerLevo = false;
                            smerDesno = true;
                            korakDole = "D";
                        }
                    }
                // posle desno levo, aliens dole

                if (korakDole.Equals("D"))
                {
                    for (int i = 0; i < aliens; i++)
                    {
                        prviTalas[i].Y = prviTalas[i].Y + 3;
                    }
                    for (int r = 0; r < red; r++)
                        for (int k = 0; k < kolona; k++)
                        {
                            drugiTalas[r, k].Y = drugiTalas[r, k].Y + 3;
                        }
                    for (int r = 0; r < red1; r++)
                        for (int k = 0; k < kolona1; k++)
                        {
                            treciTalas[r, k].Y = treciTalas[r, k].Y + 3;
                        }
                }

                int count = 0;
                for (int r = 0; r < red; r++)
                    for (int k = 0; k < kolona; k++)
                    {
                        if (ziviAlieni2[r, k].Equals("Y"))
                            count = count + 1;
                    }

                // ako je polovina mrtva ubrzati ostale
                if (slova.Score == 100)
                    brzina = 4;
                if (slova.Score == 500)
                    brzina = 5;
                if (slova.Score == 1000)
                    brzina = 6;
                
                // pobijem govna i gotova stvar
                if (slova.Score == 1300)
                {
                    winScreen = true;
                    startScreen = false;
                }
                // provera GAMEOVER-a
                // ako je rectInvader prenisko onda je GAMEOVER
                for (int r = 0; r < red1; r++)
                    for (int k = 0; k < kolona1; k++)
                    {
                        if (ziviAlieni3[r, k].Equals("Y"))
                            if (treciTalas[r, k].Y + treciTalas[r, k].Height > rectShip.Y)
                                endScreen = true;
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
                spriteBatch.Draw(background, screen, Color.White);
                slova.DrawScore(spriteBatch);

                // prvi talas
                for (int i = 0; i < aliens; i++)
                    if (ziviAlieni1[i].Equals("Y"))
                        spriteBatch.Draw(alienOne, prviTalas[i], Color.White);

                // drugi talas
                for (int r = 0; r < red; r++)
                    for (int k = 0; k < kolona; k++)
                        if (ziviAlieni2[r, k].Equals("Y"))
                            spriteBatch.Draw(alienTwo, drugiTalas[r, k], Color.White);

                // treci talas
                for (int r = 0; r < red1; r++)
                    for (int k = 0; k < kolona1; k++)
                        if (ziviAlieni3[r, k].Equals("Y"))
                            spriteBatch.Draw(alienThree, treciTalas[r, k], Color.White);

                if (bulletvisible.Equals("Y"))
                    spriteBatch.Draw(bullet, rectBullet, Color.White);
                spriteBatch.Draw(ship, rectShip, Color.White);
            }
            if (winScreen == true)
            {
                spriteBatch.Draw(win, screen, Color.White);
                slova.DrawScoreWin(spriteBatch);
                slova.DrawExit(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
