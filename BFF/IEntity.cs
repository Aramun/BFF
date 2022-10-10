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
    internal interface IEntity : ICollisionActor
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
