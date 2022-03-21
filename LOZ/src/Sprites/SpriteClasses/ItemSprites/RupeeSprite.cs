using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class RupeeSprite : AbstractItemBlockClass
	{
		//-----Constructor-----
		public RupeeSprite(Texture2D texture)
		{
			//scale = 2.0;
			_texture = texture;
			frame = new Rectangle(303, 10, 318 - 302, 37 - 9);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
