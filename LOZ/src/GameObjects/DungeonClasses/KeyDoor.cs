﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.DungeonClasses
{
    public class KeyDoor : IGameObjects
    {
		private protected ISprite sprite;
		private protected Point itemLocation;
        public KeyDoor(Point location, DoorLocation n)
        {
            sprite = Factories.DungeonFactory.Instance.CreateKeyDoor(n);
            itemLocation = location;
        }
		public void Update(GameTime timer)
        {

        }
		public Hitbox GetHitBox()
        {
            return new Hitbox(0, 0, 0, 0);
        }
		public void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, itemLocation);
		}
    }
}