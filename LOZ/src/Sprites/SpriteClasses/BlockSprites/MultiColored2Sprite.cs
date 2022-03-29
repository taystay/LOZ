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
			frame = SpriteStandardizeClass.multicolored2Sprite;
		}


		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
