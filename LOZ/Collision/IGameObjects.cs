﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.Collision.Iterator
{
    public interface IGameObjects
    {
        public Rectangle GetHitBox();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}