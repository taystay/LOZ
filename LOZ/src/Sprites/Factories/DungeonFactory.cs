
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses.BlockSprites;
using LOZ.SpriteClasses;
using LOZ.DungeonClasses;

namespace LOZ.Factories
{
    class DungeonFactory
    {
		private Texture2D blockSpritesheet;
		private static DungeonFactory instance = new DungeonFactory();
		public static DungeonFactory Instance { get { return instance; } }
		private DungeonFactory() { }
		public void LoadAllTextures(ContentManager content)
		{
			blockSpritesheet = content.Load<Texture2D>("8376");
		}
	    public ISprite GetPortal(int direction, int color) =>
			new PortalSprite(blockSpritesheet, direction, color);
		public ISprite GetExterior() =>
			new ExteriorSprite(blockSpritesheet);
		public ISprite CreateDoorWay(DoorLocation num) =>
			new DoorSprite(blockSpritesheet, num);
		public ISprite CreateKeyDoor(DoorLocation location) =>
			new KeyDoorSprite(blockSpritesheet, location);
		public ISprite CreateWall(DoorLocation location) =>
			new WallSprite(blockSpritesheet, location);
		public ISprite CreateCrackDoor(DoorLocation location) =>
			new CrackDoorSprite(blockSpritesheet, location);
		public ISprite CreateHoleWall(DoorLocation location) =>
			new HoleWallSprite(blockSpritesheet, location);
	}
}
