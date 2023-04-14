using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Kroshka_Adventure
{
    class Asteroids
    {
        public static int Width, Height;
        public static Random rnd = new Random();
        static public SpriteBatch SpriteBatch { get; set; }
        static Wind[] winds;
        static public Character Character { get; set; }
        static public int GetIntRnd (int min, int max)
        {
            return rnd.Next(min, max);
        }

        static public void Init (SpriteBatch SpriteBatch, int Width, int Height)
        {
            Asteroids.Width = Width;
            Asteroids.Height = Height;
            Asteroids.SpriteBatch = SpriteBatch;
            winds = new Wind[50];
            for (int i = 0; i < winds.Length; i++)
                winds[i] = new Wind(new Vector2(-rnd.Next(1, 10), 0));
            Character = new Character(new Vector2(0, 0));
        }

        static public void Draw()
        {
            foreach (Wind wind in winds)
                wind.Draw();
            Character.Draw();
        }

        static public void Update()
        {
            foreach (Wind wind in winds)
                wind.Update();
        }

    }

    class Wind
    {
        Vector2 Pos; // позиция
        Vector2 Dir; // направление движения
        Color color;

        public static Texture2D Texture2D { get; set; }

        public Wind (Vector2 Pos, Vector2 Dir)
        {
            this.Pos = Pos;
            this.Dir = Dir;
        }

        public Wind (Vector2 Dir)
        {
            this.Dir = Dir;
            RandomSet();
        }

        public void Update()
        {
            Pos += Dir;
            if (Pos.X < 0)
                RandomSet();
        }

        public void RandomSet()
        {
            Pos = new Vector2(Asteroids.GetIntRnd(Asteroids.Width, Asteroids.Width + 300), Asteroids.GetIntRnd(0, Asteroids.Height));
            color = Color.FromNonPremultiplied(Asteroids.GetIntRnd(0, 256), Asteroids.GetIntRnd(0, 256), Asteroids.GetIntRnd(0, 256), 255);
        }

        public void Draw()
        {
            Asteroids.SpriteBatch.Draw(Texture2D, Pos, color);
        }
    }

    class Character
    {
        public Vector2 Pos; // позиция
        Color color = Color.White;
        public int Speed { get; set; } = 3;

        public static Texture2D Texture2D { get; set; }

        public Character (Vector2 Pos)
        {
            this.Pos = Pos;
        }

        public void Up()
        {
            if (this.Pos.Y > 0) this.Pos.Y -= Speed;
        }
        public void Down()
        {
            if (this.Pos.Y < Asteroids.Height - Texture2D.Height) this.Pos.Y += Speed;
        }
        public void Left()
        {
            if (this.Pos.X > 0) this.Pos.X -= Speed;
        }
        public void Right()
        {
            if (this.Pos.X < Asteroids.Width - Texture2D.Width) this.Pos.X += Speed;
        }

        public void Draw()
        {
            Asteroids.SpriteBatch.Draw(Texture2D, Pos, color);
        }
    }


}
