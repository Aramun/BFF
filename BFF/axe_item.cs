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
    public class aex_item : IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private bool isExist;
        private AnimatedSprite _Aex;
        string animation;

        public aex_item(Game1 game, CircleF circleF, AnimatedSprite Aex)
        {
            _game = game;
            Bounds = circleF;

            animation = "aex";
            Aex.Play(animation);
            _Aex = Aex;
            isExist = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            _Aex.Play(animation);
            _Aex.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isExist)
            {
                //spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
                spriteBatch.Draw(_Aex, Bounds.Position);
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
