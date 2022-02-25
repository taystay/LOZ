using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class CompassSprite :AbstractItemBlockClass
	{

		//-----Constructor-----
		public CompassSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(105, 56, 26, 31);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	
	}
}
