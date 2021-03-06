using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public abstract class AbstractTileBlock : IEnvironment
    {
		
		public bool Pushable { get; set; } = false;
		private protected ISprite sprite;
		private protected Point itemLocation;
		public Point Position
		{
			get => itemLocation;
            set => itemLocation = value;
		}
		public virtual bool IsActive() =>
			true; 
		public virtual void Update(GameTime gameTime) =>
			sprite.Update(gameTime); 
		public abstract Hitbox GetHitBox();

		public Point GetPosition() =>
			Position; 
		public virtual void Draw(SpriteBatch spriteBatch) =>
			sprite.Draw(spriteBatch, itemLocation);
		public virtual void Draw(SpriteBatch spriteBatch, Point offset)
        {
			if (sprite != null) sprite.Draw(spriteBatch, itemLocation + offset);
			else System.Diagnostics.Debug.WriteLine("" + this.GetType().ToString());
        }
	}
}
