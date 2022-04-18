using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class SwordBeamUpSprite : ItemSpriteAbstract
	{
		public SwordBeamUpSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(112, 152, 124 - 111, 181 - 151);
		}
		public override void Update(GameTime gameTime) { }
	}
}
