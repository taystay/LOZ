using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class SwordSprite : AbstractItemBlockClass
	{ 

		//-----Constructor-----
		public SwordSprite(Texture2D texture)
		{
			//scale = 2.0;
			_texture = texture;
			frame = new Rectangle(261, 243, 11, 28);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
		
	}
}
