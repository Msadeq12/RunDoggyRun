using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using MonoString;

namespace RunDoggyRun
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private Texture2D backgroundImage;
        private Song gameSong;
        public Vector2 screenRef;
        

        private StartScene startScene;
        private PlayScene playScene;
        private AboutScene aboutScene;
        private HelpScene helpScene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected void HideAll()
        {
            foreach (var item in Components)
            {
                Scene scene = null;
                SimpleString comp = null;
                Bomb bomb = null;
                

                if (item is Scene)
                {
                    scene = (Scene)item;
                    scene.HideScene();
                }

                if(item is SimpleString)
                {
                    comp = (SimpleString) item;
                    comp.DisableText();
                }

                if (item is Bomb)
                {
                    bomb = (Bomb)item;
                    bomb.RefreshBomb();
                }
    
            }
        }
        

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            backgroundImage = this.Content.Load<Texture2D>("images/background");
            gameSong = this.Content.Load<Song>("sounds/Robot Boogie - Quincas Moreira");

            
            screenRef = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
           
            
            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.ShowScene();

            playScene = new PlayScene(this);
            this.Components.Add(playScene);

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            MediaPlayer.Play(gameSong);
            //MediaPlayer.IsRepeating = true;

        }

        protected void BackScene()
        {
            HideAll();
            playScene.components.Clear();
            startScene.ShowScene();
            playScene.Initialize();
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                BackScene();

            

            // TODO: Add your update logic here

            int index = 0;

            KeyboardState keyButton = Keyboard.GetState();

            if (startScene.Enabled)
            {
                index = startScene.menu.selectedIndex;
                

                if (index == 0 && keyButton.IsKeyDown(Keys.Enter))
                {
                    HideAll();
                    //playScene.Initialize();
                    playScene.ShowScene();
                    
                    
                }

                else if(index == 1 && keyButton.IsKeyDown(Keys.Enter))
                {
                    HideAll();
                    aboutScene.ShowScene();

                }

                else if (index == 2 && keyButton.IsKeyDown(Keys.Enter))
                {
                    HideAll();
                    helpScene.ShowScene();

                }

                else if(index == 3 && keyButton.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }


            }

           

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundImage, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
