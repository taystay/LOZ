using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class SwordBeamLeftSprite : AbstractItemBlockClass
	{
		//-----Constructor-----
		public SwordBeamLeftSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(58, 159, 82 - 57, 172 - 158);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) {  }
	}
}
