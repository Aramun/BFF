using MonoGame.Extended.Collisions;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prototype02
{
    public class PlatformEntity : IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }

        public PlatformEntity(Game1 game, RectangleF rectangleF)
        {
            _game = game;
            Bounds = rectangleF;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3);

        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {

        }

    }
}
