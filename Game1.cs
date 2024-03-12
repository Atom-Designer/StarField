using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Starfield
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Star[] stars;
        Texture2D startexture;
        Random r;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            r = new Random();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            startexture = Content.Load<Texture2D>("star");
            stars = new Star[100];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(startexture, new Rectangle(400, 240, 10, 10));
                stars[i].color = new Color(r.Next(255), r.Next(255), r.Next(255));
                stars[i].vX = r.Next(20)-6;
                stars[i].vY = r.Next(20)-6;
                if (stars[i].vX == 0 && stars[i].vY == 0)
                {
                    stars[i].vX++;
                    stars[i].vY++;
                }
            }
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Update();
                if (stars[i].outside())
                {
                    stars[i].rect.X = 400;
                    stars[i].rect.Y = 240;
                    stars[i].color = new Color(r.Next(255), r.Next(255), r.Next(255));
                    stars[i].vX = r.Next(20)-6;
                    if (stars[i].vX == 0)
                    {
                        stars[i].vX++;
                    }
                    stars[i].vY = r.Next(20)-6;
                    if (stars[i].vY == 0)
                    {
                        stars[i].vY++;
                    }
                }

            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            for (int i = 0; i < stars.Length; i++)
            {
                spriteBatch.Draw(stars[i].tex, stars[i].rect, stars[i].color);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
