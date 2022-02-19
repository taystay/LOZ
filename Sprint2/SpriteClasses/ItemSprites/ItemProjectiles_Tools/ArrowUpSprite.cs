﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class ArrowUpSprite : AbstractItemBlockClass
	{
		
		//-----Constructor-----
		public ArrowUpSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(259, 56, 11, 31);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
