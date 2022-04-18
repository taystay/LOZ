using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class ArrowDownSprite : ItemSpriteAbstract
	{ 
		public ArrowDownSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(161, 55, 14, 34);
		}
		public override void Update(GameTime gameTime) { }
	}
}
