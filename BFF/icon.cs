using MonoGame.Extended.Collisions;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Prototype02;
using MonoGame.Extended.Sprites;

namespace FireRescue
{
    public class icon : IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private AnimatedSprite _O2sprite;
        string animation;
        Vector2 O2pos;

        public icon(Game1 game, IShapeF circleF, AnimatedSprite O2)
        {
            _game = game;
            //Bounds = rectangleF;
            animation = "HP0";
            Bounds = circleF;
            O2.Play(animation);
            _O2sprite = O2;
            //O2pos = _game.Playpos() - new Vector2(0,-200);
            //O2pos = pos;
        }

        public virtual void Update(GameTime gameTime)
        {
            Bounds.Position = _game.Playpos() - new Vector2(900, 450);


            if (_game.HEALTH() >= 3)
            {
                animation = "HP0";
            }
            else if (_game.HEALTH() >= 2)
            {
                animation = "HP1";
            }
            else if (_game.HEALTH() >= 1)
            {
                animation = "HP2";
            }
            else if (_game.HEALTH() == 0)
            {
                animation = "HP3";
            }
           
            _O2sprite.Play(animation);
            _O2sprite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Green, 3);
            spriteBatch.Draw(_O2sprite, ((RectangleF)Bounds).Center);

        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {

        }
    }
}
