using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class HeartSprite : AbstractItemBlockClass
	{

		//-----Constructor-----
		public HeartSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(206, 111, 223 - 205, 130 - 110);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
		
		
	}
}
