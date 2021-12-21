using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;


namespace RunDoggyRun
{
    class AboutScene : Scene
    {
        private SpriteBatch spriteBatch;
        private Texture2D aboutPic;

        public AboutScene(Game game) : base(game)
        {
            Game1 thisGame = (Game1)game;

            spriteBatch = thisGame._spriteBatch;
            aboutPic = thisGame.Content.Load<Texture2D>("images/About");

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(aboutPic, Vector2.Zero, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
