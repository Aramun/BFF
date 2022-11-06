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
    public class playermenuentity : IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private AnimatedSprite _playermenuentity;
        string animation;

        public playermenuentity(Game1 game, IShapeF circleF, AnimatedSprite _playermenuSpeite)
        {
            _game = game;
            Bounds = circleF;

            animation = "animate";
            _playermenuSpeite.Play(animation);
            _playermenuentity = _playermenuSpeite;

        }

        public virtual void Update(GameTime gameTime)
        {
            _playermenuentity.Play(animation);
            _playermenuentity.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
          
            spriteBatch.Draw(_playermenuentity, ((RectangleF)Bounds).Center);

        }

        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            
        }

       
    }
}
