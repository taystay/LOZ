using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.SpriteClasses.ItemSprites;
using LOZ.SpriteClasses;

namespace LOZ.Factories
{
    class ItemFactory
    {
		private Texture2D ItemSpriteSheet;
		private static ItemFactory instance = new ItemFactory();
		public static ItemFactory Instance { get => instance;  }
		private ItemFactory() { }
		public void LoadAllTextures(ContentManager content) =>
			ItemSpriteSheet = content.Load<Texture2D>("items");
		public ISprite CreateDeadBeamSprite() => new SwordBeamDeathSprite(ItemSpriteSheet);
		public ISprite CreateSwordBeamDownSprite() => new SwordBeamDownSprite(ItemSpriteSheet);
		public ISprite CreateSwordBeamUpSprite() => new SwordBeamUpSprite(ItemSpriteSheet);
		public ISprite CreateSwordBeamLeftSprite() => new SwordBeamLeftSprite(ItemSpriteSheet);
		public ISprite CreateSwordBeamRightSprite() => new SwordBeamRightSprite(ItemSpriteSheet);
		public ISprite CreateArrowUpSprite() => new ArrowUpSprite(ItemSpriteSheet);
		public ISprite CreateDeadArrowSprite() => new DeadArrowSprite(ItemSpriteSheet);
		public ISprite CreateDeadBombSprite() => new DeadBombSprite(ItemSpriteSheet);
		public ISprite CreateArrowLeftSprite() => new ArrowLeftSprite(ItemSpriteSheet);
		public ISprite CreateArrowDownSprite() => new ArrowDownSprite(ItemSpriteSheet);
		public ISprite CreateArrowRightSprite() => new ArrowRightSprite(ItemSpriteSheet);
		public ISprite CreateCompassSprite() => new CompassSprite(ItemSpriteSheet);
		public ISprite CreateClockSprite() => new ClockSprite(ItemSpriteSheet);
		public ISprite CreateFireItemSprite() => new FireItemSprite(ItemSpriteSheet);
		public ISprite CreateMapSprite() => new MapSprite(ItemSpriteSheet);
		public ISprite CreateKeySprite() => new KeySprite(ItemSpriteSheet);
		public ISprite CreateHeartContainerSprite() => new HeartContainerSprite(ItemSpriteSheet);
		public ISprite CreateTriforceSprite() => new TriforceSprite(ItemSpriteSheet);
		public ISprite CreateBowSprite() => new BowSprite(ItemSpriteSheet);
		public ISprite CreateSwordSprite() => new SwordSprite(ItemSpriteSheet);
		public ISprite CreateHeartSprite() => new HeartSprite(ItemSpriteSheet);
		public ISprite CreateRupeeSprite() => new RupeeSprite(ItemSpriteSheet);
		public ISprite CreateBombSprite() => new BombSprite(ItemSpriteSheet);
		public ISprite CreateFairySprite() => new FairySprite(ItemSpriteSheet);
		public ISprite CreateYellowPixelSprite(Rectangle Box) => new YellowPixelSprite(ItemSpriteSheet, Box);
		public ISprite CreateInvisibleSprite() => new InvisibleSprite(ItemSpriteSheet);
		public ISprite CreatePortalGun() => new PortalGunSprite(ItemSpriteSheet);
	}
}
