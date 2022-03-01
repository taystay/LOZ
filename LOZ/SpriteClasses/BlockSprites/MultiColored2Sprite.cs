using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{ 
	class MultiColored2Sprite : AbstractBlock
	{

		//-----Constructor-----
		public MultiColored2Sprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(109, 29, 32, 32);
		}


		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
