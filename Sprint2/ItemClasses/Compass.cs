using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Compass : IItem
    {
        private ISprite Sprite;
        private Point ItemLocation;
        private Boolean SpriteActivity = true;
        public Compass(Point itemLocation, double scale)
        {
            Sprite = ItemFactory.Instance.CreateCompassSprite(scale);
            ItemLocation = itemLocation;
        }

        public void SetSize(int size)
        {
            Sprite.SetSize(size);
        }

        public void SetPosition(Point Position)
        {
            ItemLocation.X = Position.X;
            ItemLocation.Y = Position.Y;
        }

        public void SetSpriteActivity(Boolean activity)
        {
            SpriteActivity = activity;
        }

        public Boolean SpriteActive()
        {
            return SpriteActivity;
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, ItemLocation);
        }

    }
}
