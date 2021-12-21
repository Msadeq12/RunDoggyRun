using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RunDoggyRun
{
    class Explosion : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private Vector2 dimension;
        private Texture2D explosionPics;
        private int delay;
        private int delayCounter;
        private List<Rectangle> frames;
        private int frameIndex = -1;

        private const int ROW = 5;
        private const int COLUMN = 5;

        public Explosion(Game game, 
            Vector2 position,
            Texture2D explosionPics,
            SpriteBatch spriteBatch,
            int delay) : base(game)
        {
            this.position = position;
            this.spriteBatch = spriteBatch;
            this.delay = delay;
            this.explosionPics = explosionPics;

            dimension = new Vector2(explosionPics.Width / COLUMN, explosionPics.Height / ROW);
            this.Enabled = false;
            this.Visible = false;

            createFrames();
        }

        public void createFrames()
        {
            frames = new List<Rectangle>();

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COLUMN; j++)
                {
                    int xComponent = j * (int)dimension.X;
                    int yComponent = i * (int)dimension.Y;

                    Rectangle frame = new Rectangle(xComponent, yComponent, (int)dimension.X, (int)dimension.Y);

                    frames.Add(frame);

                }


            }
            
        }

        public void RestartAnimation()
        {
            frameIndex = -1;
            delayCounter = 0;
            this.Enabled = true;
            this.Visible = true;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if(frameIndex >= 0)
            {
                spriteBatch.Draw(explosionPics, position, frames[frameIndex], Color.White);
            }
            

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            int lastFrame = ROW * COLUMN;
            delayCounter++;

            if(delay > delayCounter)
            {
                frameIndex++;

                if(frameIndex > lastFrame - 1)
                {
                    frameIndex = -1;
                    this.Enabled = false;
                    this.Visible = false;

                }

                delayCounter = 0;
            }
            base.Update(gameTime);
        }
    }
}
