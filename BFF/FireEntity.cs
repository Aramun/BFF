using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.Sprites;

namespace Prototype02
{
    public class FireEntity:IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private bool isExist;
        private AnimatedSprite _FireSprite;
        string animation;

        public FireEntity(Game1 game, CircleF circleF, AnimatedSprite fireSprite)
        {
            _game = game;
            Bounds = circleF;

            animation = "fire1";
            fireSprite.Play(animation);
            _FireSprite = fireSprite;
            isExist = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            _FireSprite.Play(animation);
            _FireSprite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
               // spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
                spriteBatch.Draw(_FireSprite, Bounds.Position);
            
        }

        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            if (isExist)
            {
                if (collisionInfo.Other.ToString().Contains("PlayerEntity"))
                {
                    isExist = false;
                    
                }
            }
        }

        public bool IsExist()
        {
            return isExist;
        }
    }
}
