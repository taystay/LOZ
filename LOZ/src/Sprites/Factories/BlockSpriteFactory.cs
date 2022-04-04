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

		public static BlockSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private BlockSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			blockSpritesheet = content.Load<Texture2D>("ZeldaDungeonBlocks");
			basementSheet = content.Load<Texture2D>("BasementTiles");
		}

		public ISprite CreateBlackTileSprite()
		{
			return new BlackTileSprite(blockSpritesheet);
		}

		public ISprite CreateBlueSandBlockSprite() 
		{
			return new BlueSandBlockSprite(blockSpritesheet);
		}

		public ISprite CreateBlueTriangleBlockSprite()
		{
			return new BlueTriangleTileSprite(blockSpritesheet);
		}

		public ISprite CreateDarkBlueSolidBlockSprite()
		{
			return new DarkBlueSolidBlockSprite(blockSpritesheet);
		}

		public ISprite CreateMulticolored1Sprite()
		{
			return new Multicolored1Sprite(blockSpritesheet);
		}

		public ISprite CreateMulticolored2Sprite()
		{
			return new MultiColored2Sprite(blockSpritesheet);
		}

		public ISprite CreateSolidBlueTileSprite()
		{
			return new SolidBlueTileSprite(blockSpritesheet);
		}

		public ISprite CreateStairsBlockSprite()
		{
			return new StairsBlockSprite(blockSpritesheet);
		}

		public ISprite CreateBasementBlockSprite()
		{
			return new BasementTileSprite(basementSheet);
		}

		public ISprite CreateLadderSprite()
		{
			return new LadderSprite(basementSheet);
		}

		public ISprite CreateFadeBlackSprite()
        {
			return new BlackTileSprite(basementSheet);
        }
	}
}
