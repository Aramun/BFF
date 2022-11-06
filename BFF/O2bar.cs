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
    public class O2bar : IEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        private AnimatedSprite _O2sprite;
        string animation;
        Vector2 O2pos;

        public O2bar(Game1 game, IShapeF circleF, AnimatedSprite O2)
        {
            _game = game;
            //Bounds = rectangleF;
            animation = "animation0";
            Bounds = circleF;
            O2.Play(animation);
            _O2sprite = O2;
            //O2pos = _game.Playpos() - new Vector2(0,-200);
            //O2pos = pos;
        }

        public virtual void Update(GameTime gameTime)
        {
            

            if (_game.ISTUTORIAL())
            {
                Bounds.Position = _game.Playpos() - new Vector2(900, 650);

                if (_game.Time() >= 60)
                {
                    animation = "animation0";
                }
                else if (_game.Time() >= 50 && _game.Time() < 51)
                {
                    animation = "animation1";
                }
                else if (_game.Time() >= 40 && _game.Time() < 41)
                {
                    animation = "animation2";
                }
                else if (_game.Time() >= 35 && _game.Time() < 36)
                {
                    animation = "animation3";
                }
                else if (_game.Time() >= 30 && _game.Time() < 31)
                {
                    animation = "animation4";
                }
                else if (_game.Time() >= 20 && _game.Time() < 22)
                {
                    animation = "animation5";
                }
                else if (_game.Time() >= 10 && _game.Time() < 11)
                {
                    animation = "animation6";
                }
                else if (_game.Time() >= 0 && _game.Time() == 0)
                {
                    animation = "animation7";
                }
            }

            if (_game.ISGAMEPLAY())
            {
                Bounds.Position = _game.Playpos() - new Vector2(900, 650);
                if (_game.Time() >= 180)
                {
                    animation = "animation0";
                }
                else if (_game.Time() >= 150 && _game.Time() < 151)
                {
                    animation = "animation1";
                }
                else if (_game.Time() >= 120 && _game.Time() < 121)
                {
                    animation = "animation2";
                }
                else if (_game.Time() >= 90 && _game.Time() < 91)
                {
                    animation = "animation3";
                }
                else if (_game.Time() >= 60 && _game.Time() < 61)
                {
                    animation = "animation4";
                }
                else if (_game.Time() >= 30 && _game.Time() < 31)
                {
                    animation = "animation5";
                }
                else if (_game.Time() >= 10 && _game.Time() < 11)
                {
                    animation = "animation6";
                }
                else if (_game.Time() >= 0 && _game.Time() == 0)
                {
                    animation = "animation7";
                }
            }

            if (_game.ISGAMEPLAY2())
            {
                Bounds.Position = _game.Playpos() - new Vector2(900, 650);

                if (_game.Time() >= 420)
                {
                    animation = "animation0";
                }
                else if (_game.Time() >= 360 && _game.Time() < 361)
                {
                    animation = "animation1";
                }
                else if (_game.Time() >= 300 && _game.Time() < 301)
                {
                    animation = "animation2";
                }
                else if (_game.Time() >= 240 && _game.Time() < 241)
                {
                    animation = "animation3";
                }
                else if (_game.Time() >= 180 && _game.Time() < 181)
                {
                    animation = "animation4";
                }
                else if (_game.Time() >= 120 && _game.Time() < 121)
                {
                    animation = "animation5";
                }
                else if (_game.Time() >= 60 && _game.Time() < 61)
                {
                    animation = "animation6";
                }
                else if (_game.Time() >= 0 && _game.Time() == 0)
                {
                    animation = "animation7";
                }
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
