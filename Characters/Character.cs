using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RunDoggyRun
{
    public class Character : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D characterPic;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 screenRef;
        private float flip;
        private float scale = 1f;
        private Vector2 origin;
        private Rectangle rect;
        private Vector2 upMove;
        private Vector2 downMove;
        private Vector2 originalPosition;

        public Vector2 Position { get => position; set => position = value; }

        public Character(Game game, SpriteBatch spriteBatch, 
            Texture2D characterPic, Vector2 position, Vector2 speed, 
            Vector2 screenRef) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.characterPic = characterPic;
            this.position = position;
            this.speed = speed;
            this.screenRef = screenRef;

            flip = 0;
            origin = new Vector2(characterPic.Width/2, characterPic.Height/2);
            rect = new Rectangle(0, 0, characterPic.Width, characterPic.Height);
            upMove = new Vector2(0, -6);
            downMove = new Vector2(0, 2);
            originalPosition = position;

        }

        public void DisableChar()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        public void EnableChar()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(characterPic, position, rect, Color.White, flip, origin, scale, SpriteEffects.None, 0.1f);

            spriteBatch.End();
        }

        public Rectangle charBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, characterPic.Width - 30, characterPic.Height);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keys = Keyboard.GetState();

            if (keys.IsKeyDown(Keys.Left))
            {
                position -= speed;
                
                if (position.X  < 0)
                {
                    position.X = 0;
                }

            }

            if (keys.IsKeyDown(Keys.Right))
            {
                position += speed;

                if(position.X > screenRef.X)
                {
                    position.X = screenRef.X;
                }
                
            }

            if (keys.IsKeyDown(Keys.Up))
            {
                position += upMove;
                
            }

            if (position.Y < originalPosition.Y)
            {
                position += downMove;

            }
        }
    }
}
