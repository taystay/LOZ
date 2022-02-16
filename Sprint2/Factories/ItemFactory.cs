﻿
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.SpriteClasses.ItemSprites;

namespace Sprint2.Factories
{
    class ItemFactory
    {
		private Texture2D ItemSpriteSheet;

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

		public ISprite CreateDeadBeamSprite(double scale)
		{
			return new SwordBeamDeathSprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateSwordBeamDownSprite(double scale)
		{
			return new SwordBeamDownSprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateSwordBeamUpSprite(double scale)
		{
			return new SwordBeamUpSprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateSwordBeamLeftSprite(double scale)
		{
			return new SwordBeamLeftSprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateSwordBeamRightSprite(double scale)
		{
			return new SwordBeamRightSprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateArrowUpSprite(double scale)
        {
			return new ArrowUpSprite(ItemSpriteSheet, scale);
        }

		public ISprite CreateDeadArrowSprite(double scale)
		{
			return new DeadArrowSprite(ItemSpriteSheet, scale);
		}
		public ISprite CreateDeadBombSprite(double scale)
		{
			return new DeadBombSprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateArrowLeftSprite(double scale)
		{
			return new ArrowLeftSprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateArrowDownSprite(double scale)
		{
			return new ArrowDownSprite(ItemSpriteSheet, scale);
		}

		public ISprite CreateArrowRightSprite(double scale)
		{
			return new ArrowRightSprite(ItemSpriteSheet, scale);
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
			return new BombSprite(ItemSpriteSheet);
		}
		public ISprite CreateFairySprite(double scale)
		{
			return new FairySprite(ItemSpriteSheet, scale);
		}
	}
}
