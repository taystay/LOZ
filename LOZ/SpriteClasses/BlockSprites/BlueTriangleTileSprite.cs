using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Sprint2.SpriteClasses.BlockSprites
{
    class BlueTriangleTileSprite : AbstractItemBlockClass
    {
		//-----Constructor-----
		public BlueTriangleTileSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(41, 29, 32, 32);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	
	}


}
