using MonoGame.Extended.Collisions;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;

namespace Prototype02
{
    public class PlayerEntity:IEntity
    {
        private readonly Game1 _game;
        public int Velocity = 20;
        Vector2 move;
        Vector2 jump;
        public IShapeF Bounds { get; }
        private KeyboardState _currentkey;
        private KeyboardState _oldkey;

        bool isJumping;
        bool isGrounded;
        public int jumpSpeed;
        float force;

        private AnimatedSprite _PlayrSprite;
        string animation;
        bool isHit;
        public PlayerEntity(Game1 game, IShapeF circleF, AnimatedSprite PlayerSprite)
        {
            _game = game;
            Bounds = circleF;

            jumpSpeed = -30;
            force = 20;
            isGrounded = false;

            animation = "idle";
            PlayerSprite.Play(animation);
            _PlayrSprite = PlayerSprite;
        }

        public virtual void Update(GameTime gameTime)
        {
            _currentkey = Keyboard.GetState();

            if (isGrounded) { animation = "idle"; }

            if (_currentkey.IsKeyDown(Keys.D) && Bounds.Position.X < _game.GetMapWidth() - ((RectangleF)Bounds).Width)
            {
                move = new Vector2(Velocity, 0) * gameTime.GetElapsedSeconds() * 50;
                if(Bounds.Position.X - _game.GetCameraPositionX() >= 200
                    && _game.GetCameraPositionX() < _game.GetMapWidth() - (_game.GetMapWidth() ))
                {
                    _game.UpdateCamera(move);
                }
                Bounds.Position += move;

                if (isGrounded)
                {
                    animation = "run";
                    _PlayrSprite.Effect = SpriteEffects.None;
                }
            }

            else if (_currentkey.IsKeyDown(Keys.A) && Bounds.Position.X > 0)
            {
                move = new Vector2(-Velocity, 0) * gameTime.GetElapsedSeconds() * 50;
                if(Bounds.Position.X - _game.GetCameraPositionX() <= 200
                    && _game.GetCameraPositionX() > 0)
                {
                    _game.UpdateCamera(move);
                }
                Bounds.Position += move;

                if (isGrounded)
                {
                    animation = "run";
                    _PlayrSprite.Effect = SpriteEffects.FlipHorizontally;
                }
            }

            if (isJumping && force < 0)
            {
                isJumping = false;
            }

            if (_currentkey.IsKeyDown(Keys.W) && _oldkey.IsKeyUp(Keys.W) && isGrounded)
            {
                isJumping = true;
                isGrounded = false;
                jump = new Vector2(0, -jumpSpeed) * gameTime.GetElapsedSeconds() * 50;
                if (Bounds.Position.Y - _game.GetCameraPositionY() <= 120)
                    
                {
                    _game.UpdateCamera(jump);
                }
                Bounds.Position += jump;
            }

            if (isJumping)
            {
                animation = "jump";
                jumpSpeed = -30;
                force -= gameTime.GetElapsedSeconds() * 32;
            }
            else
            {
                jumpSpeed = 30;
                if (!isGrounded)
                {
                    animation = "land";
                }
            }
            Bounds.Position += new Vector2(0, jumpSpeed) * gameTime.GetElapsedSeconds() * 50;
            _PlayrSprite.Play(animation);
            _PlayrSprite.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            _oldkey = _currentkey;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3f);
            spriteBatch.Draw(_PlayrSprite, ((RectangleF)Bounds).Center);

        }

        public void OnCollision(CollisionEventArgs CollisionInfo)
        {
            if (CollisionInfo.Other.ToString().Contains("PlatformEntity"))
            {
                if (!isJumping)
                {
                    if (((RectangleF)Bounds).Top < ((RectangleF)CollisionInfo.Other.Bounds).Top && ((RectangleF)Bounds).Bottom < ((RectangleF)CollisionInfo.Other.Bounds).Bottom)
                    {
                        isGrounded = true;
                        force = 10;
                    }
                }
                Bounds.Position -= CollisionInfo.PenetrationVector;
            }

            /*if (CollisionInfo.Other.ToString().Contains("BrokenEntity"))
            {
                Bounds.Position = Vector2.Zero;
                _game.UpdateCamera(Vector2.Zero);
                _game.Setcam(Vector2.Zero);
                isHit = false;
            }
            if (CollisionInfo.Other.ToString().Contains("FireEntity"))
            {
                Bounds.Position = Vector2.Zero;
                _game.UpdateCamera(Vector2.Zero);
                _game.Setcam(Vector2.Zero);
                isHit = false;
                _game.GetMapWidth();
            }
            if (CollisionInfo.Other.ToString().Contains("FireEntity2"))
            {
                Bounds.Position = Vector2.Zero;
                _game.UpdateCamera(Vector2.Zero);
                _game.Setcam(Vector2.Zero);

                isHit = false;
            }*/
        }

        public bool IsHit()
        {
            return isHit;
        }

        public bool IsJump()
        {
            return isJumping;
        }
    }
}
