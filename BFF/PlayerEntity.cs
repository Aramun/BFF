using MonoGame.Extended.Collisions;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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
        Song hit_stone;


        bool isJumping;
        bool isGrounded;
        public int jumpSpeed;
        float force;
        bool isright;
        bool isburn = false;

        private AnimatedSprite _PlayrSprite;
        string animation;
        bool Ishit;
        public float countDown = 0;
        bool death = false;
        int health = 3;
        bool invisible = false;
        bool burn = false;
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
            if (countDown > 0)
            {
                countDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                burn = false;
            }
            else
            {
                countDown = 0;
                invisible = false;
                
            }

            if (isGrounded && countDown == 0 && !death)
            {
                animation = "idle";
            }
            else
            {
                jumpSpeed = 20;
                if (!isGrounded)
                {
                    animation = "land";
                }
            }
            if(_game.Time() == 0)
            {
                death = true;
            }

            if (death && !isburn)
            {
                invisible = false;
                animation = "deathwithstone";
            }
            if (death && isburn)
            {
                invisible = false;
                animation = "deathwithfire";
            }
            if (_currentkey.IsKeyDown(Keys.Enter) && death)
            {

                if (_game.ISTUTORIAL())
                {
                    Bounds.Position = new Vector2(0, 2400);
                }
                if (_game.ISGAMEPLAY())
                {
                    Bounds.Position = new Vector2(480, 3300);
                }
                if (_game.ISGAMEPLAY2())
                {
                    Bounds.Position = new Vector2(480, 9600);
                }
                _game.UpdateCamera(Vector2.Zero);
                _game.Setcam(Vector2.Zero);
                health = 3;

                if(countDown > 0)
                {
                    animation = "reborn";
                }
                isburn = false;
                death = false;

            }
            if (_currentkey.IsKeyDown(Keys.F) && countDown >= 0 && _game.EXT())
            {
                animation = "useext";
                countDown = 1f;
                if (isright)
                {
                    _PlayrSprite.Effect = SpriteEffects.None;
                }
                if (!isright)
                {
                    _PlayrSprite.Effect = SpriteEffects.FlipHorizontally;
                }
            }
            if (_currentkey.IsKeyDown(Keys.F) && countDown >= 0 && _game.AXE())
            {
                animation = "useaex";
                countDown = 1f;
                if (isright)
                {
                    _PlayrSprite.Effect = SpriteEffects.None;
                }
                if (!isright)
                {
                    _PlayrSprite.Effect = SpriteEffects.FlipHorizontally;
                }
            }
            if (_currentkey.IsKeyDown(Keys.D) && Bounds.Position.X < _game.GetMapWidth() - ((RectangleF)Bounds).Width && !death)
            {
                move = new Vector2(Velocity, 0) * gameTime.GetElapsedSeconds() * 50;
                Bounds.Position += move;
                isright = true;

                if (isGrounded)
                {
                    animation = "run";
                    _PlayrSprite.Effect = SpriteEffects.None;
                }
            }

            else if (_currentkey.IsKeyDown(Keys.A) && Bounds.Position.X > 0 && !death)
            {
                move = new Vector2(-Velocity, 0) * gameTime.GetElapsedSeconds() * 50;
                /*  if(Bounds.Position.X - _game.GetCameraPositionX() <= 240
                      && _game.GetCameraPositionX() > 0)
                  {
                      _game.UpdateCamera(move);
                  }*/
                Bounds.Position += move;
                isright = false;

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

            if (_currentkey.IsKeyDown(Keys.W) && _oldkey.IsKeyUp(Keys.W) && isGrounded && !death)
            {
                isJumping = true;
                isGrounded = false;
                jump = new Vector2(0, -jumpSpeed) * gameTime.GetElapsedSeconds() * 50;
                if (Bounds.Position.Y - _game.GetCameraPositionY() <= 240

                    && _game.GetCameraPositionY() < _game.GetMapHeigh() - (_game.GetMapHeigh() / 3))

                {
                    _game.UpdateCamera(jump);
                }
                Bounds.Position += jump;
            }

            if (isJumping)
            {
                animation = "jump";
                jumpSpeed = -20;
                force -= gameTime.GetElapsedSeconds() * 32;
            }
            else
            {
                jumpSpeed = 20;
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
           // spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3f);
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
                        force = 20;
                    }
                }
                Bounds.Position -= CollisionInfo.PenetrationVector;
            }
            if (CollisionInfo.Other.ToString().Contains("FireEntity") && countDown <= 0)
            {
                countDown = 4;
                Ishit = true;
                invisible = true;
                if (!death && health > 0)
                {
                    burn = true;
                }
                
                if (health > 0)
                {
                    health -= 1;
                }
                if (health == 0)
                {
                    death = true;
                    isburn = true;
                }
            }
            if (CollisionInfo.Other.ToString().Contains("FireEntity2") && countDown <= 0)
            {
                countDown = 4;
                Ishit = true;
                invisible = true;
                if (!death && health > 0)
                {
                    burn = true;
                }
                if (health > 0)
                {
                    health -= 1;
                }
                if (health == 0)
                {
                    death = true;
                    isburn = true;
                }
            }
            if (CollisionInfo.Other.ToString().Contains("FireEntity3") )
            {
                if (!death)
                {
                    burn = true;
                }
                death = true;
                    isburn = true;
                
            }
            if (CollisionInfo.Other.ToString().Contains("FireEntity4") )
            {

                if (!death)
                {
                    burn = true;
                }
                death = true;
                    isburn = true;
                
            }
            if (CollisionInfo.Other.ToString().Contains("DoorEntity") && countDown <= 0)
            {


                if (!death)
                {
                    burn = true;
                }
                death = true;
                isburn = true;

            }
            if (CollisionInfo.Other.ToString().Contains("PlatformEntityTrap") && Ishit == true)
            {
                Ishit = false;
            }
            if (!CollisionInfo.Other.ToString().Contains("PlatformEntityTrap"))
            {
                Ishit = true;
            }


            if (CollisionInfo.Other.ToString().Contains("BrokenEntity") && countDown <= 0 && _game.ISTRAP())
            {
                countDown = 4;
                Ishit = true;
                invisible = true;

                if (health > 0)
                {
                    health -= 1;
                    
                }
                if (health == 0)
                {
                    death = true;
                }
                
            }
            if (CollisionInfo.Other.ToString().Contains("BrokenEntity2") && countDown == 0 && _game.ISTRAP() )
            {
                countDown = 2;
                Ishit = true;
                invisible = true;
                if (health > 0)
                {
                    health -= 1;
                }
                if (health == 0)
                {
                    death = true;
                }
            }

            /*if (CollisionInfo.Other.ToString().Contains("BrokenEntity3") && _game.ISTRAP() && countDown == 0)
            {
                countDown = 2;
                Ishit = true;
                if (health > 0)
                {
                    health -= 1;
                }
                if (health == 0)
                {
                    death = true;
                }
            }
            if (CollisionInfo.Other.ToString().Contains("BrokenEntity4") && _game.ISTRAP() && countDown == 0)
            {
                countDown = 2;
                Ishit = true;
                if (health > 0)
                {
                    health -= 1;
                }
                if (health == 0)
                {
                    death = true;
                }
            }*/


        }

        public bool IsHit()
        {
            return Ishit;
        }

        public bool IsJump()
        {
            return isJumping;
        }
        public int HEALTH()
        {
            return health;
        }

        public bool DEATH()
        {
            return death;
        }
        public bool INVISIBLE()
        {
            return invisible;
        }
        public bool BURN()
        {
            return burn;
        }

    }
}
