using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.SpriteClasses;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class ArrowDownSprite : AbstractItemBlockClass
	{ 

		//-----Constructor-----
		public ArrowDownSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(161, 55, 174 - 160, 88 - 54);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
