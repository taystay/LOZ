using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses.BlockSprites;
using LOZ.SpriteClasses;

namespace LOZ.Factories
{
    class BlockSpriteFactory
    {
		private Texture2D blockSpritesheet;
		private Texture2D basementSheet;
		private static BlockSpriteFactory instance = new BlockSpriteFactory();
		public static BlockSpriteFactory Instance { get { return instance;} }
		private BlockSpriteFactory() { }
		public void LoadAllTextures(ContentManager content)
		{
			blockSpritesheet = content.Load<Texture2D>("ZeldaDungeonBlocks");
			basementSheet = content.Load<Texture2D>("BasementTiles");
		}
		public ISprite CreateBlackTileSprite() => new BlackTileSprite(blockSpritesheet);
		public ISprite CreateBlueSandBlockSprite() => new BlueSandBlockSprite(blockSpritesheet);
		public ISprite CreateBlueTriangleBlockSprite() => new BlueTriangleTileSprite(blockSpritesheet);
		public ISprite CreateDarkBlueSolidBlockSprite() => new DarkBlueSolidBlockSprite(blockSpritesheet);
		public ISprite CreateMulticolored1Sprite() => new Multicolored1Sprite(blockSpritesheet);
		public ISprite CreateMulticolored2Sprite() => new MultiColored2Sprite(blockSpritesheet);
		public ISprite CreateSolidBlueTileSprite() => new SolidBlueTileSprite(blockSpritesheet);
		public ISprite CreateStairsBlockSprite() => new StairsBlockSprite(blockSpritesheet);
		public ISprite CreateBasementBlockSprite() => new BasementTileSprite(basementSheet);
		public ISprite CreateLadderSprite() => new LadderSprite(basementSheet);
		public ISprite CreateFadeBlackSprite() => new BlackTileSprite(basementSheet);
	}
}
