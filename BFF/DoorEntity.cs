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
using Prototype02;

namespace FireRescue
{
    public class DoorEntity : IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private bool isExist;
        private AnimatedSprite _DoorSprite;
        string animation;

        public DoorEntity(Game1 game, CircleF circleF, AnimatedSprite DoorSprite)
        {
            _game = game;
            Bounds = circleF;

            animation = "door";
            DoorSprite.Play(animation);
            _DoorSprite = DoorSprite;
            isExist = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            _DoorSprite.Play(animation);
            _DoorSprite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
            spriteBatch.Draw(_DoorSprite, Bounds.Position);

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