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
    public class Itemuse : IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        bool itemuse = false;

        public Itemuse(Game1 game, RectangleF rectangleF)
        {
            _game = game;
            Bounds = rectangleF;
        }

        public virtual void Update(GameTime gameTime)
        {

            if (_game.EXT()==false)
            {
                itemuse = false;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Green, 3);

        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {
            if (CollisionInfo.Other.ToString().Contains("PlayerEntity") )
            {
              itemuse = true;

            }

        }
        public bool Item()
        {
            return itemuse;
        }

    }
}
