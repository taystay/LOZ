using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class RupeeSprite : ItemSpriteAbstract
	{
		public RupeeSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(303, 10, 318 - 302, 37 - 9);
		}
		public override void Update(GameTime gameTime) { }
	}
}
