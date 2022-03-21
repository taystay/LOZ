using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class ArrowRightSprite : AbstractItemBlockClass
	{ 

		//-----Constructor-----
		public ArrowRightSprite(Texture2D texture)
		{
			//scale = 2.0;
			_texture = texture;
			frame = new Rectangle(297,65,330 - 296,77 - 64);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
