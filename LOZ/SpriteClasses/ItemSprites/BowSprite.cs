using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class BowSprite : AbstractItemBlockClass
	{ 

		//-----Constructor-----
		public BowSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(159, 104, 176 - 158, 131 - 103);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
		
	}
}
