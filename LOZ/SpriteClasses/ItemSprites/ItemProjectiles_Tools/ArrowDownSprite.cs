﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class ArrowDownSprite : AbstractItemBlockClass
	{ 

		//-----Constructor-----
		public ArrowDownSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frame = new Rectangle(161, 55, 14, 34);
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
