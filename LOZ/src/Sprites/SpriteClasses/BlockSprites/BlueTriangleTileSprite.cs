﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace LOZ.SpriteClasses.BlockSprites
{
    class BlueTriangleTileSprite : AbstractBlock
	{
		public BlueTriangleTileSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = SpriteStandardizeClass.blueTriangleSprite;
		}
		public override void Update(GameTime gameTime) { }
	
	}


}
