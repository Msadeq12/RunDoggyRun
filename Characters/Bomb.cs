using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using MonoString;

namespace RunDoggyRun
{
    public class Bomb : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D characterPic;
        private Vector2 position;
        private Vector2 originalPosition;
        private Vector2 speed;
        private Vector2 screenRef;
        public Game1 game1;
        private Explosion explode;
        private Texture2D explosion;
        private Vector2 dogPosition;
        private SimpleString message;
        private SpriteFont font;
        private Vector2 messagePosition;
        private string scoreNumber;
        private string scoreMessage = "";
        public int score = 0;

        Song boom;

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Speed { get => speed; set => speed = value; }

        

        public Bomb(Game game, SpriteBatch spriteBatch,
            Texture2D pic,
            Vector2 position,
            Vector2 dogPosition,
            Vector2 speed,
            Vector2 screenRef) : base(game)
        {
            this.spriteBatch = spriteBatch;
            characterPic = pic;
            this.position = position;
            this.screenRef = screenRef;
            this.speed = speed;
            this.game1 = (Game1)game;
            this.dogPosition = dogPosition;

            explosion = game1.Content.Load<Texture2D>("images/explosion");
            boom = game1.Content.Load<Song>("sounds/Big Explosion Cut Off");
            font = game1.Content.Load<SpriteFont>("fonts/Hi-Font");
            messagePosition = new Vector2(500, 10);

            

        }

        public Rectangle bombBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, characterPic.Width, characterPic.Height);
        }

        public void DisableBomb()
        {
            this.Enabled = false;
            this.Visible = false;
            MediaPlayer.Stop(); 
        }

        public void RefreshBomb()
        { 
            this.Dispose();
        }

        public void EnableBomb()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(characterPic, position, Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            position += speed;

            Random randomPos = new Random();
            originalPosition = new Vector2(randomPos.Next(0, (int)screenRef.X), 0);

            Vector2 strikePosition = new Vector2(screenRef.X / 2, screenRef.Y - 51);

            scoreNumber = score.ToString();
       
            if (position.Y == strikePosition.Y)
            {
                game1.Components.Remove(message);

                explode = new Explosion(game1, position, explosion, spriteBatch, 3);
                game1.Components.Add(explode);

                MediaPlayer.Play(boom);
                explode.RestartAnimation();
                position = originalPosition;

                score += 10;
                scoreNumber = score.ToString();

                message = new SimpleString(game1, spriteBatch, font, scoreMessage = "Score: " + scoreNumber,
                messagePosition, Color.Black);

                game1.Components.Add(message);
            }

            
            

            

        }
    }
}
