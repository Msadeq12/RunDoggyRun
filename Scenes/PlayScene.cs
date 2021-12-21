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
    class PlayScene : Scene
    {
        private SpriteBatch spriteBatch;
        public Character doggy;
        public Bomb bomb;
        public SimpleString message;
        Game1 thisGame;
        Vector2 messagePosition;
        private SpriteFont font;
        private Texture2D doggyPic;
        private Vector2 screenRef;
        private Vector2 bombPosition;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 bombSpeed;
        private Texture2D bombPic;
        private Texture2D knifePic;
        private Vector2 knifePosition;
        private Vector2 knifeSpeed;
        string gameOver = "";
        Song lose;


        public PlayScene(Game game) : base(game)
        {
            thisGame = (Game1)game;

            spriteBatch = thisGame._spriteBatch;

            screenRef = new Vector2(thisGame._graphics.PreferredBackBufferWidth,
                thisGame._graphics.PreferredBackBufferHeight);

            doggyPic = thisGame.Content.Load<Texture2D>("images/dog");
            position = new Vector2(screenRef.X / 2 - doggyPic.Width/2, screenRef.Y - 30);
            speed = new Vector2(5, 0);

            bombSpeed = new Vector2(0, 3);
            bombPic = thisGame.Content.Load<Texture2D>("images/bomb");
            Random randomPositions = new Random();
            messagePosition = new Vector2(screenRef.X / 2, screenRef.Y / 2);

            bombPosition = new Vector2(randomPositions.Next(0, 
                thisGame._graphics.PreferredBackBufferWidth - 40), 0);

            Vector2 originalPosition = new Vector2(randomPositions.Next(0, 
                thisGame._graphics.PreferredBackBufferWidth - bombPic.Width), 0);

            
            font = thisGame.Content.Load<SpriteFont>("fonts/Hi-Font");

            knifePic = thisGame.Content.Load<Texture2D>("images/knife");

            Random randomKnife = new Random();

  
            doggy = new Character(thisGame, spriteBatch, doggyPic, position, speed, screenRef);
            this.components.Add(doggy);

            bomb = new Bomb(thisGame, spriteBatch, bombPic, bombPosition, position, bombSpeed, screenRef);
            this.components.Add(bomb);

            lose = thisGame.Content.Load<Song>("sounds/Dumpster Rattle");

            
            
        }

       

        public override void Update(GameTime gameTime)
        {
            Rectangle dogBounds = doggy.charBounds();
            Rectangle bombRect = bomb.bombBounds();
            

            doggy.EnableChar();
            bomb.EnableBomb();

            if (dogBounds.Intersects(bombRect))
            {
                gameOver = "Game Over";
                message = new SimpleString(thisGame, spriteBatch, font, gameOver, messagePosition, Color.Red);
                this.components.Add(message);
                MediaPlayer.Play(lose);
                doggy.DisableChar();
                bomb.DisableBomb();
                
            }

  
            base.Update(gameTime);
        }

        public override void Initialize()
        {
            doggy = new Character(thisGame, spriteBatch, doggyPic, position, speed, screenRef);
            this.components.Add(doggy);

            bomb = new Bomb(thisGame, spriteBatch, bombPic, bombPosition, position, bombSpeed, screenRef);
            this.components.Add(bomb);

            message = new SimpleString(thisGame, spriteBatch, font, gameOver, messagePosition, Color.Red);

            base.Initialize();
        }
    }
}
