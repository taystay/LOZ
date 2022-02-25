using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class DeadArrowSprite : AbstractItemBlockClass
	{

		//-----Constructor-----
		public DeadArrowSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(106, 246, 136 - 105, 274 - 245);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
