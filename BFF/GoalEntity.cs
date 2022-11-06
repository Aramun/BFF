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
    public class GoalEntity:IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private AnimatedSprite _GoalSprite;
        string animation;
        private bool isRescue = false;
        bool hit;
        

        public GoalEntity(Game1 game, CircleF circleF, AnimatedSprite Npcsprite)
        {
            _game = game;
            Bounds = circleF;
            animation = "goal1";
            _GoalSprite = Npcsprite;
            isRescue = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            _GoalSprite.Play(animation);
            _GoalSprite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
           // spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
            spriteBatch.Draw(_GoalSprite, Bounds.Position);

        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {
            if (!isRescue)
            {
                if (CollisionInfo.Other.ToString().Contains("PlayerEntity") && _game.rescuenum >= 4)
                {
                    isRescue = true;
                }
            }
        }

        public bool IsRescue()
        {
            return isRescue;
        }
    }
}
