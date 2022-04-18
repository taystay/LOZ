using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class HeartContainerSprite : ItemSpriteAbstract
	{
		public HeartContainerSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(102, 6, 139 - 101, 38 - 5);
		}
		public override void Update(GameTime gameTime) { }
	}
}
