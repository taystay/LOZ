using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace LOZ.SpriteClasses.BlockSprites
{
	class Multicolored1Sprite :AbstractItemBlockClass
	{
		public Multicolored1Sprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(75, 29, 32, 32);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }


	}
}
