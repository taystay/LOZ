using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class Compass : ItemAbstract
    {
        public Compass(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateCompassSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 34;
        }
        public override  void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
