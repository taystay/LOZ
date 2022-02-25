using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class Rupee :ItemAbstract
    {

        public Rupee(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateRupeeSprite();
            _itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
