using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RunDoggyRun
{
    class StartScene : Scene
    {
        private SpriteBatch spriteBatch;
        public Menu menu { get; set; }

        string[] menuContent = { "Play Game", "About", "Help", "Exit" };

        public StartScene(Game game) : base(game)
        {
            Game1 thisGame = (Game1) game;

            this.spriteBatch = thisGame._spriteBatch;
            SpriteFont regularFont = thisGame.Content.Load<SpriteFont>("fonts/Font");
            SpriteFont selectedFont = thisGame.Content.Load<SpriteFont>("fonts/Hi-Font");
            Texture2D background = thisGame.Content.Load<Texture2D>("images/black");
            Vector2 screenRef = thisGame.screenRef;

            menu = new Menu(thisGame, spriteBatch, regularFont, selectedFont, menuContent, screenRef, background);
            this.components.Add(menu);
        }
    }
}
