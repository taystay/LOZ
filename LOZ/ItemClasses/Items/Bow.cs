using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class Bow : ItemAbstract
    {

        public Bow(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateBowSprite();
            _itemLocation = itemLocation;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
