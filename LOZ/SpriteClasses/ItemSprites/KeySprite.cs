using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class KeySprite : AbstractItemBlockClass
	{
		//-----Constructor-----
		public KeySprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(62, 9, 20, 30);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
		
	}
}
