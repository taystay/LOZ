using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	class LinkSpriteFactory
	{
		private Texture2D linkSpriteSheet;
		// More private Texture2Ds follow
		// ...

		private static LinkSpriteFactory instance = new LinkSpriteFactory();

		public static LinkSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private LinkSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			linkSpriteSheet = content.Load<Texture2D>("LinkSprites");
		}

        public ISprite LinkIdle()
        {

            return new LinkIdle(linkSpriteSheet);

        }

		public ISprite LinkMovingUp()
		{

			return new LinkMovingUp(linkSpriteSheet);

		}

		public ISprite LinkMovingDown()
		{

			return new LinkMovingDown(linkSpriteSheet);

		}

		public ISprite LinkMovingLeft()
		{

			return new LinkMovingLeft(linkSpriteSheet);

		}

		public ISprite LinkMovingRight()
		{

			return new LinkMovingRight(linkSpriteSheet);

		}


	}
}
