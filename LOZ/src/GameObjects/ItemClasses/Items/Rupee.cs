using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Rupee :ItemAbstract
    {

        public Rupee(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateRupeeSprite();
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
