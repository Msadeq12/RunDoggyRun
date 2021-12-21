using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RunDoggyRun
{
    class Scene : DrawableGameComponent
    {
        public List<DrawableGameComponent> components { get; set; }

        public virtual void ShowScene()
        {
            this.Visible = true;
            this.Enabled = true;
        }

        public virtual void HideScene()
        {
            this.Visible = false;
            this.Enabled = false;
        }

        public Scene(Game game) : base(game)
        {
            components = new List<DrawableGameComponent>();
            HideScene();
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent gameComponent = null;

            foreach (var item in components)
            {
                
                
                    gameComponent =  item;

                    if (gameComponent.Visible)
                    {
                        gameComponent.Draw(gameTime);
                    }
                

            }
            

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }

            }

            base.Update(gameTime);
        }
    }
}
