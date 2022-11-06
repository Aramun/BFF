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
    public class extinguisherwithfire4 : IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private bool isExist;
        private AnimatedSprite _extinguisher ;
        string animation;

        public extinguisherwithfire4(Game1 game, CircleF circleF, AnimatedSprite extinguisher)
        {
            _game = game;
            Bounds = circleF;

            animation = "extinguisher";
            extinguisher.Play(animation);
            _extinguisher = extinguisher;
            isExist = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            _extinguisher.Play(animation);
            _extinguisher.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isExist)
            {
                //spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
                spriteBatch.Draw(_extinguisher, Bounds.Position);
            }

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
