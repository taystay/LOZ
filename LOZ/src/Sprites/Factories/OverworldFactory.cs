using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses.BlockSprites;
using LOZ.SpriteClasses;

namespace LOZ.Factories
{
    class OverworldFactory
    {
		private Texture2D blockSpritesheet;


		private static OverworldFactory instance = new OverworldFactory();
		public static OverworldFactory Instance { get => instance; }
		private OverworldFactory() { }
		public void LoadAllTextures(ContentManager content) => blockSpritesheet = content.Load<Texture2D>("LOZEnvironemnt");
		public ISprite BottomWall() => new OverworldTile(blockSpritesheet, 0);
		public ISprite TopWall() => new OverworldTile(blockSpritesheet, 1);
		public ISprite Sand() => new OverworldTile(blockSpritesheet, 2);
		public ISprite TopLeftTree() => new OverworldTile(blockSpritesheet, 3);
		public ISprite BottomLeftTree() => new OverworldTile(blockSpritesheet, 4);
		public ISprite TopRightTree() => new OverworldTile(blockSpritesheet, 5);
		public ISprite BottomRightTree() => new OverworldTile(blockSpritesheet, 6);
		public ISprite CenterTree() => new OverworldTile(blockSpritesheet, 7);
		public ISprite Bridge() => new OverworldTile(blockSpritesheet, 8);
		public ISprite Water() => new OverworldTile(blockSpritesheet, 9);
	}
}
