﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.DungeonClasses
{
    public class ExteriorObject : IGameObjects
    {

		private protected ISprite sprite;
		private protected Point itemLocation;
        public ExteriorObject()
        {
            sprite = Factories.DungeonFactory.Instance.GetExterior();
            itemLocation = DungeonInfo.Map.Location;
            
        }

		public void Update(GameTime timer)
        {

        }

		public Hitbox GetHitBox()
        {
            Rectangle i = DungeonInfo.Inside;
            return new Hitbox(i.X, i.Y, i.Width, i.Height);
        }

		public virtual void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, itemLocation);
		}

    }
}
