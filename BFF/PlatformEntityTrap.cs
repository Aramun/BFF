using MonoGame.Extended.Collisions;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Prototype02;

namespace FireRescue

{
    public class PlatformEntityTrap : IEntity
    {
        private readonly Game1 _game;
        public bool ishit;
        public IShapeF Bounds { get; }

        public BrokenEntity _broken;
        public BrokenEntity2 _broken2;
        public BrokenEntity3 _broken3;
        public BrokenEntity4 _broken4;

        public float countDown = 0;
        public PlatformEntityTrap(Game1 game, RectangleF rectangleF)
        {
            _game = game;
            Bounds = rectangleF;
        }

        public PlatformEntityTrap(Game1 game, RectangleF rectangleF, BrokenEntity broken)
        {
            _game = game;
            Bounds = rectangleF;
            this._broken = broken;
        }

        public PlatformEntityTrap(Game1 game, RectangleF rectangleF, BrokenEntity2 broken2)
        {
            _game = game;
            Bounds = rectangleF;
            this._broken2 = broken2;
        }
        public PlatformEntityTrap(Game1 game, RectangleF rectangleF, BrokenEntity3 broken3)
        {
            _game = game;
            Bounds = rectangleF;
            this._broken3 = broken3;
        }

        public PlatformEntityTrap(Game1 game, RectangleF rectangleF, BrokenEntity4 broken4)
        {
            _game = game;
            Bounds = rectangleF;
            this._broken4 = broken4;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (countDown > 0)
            {
                countDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                countDown = 0;
            }
            if(countDown == 0)
            {
                ishit = false;
            }
            if(_game.ISTRAP() == false && ishit == true)
            {
                ishit = false;
            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
           // spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Green, 3);

        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {
            if (CollisionInfo.Other.ToString().Contains("PlayerEntity"))
            {
                if (_broken != null && countDown == 0)
                {
                    _broken.ISTRAP = true;
                    countDown = 5f;
                    ishit = true;
                }
                if (_broken2 != null && countDown == 0)
                {
                    _broken2.ISTRAP = true;
                    countDown = 5f;
                    ishit = true;
                }
                if (_broken3 != null && countDown == 0)
                {
                    _broken3.ISTRAP = true;
                    countDown = 5f;
                    ishit = true;
                }
                if (_broken4 != null && countDown == 0)
                {
                    _broken4.ISTRAP = true;
                    countDown = 5f;
                    ishit = true;
                }
            }
        }

        public bool ISHIT()
        {
            return ishit;
        }

    }
}
