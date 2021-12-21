using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RunDoggyRun
{
    class HelpScene : Scene
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpPic;
        private Rectangle rect;

        public HelpScene(Game game) : base(game)
        {
            Game1 thisGame = (Game1)game;

            spriteBatch = thisGame._spriteBatch;
            helpPic = thisGame.Content.Load<Texture2D>("images/keyboard");
            rect = new Rectangle(0, 0, thisGame._graphics.PreferredBackBufferWidth,
                thisGame._graphics.PreferredBackBufferHeight);
            
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(helpPic, rect, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
