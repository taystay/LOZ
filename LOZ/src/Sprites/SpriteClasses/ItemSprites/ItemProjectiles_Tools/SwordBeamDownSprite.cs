using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class SwordBeamDownSprite : ItemSpriteAbstract
	{	
		public SwordBeamDownSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(18, 152, 29 - 17, 181 - 151);
		}

		public override void Update(GameTime gameTime) { }
	}
}
