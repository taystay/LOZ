using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class PortalGunSprite : ItemSpriteAbstract
	{ 
		public PortalGunSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(309, 238, 327 - 309, 286 - 238);
		}
		public override void Update(GameTime gameTime) { }
		
	}
}
