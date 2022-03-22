using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class TriforceSprite : AbstractItemBlockClass
	{

		private const int maxFrame = 2;
		//-----Constructor-----
		public TriforceSprite(Texture2D texture)
		{
			//scale = 2.0;
			_texture = texture;
			frame = new Rectangle(155, 7, 179 - 154, 33 - 6);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) {
			if (gameTime.TotalGameTime.Seconds % 2 == 0)
			{
				frame = new Rectangle(204, 9, 179 - 154, 33 - 6);
			}
			else
			{
				frame = new Rectangle(155, 7, 179 - 154, 33 - 6);
			}
		}
	}
}
