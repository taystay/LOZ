using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.DungeonClasses
{
    public class ExteriorObject : IGameObjects
    {

		private protected ISprite sprite;
		private protected Point itemLocation;
        public ExteriorObject(Point p)
        {
            itemLocation = p;
            sprite = Factories.DungeonFactory.Instance.GetExterior();
        }

		public void Update(GameTime timer)
        {

        }

		public Hitbox GetHitBox()
        {
            return new Hitbox(itemLocation.X, itemLocation.Y, 3 * (776 - 521), 3 * (186 - 11));
        }

		public virtual void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, itemLocation);
		}

    }
}
