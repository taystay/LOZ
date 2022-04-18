using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class ArrowRightSprite : ItemSpriteAbstract
	{ 
		public ArrowRightSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(297,65,330 - 296,77 - 64);
		}
		public override void Update(GameTime gameTime) { }
	}
}
