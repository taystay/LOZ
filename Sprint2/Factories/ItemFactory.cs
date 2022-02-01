using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class ItemFactory
    {
		private Texture2D ItemSpriteSheet;
		// More private Texture2Ds follow
		// ...

		private static ItemFactory instance = new ItemFactory();

		public static ItemFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private ItemFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			ItemSpriteSheet = content.Load<Texture2D>("LinkSprites");
		}

		public ISprite CreateArrowItemSprite(double scale)
        {
			return new ArrowItemSprite(ItemSpriteSheet, scale);
        }

		public ISprite CreateCompassSprite(double scale)
        {
			return new CompassSprite(ItemSpriteSheet, scale);
        }

		public ISprite CreateClockSprite(double scale)
		{
			return new ClockSprite(ItemSpriteSheet, scale);
		}

		/*
		public ISprite CreateSmallEnemySprite()
		{
			return new EnemySprite(enemySpritesheet, 32, 32);
		}
		*/
	}
}
