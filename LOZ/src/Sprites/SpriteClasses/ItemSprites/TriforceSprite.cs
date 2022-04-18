using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class TriforceSprite : ItemSpriteAbstract
	{
		private int counter = 0;
		private const int countsPerFrame = 30;
		public TriforceSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(155, 7, 179 - 154, 33 - 6);
		}
		public override void Update(GameTime gameTime) {
			counter++;
			if (counter >= countsPerFrame / 2)
				frame = new Rectangle(204, 9, 179 - 154, 33 - 6);
			else
				frame = new Rectangle(155, 7, 179 - 154, 33 - 6);
			if (counter > countsPerFrame)
				counter = 0;
		}
	}
}
