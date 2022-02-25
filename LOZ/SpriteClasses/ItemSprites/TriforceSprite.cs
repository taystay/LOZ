using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class TriforceSprite : AbstractItemBlockClass
	{
		//-----Constructor-----
		public TriforceSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(155, 7, 179 - 154, 33 - 6);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
