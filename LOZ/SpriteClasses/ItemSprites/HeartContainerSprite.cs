using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class HeartContainerSprite : AbstractItemBlockClass
	{

		//-----Constructor-----
		public HeartContainerSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(102, 6, 139 - 101, 38 - 5);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime)
		{

		}

	}
}
