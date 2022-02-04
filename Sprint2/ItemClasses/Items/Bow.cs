using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Bow : IItem
    {
        private ISprite Sprite;
        private Point ItemLocation;
        private Boolean SpriteActivity = true;

        public Bow(Point itemLocation, double scale)
        {
            Sprite = ItemFactory.Instance.CreateBowSprite(scale);
            ItemLocation = itemLocation;
        }

        public void SetSize(double size)
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
