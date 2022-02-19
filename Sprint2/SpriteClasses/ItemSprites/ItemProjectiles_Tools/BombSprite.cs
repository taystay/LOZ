using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class BombSprite : AbstractItemBlockClass
	{
		private Color color = new Color(255, 255, 255);

		public BombSprite(Texture2D texture)
		{
			scale = 1.5;
			_texture = texture;
			frame = new Rectangle(111, 99, 129 - 110, 133 - 98);
		}

		public override void Update(GameTime gameTime)
		{
			scale += .01;
			color.G -= 3;
			color.B -= 3;
		}
	}
}
