using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Sword : ItemAbstract
    {

        public Sword(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateSwordSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 11;
            hitBoxHeight = 28;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
