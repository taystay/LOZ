using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public abstract class AbstractTileBlock : IEnvironment
    {

		private protected ISprite sprite;
		private protected Point itemLocation;
		public abstract void Update(GameTime timer);

		public abstract Hitbox GetHitBox();
		public Point GetPosition() {
			return itemLocation;
		
		}

		public virtual void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, itemLocation);
		}

    }
}
