﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class FireItem : IItem
    {
        private ISprite sprite;
        private Point itemLocation;
        private Boolean spriteActivity = true;

        public FireItem(Point itemLocation, double scale)
        {
            sprite = ItemFactory.Instance.CreateFireItemSprite(scale);
            this.itemLocation = itemLocation;
        }

        public void SetSize(double size)
        {
            sprite.SetSize(size);
        }

        public void SetPosition(Point Position)
        {
            itemLocation.X = Position.X;
            itemLocation.Y = Position.Y;
        }

        public void SetSpriteActivity(Boolean activity)
        {
            spriteActivity = activity;
        }

        public Boolean SpriteActive()
        {
            return spriteActivity;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, itemLocation);
        }

    }
}
