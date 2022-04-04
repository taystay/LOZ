using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class PortalGunSprite : AbstractItemBlockClass
	{ 

		//-----Constructor-----
		public PortalGunSprite(Texture2D texture)
		{
			//scale = 1.0;
			_texture = texture;
			frame = new Rectangle(309, 238, 327 - 309, 286 - 238);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
		
	}
}
