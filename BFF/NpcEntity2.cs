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
   public class NpcEntity2: IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private AnimatedSprite _NpcSprite;
        string animation;
        private bool isRescue;
        int Rescue;
        bool allRescue;

        public NpcEntity2(Game1 game, CircleF circleF, AnimatedSprite Npcsprite)
        {
            _game = game;
            Bounds = circleF;
            animation = "npc2";
            _NpcSprite = Npcsprite;
            isRescue = false;
            allRescue = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            _NpcSprite.Play(animation);
            _NpcSprite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            if (Rescue == 1)
            {
                allRescue = true;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isRescue == false)
            {
                //spriteBatch.DrawCircle((CircleF)Bounds, 8, Color.Red, 3f);
                spriteBatch.Draw(_NpcSprite, Bounds.Position);
            }

        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {
            if (!isRescue)
            {
                if (CollisionInfo.Other.ToString().Contains("PlayerEntity"))
                {
                    isRescue = true;
                    Rescue += 1;

                }
            }
        }

        public bool IsRescue()
        {
            return isRescue;
        }

        public bool AllRescue()
        {
            return allRescue;
        }
    }
}
