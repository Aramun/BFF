using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Collisions;
using System;

namespace Prototype02
{
    public class BrokenEntity 
    {
        /*private readonly Game1 _game;
        public int Velocity = 4;
        public IShapeF Bounds { get; }
        public Vector2 Oldpos;
        public int jumpSpeed;

        private Texture2D _BrokenSprite;
        private bool past;
        Random r;
        public BrokenEntity(Game1 game, IShapeF circleF, Texture2D BrokenSprite)
        {
            _game = game;
            Bounds = circleF;
            Oldpos = Bounds.Position;
            _BrokenSprite = BrokenSprite;
            Random r = new Random();
            for(int i = 0; i<4; i++)
            {
                jumpSpeed = r.Next(1,3);
            }
            past = true;
        }

        /*public virtual void Update(GameTime gameTime)
        {
            
                Bounds.Position += new Vector2(0, jumpSpeed);
        
            if (Bounds.Position.Y > 480)
            {
                //past = true;
                Bounds.Position = Oldpos;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
            spriteBatch.Draw(_BrokenSprite, Bounds.Position, Color.White);
        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {
            if (past)
            {
                if (CollisionInfo.Other.ToString().Contains("PlayerEntity"))
                {
                    past = false;

                }
            }
        }

        public bool Past()
        {
            return past;
        }*/
    }
}

