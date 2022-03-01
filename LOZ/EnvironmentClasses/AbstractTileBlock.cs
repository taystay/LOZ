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

		public Hitbox GetHitBox()
		{

			return new Hitbox(itemLocation.X - 32, itemLocation.Y - 32, 48, 48);
		}

		public void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, itemLocation);
		}

    }
}
