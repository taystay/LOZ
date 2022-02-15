
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.SpriteClasses.BlockSprites;

namespace Sprint2.Factories
{
    class BlockSpriteFactory
    {
		private Texture2D blockSpritesheet;
		// More private Texture2Ds follow
		// ...

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
		}

		public ISprite CreateBlackTileSprite(double scale)
		{
			return new BlackTileSprite(blockSpritesheet, scale);
		}

		public ISprite CreateBlueSandBlockSprite(double scale) 
		{
			return new BlueSandBlockSprite(blockSpritesheet, scale);
		}

		public ISprite CreateBlueTriangleBlockSprite(double scale)
		{
			return new BlueTriangleTileSprite(blockSpritesheet, scale);
		}

		public ISprite CreateDarkBlueSolidBlockSprite(double scale)
		{
			return new DarkBlueSolidBlockSprite(blockSpritesheet, scale);
		}

		public ISprite CreateMulticolored1Sprite(double scale)
		{
			return new Multicolored1Sprite(blockSpritesheet, scale);
		}

		public ISprite CreateMulticolored2Sprite(double scale)
		{
			return new MultiColored2Sprite(blockSpritesheet, scale);
		}

		public ISprite CreateSolidBlueTileSprite(double scale)
		{
			return new SolidBlueTileSprite(blockSpritesheet, scale);
		}

		public ISprite CreateStairsBlockSprite(double scale)
		{
			return new StairsBlockSprite(blockSpritesheet, scale);
		}



	}
}
