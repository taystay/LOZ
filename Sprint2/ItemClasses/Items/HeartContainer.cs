﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class HeartContainer : ItemAbstract
    {

        public HeartContainer(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateHeartContainerSprite();
            _itemLocation = itemLocation;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
