using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class ArrowLeftSprite :AbstractItemBlockClass
	{
		//-----Constructor-----
		public ArrowLeftSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(200, 65, 233 - 199, 76 - 64);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
