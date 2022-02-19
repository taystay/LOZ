using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.BlockSprites
{
    class SolidBlueTileSprite : AbstractItemBlockClass
    {

		//-----Constructor-----
		public SolidBlueTileSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(7, 29, 32, 32);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }

	}
}
