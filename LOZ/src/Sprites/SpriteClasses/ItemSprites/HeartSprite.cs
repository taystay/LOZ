using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class HeartSprite : ItemSpriteAbstract
	{
		public HeartSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(206, 111, 223 - 205, 130 - 110);
		}
		public override void Update(GameTime gameTime) { }		
	}
}
