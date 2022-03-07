﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class LadderSprite : AbstractBlock
	{
		public LadderSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(0, 0, 16, 16);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}