using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class MapSprite : AbstractItemBlockClass
	{
		//-----Constructor-----
		public MapSprite(Texture2D texture)
		{
			//scale = 2.0;
			_texture = texture;
			frame = new Rectangle(303, 108, 18, 27);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
