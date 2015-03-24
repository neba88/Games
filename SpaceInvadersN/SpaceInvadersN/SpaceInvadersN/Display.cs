using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersN
{
    public class Display
    {
        private Vector2 scorePos = new Vector2(100, 0);
        private Vector2 scorePosWin = new Vector2(300, 600);
        private Vector2 lives = new Vector2(600, 455);
        private Vector2 exit = new Vector2(500, 600);

        public SpriteFont Font
        {
            get;
            set;
        }

        public SpriteFont Font1
        {
            get;
            set;
        } 

        public int Score
        {
            get;
            set;
        }

        public Display()
        {
        }

        public void DrawScore(SpriteBatch spriteBatch)
        {
            // Draw the Score in the top-left of screen
            spriteBatch.DrawString(
                Font,                          // SpriteFont
                "SCORE: " + Score.ToString(),  // Text
                scorePos,                      // Position
                Color.Lime);                   // Tint
        }

        public void DrawLives(SpriteBatch spriteBatch)
        {
            // Draw the Score in the top-left of screen
            spriteBatch.DrawString(
                Font,                           // SpriteFont
                "LIVES: ",                      // Text
                lives,                          // Position
                Color.Lime);                    // Tint
        }

        public void DrawScoreWin(SpriteBatch spriteBatch)
        {
            // Draw the Score in the top-left of screen
            spriteBatch.DrawString(
                Font,                          // SpriteFont
                "SCORE: " + Score.ToString(),  // Text
                scorePosWin,                   // Position
                Color.Lime);                   // Tint
        }

        public void DrawExit(SpriteBatch spriteBatch)
        {
            // Draw the Score in the top-left of screen
            spriteBatch.DrawString(
                Font,                           // SpriteFont
                "Press Escape to exit!",        // Text
                exit,                           // Position
                Color.Lime);                    // Tint
        }

    }
}
