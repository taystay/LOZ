using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class SwordBeamDownSprite : AbstractItemBlockClass
	{
	
		public SwordBeamDownSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(18, 152, 29 - 17, 181 - 151);
		}

		public override void Update(GameTime gameTime) { }
	}
}
