using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses.ItemSprites;
using LOZ.SpriteClasses;

namespace LOZ.Factories
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

		public ISprite CreateDeadBeamSprite()
		{
			return new SwordBeamDeathSprite(ItemSpriteSheet);
		}

		public ISprite CreateSwordBeamDownSprite()
		{
			return new SwordBeamDownSprite(ItemSpriteSheet);
		}

		public ISprite CreateSwordBeamUpSprite()
		{
			return new SwordBeamUpSprite(ItemSpriteSheet);
		}

		public ISprite CreateSwordBeamLeftSprite()
		{
			return new SwordBeamLeftSprite(ItemSpriteSheet);
		}

		public ISprite CreateSwordBeamRightSprite()
		{
			return new SwordBeamRightSprite(ItemSpriteSheet);
		}

		public ISprite CreateArrowUpSprite()
        {
			return new ArrowUpSprite(ItemSpriteSheet);
        }

		public ISprite CreateDeadArrowSprite()
		{
			return new DeadArrowSprite(ItemSpriteSheet);
		}
		public ISprite CreateDeadBombSprite()
		{
			return new DeadBombSprite(ItemSpriteSheet);
		}

		public ISprite CreateArrowLeftSprite()
		{
			return new ArrowLeftSprite(ItemSpriteSheet);
		}

		public ISprite CreateArrowDownSprite()
		{
			return new ArrowDownSprite(ItemSpriteSheet);
		}

		public ISprite CreateArrowRightSprite()
		{
			return new ArrowRightSprite(ItemSpriteSheet);
		}

		public ISprite CreateCompassSprite()
        {
			return new CompassSprite(ItemSpriteSheet);
        }

		public ISprite CreateClockSprite()
		{
			return new ClockSprite(ItemSpriteSheet);
		}

		public ISprite CreateFireItemSprite()
        {
			return new FireItemSprite(ItemSpriteSheet);
        }

		public ISprite CreateMapSprite()
        {
			return new MapSprite(ItemSpriteSheet);
        }

		public ISprite CreateKeySprite()
		{
			return new KeySprite(ItemSpriteSheet);
		}

		public ISprite CreateHeartContainerSprite()
		{
			return new HeartContainerSprite(ItemSpriteSheet);
		}
		public ISprite CreateTriforceSprite()
		{
			return new TriforceSprite(ItemSpriteSheet);
		}
		public ISprite CreateBowSprite()
		{
			return new BowSprite(ItemSpriteSheet);
		}
		public ISprite CreateHeartSprite()
		{
			return new HeartSprite(ItemSpriteSheet);
		}
		public ISprite CreateRupeeSprite()
		{
			return new RupeeSprite(ItemSpriteSheet);
		}
		public ISprite CreateBombSprite()
		{
			return new BombSprite(ItemSpriteSheet);
		}
		public ISprite CreateFairySprite()
		{
			return new FairySprite(ItemSpriteSheet);
		}

		public ISprite CreateYellowPixelSprite()
		{
			return new YellowPixelSprite(ItemSpriteSheet);
		}
	}
}
