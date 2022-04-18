using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class BombSprite : ItemSpriteAbstract
	{
		private Color color = new Color(255, 255, 255);
		public BombSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(111, 99, 129 - 110, 133 - 98);
		}
		public override void Update(GameTime gameTime)
		{
			scale += .005;
			color.G -= 3;
			color.B -= 3;
		}
	}
}
