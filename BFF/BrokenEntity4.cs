using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Collisions;
using System;
using Prototype02;

namespace FireRescue
{
    public class BrokenEntity4 : IEntity
    {
        private readonly Game1 _game;
        public int Velocity = 4;
        public IShapeF Bounds { get; }
        public Vector2 Oldpos;
        public int jumpSpeed;
        public Vector2 Endpos;
        private AnimatedSprite _BrokenSprite;
        private bool past;
        string animation;
        Random r;
        bool Hitplatform = false;

        public bool ISTRAP = false;
        public BrokenEntity4(Game1 game, IShapeF circleF, AnimatedSprite BrokenSprite)
        {
            _game = game;
            Bounds = circleF;
            Oldpos = Bounds.Position;
            animation = "stone3";
            BrokenSprite.Play(animation);
            _BrokenSprite = BrokenSprite;
            Endpos = Bounds.Position;
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                jumpSpeed = r.Next(20, 25);
            }
            past = true;
        }

        public virtual void Update(GameTime gameTime)
        {

            if (ISTRAP == true)
            {
                Bounds.Position += new Vector2(0, jumpSpeed);
                _BrokenSprite.Play(animation);
                _BrokenSprite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (Hitplatform == true || ISTRAP == false)
            {
                //past = true;
                Bounds.Position = Oldpos;
                Hitplatform = false;

            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
            if (ISTRAP == true)
            {
                spriteBatch.Draw(_BrokenSprite, Bounds.Position);

            }
        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {

            if (CollisionInfo.Other.ToString().Contains("PlayerEntity"))
            {
                ISTRAP = false;

            }
            if (CollisionInfo.Other.ToString().Contains("PlatformEntity"))
                {
                    Hitplatform = true;

                }
                if (CollisionInfo.Other.ToString().Contains("PlatformEntityTrap"))
                {
                    Hitplatform = true;

                }
            
        }

        public bool Past()
        {
            return past;
        }
    }
}
