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
			ItemSpriteSheet = content.Load<Texture2D>("items");
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

		public ISprite CreateFireItemSprite(double scale)
        {
			return new FireItemSprite(ItemSpriteSheet, scale);
        }

		public ISprite CreateMapSprite(double scale)
        {
			return new MapSprite(ItemSpriteSheet, scale);
        }

		public ISprite CreateKeySprite(double scale)
		{
			return new KeySprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateHeartContainerSprite(double scale)
		{
			return new HeartContainerSprite(ItemSpriteSheet, scale);
		}
		public ISprite CreateTriforceSprite(double scale)
		{
			return new TriforceSprite(ItemSpriteSheet, scale);
		}
		public ISprite CreateBowSprite(double scale)
		{
			return new BowSprite(ItemSpriteSheet, scale);
		}
		public ISprite CreateHeartSprite(double scale)
		{
			return new HeartSprite(ItemSpriteSheet, scale);
		}
		public ISprite CreateRupeeSprite(double scale)
		{
			return new RupeeSprite(ItemSpriteSheet, scale);
		}
		public ISprite CreateBombSprite(double scale)
		{
			return new BombSprite(ItemSpriteSheet, scale);
		}
		public ISprite CreateFairySprite(double scale)
		{
			return new FairySprite(ItemSpriteSheet, scale);
		}

		/*
		public ISprite CreateSmallEnemySprite()
		{
			return new EnemySprite(enemySpritesheet, 32, 32);
		}
		*/
	}
}
