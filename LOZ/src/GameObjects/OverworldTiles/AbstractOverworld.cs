using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public abstract class AbstractOverworld : IEnvironment
    {
		private protected ISprite sprite;
		public Point Position { get; set; }

		#region IEnviornment variables
		public bool Pushable { get; set; } = false;
		public Point GetPosition() => Position;
        #endregion

        public abstract Hitbox GetHitBox();

        #region virtual functions
        public virtual bool IsActive() => true;
		public virtual void Draw(SpriteBatch spriteBatch) => Draw(spriteBatch, new Point());		
		public virtual void Update(GameTime gameTime)
		{
			sprite.Update(gameTime);
		}
		public virtual void Draw(SpriteBatch spriteBatch, Point offset)
		{
			sprite.Draw(spriteBatch, Position + offset);
		}
        #endregion
    }
}
