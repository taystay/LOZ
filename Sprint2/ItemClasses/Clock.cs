using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Clock : IItem
    {
        private ISprite Sprite;
        private Point ItemLocation;
        private Boolean SpriteActivity = true;
        public Clock(Point itemLocation, double scale)
        {
            Sprite = ItemFactory.Instance.CreateClockSprite(scale);
            ItemLocation = itemLocation;
        }

        public void SetSpriteActivity(Boolean activity)
        {
            SpriteActivity = activity;
        }

        public Boolean SpriteActive()
        {
            return SpriteActivity;
        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, ItemLocation);
        }

    }
}
