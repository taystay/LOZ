using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class FireItem : ItemAbstract
    { 
        public FireItem(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateFireItemSprite();
            _itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
