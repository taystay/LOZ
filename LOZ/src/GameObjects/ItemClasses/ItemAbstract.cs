﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.ItemsClasses
{
    abstract class ItemAbstract : IItem
    {
        private protected ISprite sprite;
        private protected Point _itemLocation;
        private protected bool spriteActivity =  true;
        private protected int hitBoxWidth = 1;
        private protected int hitBoxHeight = 1;
        public void SetPosition(Point position)
        {
            _itemLocation = position;
        }
        public bool SpriteActive()
        {
            return spriteActivity;
        }
        public void KillItem()
        {
            spriteActivity = false;
        }
        public Hitbox GetHitBox()
        {
            Hitbox hitbox = new Hitbox(_itemLocation.X - hitBoxWidth / 2, _itemLocation.Y - hitBoxHeight / 2, hitBoxWidth, hitBoxHeight);
            return hitbox;
        }
        public abstract void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, _itemLocation);
        }
    }
}