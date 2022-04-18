using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class ArrowUpSprite : ItemSpriteAbstract
	{
		public ArrowUpSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(259, 56, 11, 31);
		}
		public override void Update(GameTime gameTime) { }
	}
}
