using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public abstract class AbstractTileBlock : IEnvironment
    {
		public Point Position
        {
            get
            {
				return itemLocation;
            } 
			set
            {
				itemLocation = value;
            }
        }
		public bool Pushable { get; set; } = false;
		private protected ISprite sprite;
		private protected Point itemLocation;
		public virtual void Update(GameTime gameTime) {
			sprite.Update(gameTime);

		}

		public abstract Hitbox GetHitBox();
		public Point GetPosition() {
			return Position;	
		}

		public virtual void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, itemLocation);
		}

    }
}
