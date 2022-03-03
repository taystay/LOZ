using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class InvisibleSprite : AbstractItemBlockClass
	{ 

		//-----Constructor-----
		public InvisibleSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(300, 250, 3, 3);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
		
	}
}
