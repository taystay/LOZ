﻿using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Key : ItemAbstract
    {
        public Key(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateKeySprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 34;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}