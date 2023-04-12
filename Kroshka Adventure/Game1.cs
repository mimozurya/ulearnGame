using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Kroshka_Adventure
{
    enum Stat
    {
        SplashScreen,
        Game,
        Final,
        Pause
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Stat Stat = Stat.SplashScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1020;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SplashScreen.Background = Content.Load<Texture2D>("background");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");
            Asteroids.Init(spriteBatch, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Wind.Texture2D = Content.Load<Texture2D>("wind");
        }

        protected override void Update(GameTime gameTime)
        {
            switch(Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
                    if (Keyboard.GetState().IsKeyDown(Keys.Space)) Stat = Stat.Game;
                    break;
                case Stat.Game:
                    Asteroids.Update();
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Stat = Stat.SplashScreen;
                    break;
            }

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit();
            SplashScreen.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            switch(Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Draw(spriteBatch);
                    break;
                case Stat.Game:
                    Asteroids.Draw();
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}