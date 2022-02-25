using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class ClockSprite : AbstractItemBlockClass
	{ 
		//-----Constructor-----
		public ClockSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(9, 6, 30, 35);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
		
	}
}
