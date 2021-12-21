using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RunDoggyRun
{
    class Menu : DrawableGameComponent
    {
        public int selectedIndex { get; set; }
        private string[] menuContent;

        private SpriteBatch spriteBatch;
        private SpriteFont normalFont;
        private SpriteFont selectedFont;
        private Vector2 position;
        private Vector2 screenRef;
        private KeyboardState previousState;
        private Texture2D menuBackground;

        public Menu(Game game, SpriteBatch spriteBatch,
            SpriteFont normalFont,
            SpriteFont selectedFont,
            string[] menuContent,
            Vector2 screenRef,
            Texture2D menuBackground) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.normalFont = normalFont;
            this.selectedFont = selectedFont;
            this.menuContent = menuContent;
            this.menuBackground = menuBackground;
            this.screenRef = screenRef;

            this.position = new Vector2(screenRef.X / 2 - 70, screenRef.Y / 2 - 60);

        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 Pos = position;

            spriteBatch.Begin();

            for (int i = 0; i < menuContent.Length; i++)
            {
                if(selectedIndex == i)
                {
                    spriteBatch.Draw(menuBackground, new Rectangle((int)Pos.X, (int)Pos.Y,
                        (int)selectedFont.MeasureString(menuContent[i]).X, 40), Color.Black);

                    spriteBatch.DrawString(selectedFont, menuContent[i], Pos, Color.White);
                    Pos.Y += selectedFont.LineSpacing;
                }

                else
                {
                    spriteBatch.DrawString(normalFont, menuContent[i], Pos, Color.Black);
                    Pos.Y += normalFont.LineSpacing;
                }

            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Up) && previousState.IsKeyUp(Keys.Up))
            {
                selectedIndex--;

                if (selectedIndex <= -1)
                {
                    selectedIndex = menuContent.Length - 1;
                }
            }


            else if (key.IsKeyDown(Keys.Down) && previousState.IsKeyUp(Keys.Down))
            {
                selectedIndex++;

                if (selectedIndex >= menuContent.Length)
                {
                    selectedIndex = 0;
                }

            }

            previousState = key;

            base.Update(gameTime);
        }
    }
}
