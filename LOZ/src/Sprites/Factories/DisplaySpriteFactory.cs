using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses.DisplaySprites;
using LOZ.SpriteClasses;

namespace LOZ.Factories
{
    class DisplaySpriteFactory
    {
		private Texture2D HUDSpritesheet;
		private Texture2D tranparentB;
		private Texture2D mainMenu;
		private Texture2D black;
		private Texture2D vic;
		private static DisplaySpriteFactory instance = new DisplaySpriteFactory();
		public static DisplaySpriteFactory Instance {get => instance;}
		private DisplaySpriteFactory() { }
		public void LoadAllTextures(ContentManager content)
		{
			HUDSpritesheet = content.Load<Texture2D>("HUDLayout");
			tranparentB = content.Load<Texture2D>("transparentB");
			mainMenu = content.Load<Texture2D>("menuv2");
			black = content.Load<Texture2D>("Black");
			vic = content.Load<Texture2D>("VictoryScreen");
		}
		public ISprite GetIntroText() => new IntroText(mainMenu);
		public Texture2D getBlackFade() => black;
		public ISprite GetMainMenu() => new MainMenu(mainMenu);
		public ISprite CreateSelectItemSprite() => new SelectItemSprite(HUDSpritesheet);
		public ISprite CreateHUDSprite() => new HUDSprite(HUDSpritesheet);
		public ISprite CreateRoomOnMapSprite() => new MapRoom(HUDSpritesheet);
		public ISprite CreateDeadDisplay() => new DeadDisplay(HUDSpritesheet);
		public ISprite CreateBlueMapRoomSprite() => new BlueMapRoom(HUDSpritesheet);
		public ISprite CreateLinkIndicator() => new linkLocationSprite(HUDSpritesheet);
		public ISprite CreatePauseSprite() => new PauseHudSprite(HUDSpritesheet);
		public ISprite GetHudHeart(bool fullHeart) => new HudHeart(HUDSpritesheet, fullHeart);
		public ISprite GetMapWalk(int width, int height) => new MapWalkWay(HUDSpritesheet, width, height);
		public Texture2D TransparentBackground() => tranparentB;
		public ISprite GetVicScreen() => new VictoryScreen(vic);
	}
}
