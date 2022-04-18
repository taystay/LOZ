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
		public static DisplaySpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}
		private DisplaySpriteFactory()
		{
		}
		public void LoadAllTextures(ContentManager content)
		{
			HUDSpritesheet = content.Load<Texture2D>("HUDLayout");
			tranparentB = content.Load<Texture2D>("transparentB");
			mainMenu = content.Load<Texture2D>("menuv2");
			black = content.Load<Texture2D>("Black");
			vic = content.Load<Texture2D>("VictoryScreen");
		}
		public ISprite GetIntroText()
        {
			return new IntroText(mainMenu);
        }
		public Texture2D getBlackFade()
        {
			return black;
        }
		public ISprite GetMainMenu()
        {
			return new MainMenu(mainMenu);
        }
		public ISprite CreateSelectItemSprite()
        {
			return new SelectItemSprite(HUDSpritesheet);
		}
		public ISprite CreateHUDSprite()
		{
			return new HUDSprite(HUDSpritesheet);
		}
		public ISprite CreateRoomOnMapSprite()
        {
			return new MapRoom(HUDSpritesheet);
        }
		public ISprite CreateDeadDisplay()
        {
			return new DeadDisplay(HUDSpritesheet);
        }
		public ISprite CreateBlueMapRoomSprite()
		{
			return new BlueMapRoom(HUDSpritesheet);
		}
		public ISprite CreateLinkIndicator()
		{
			return new linkLocationSprite(HUDSpritesheet);
		}
		public ISprite CreatePauseSprite()
        {
			return new PauseHudSprite(HUDSpritesheet);
        }
		public ISprite GetHudHeart(bool fullHeart)
        {
			return new HudHeart(HUDSpritesheet, fullHeart);
        }
		public ISprite GetMapWalk(int width, int height)
		{
			return new MapWalkWay(HUDSpritesheet, width, height);
		}
		public Texture2D TransparentBackground()
		{
			return tranparentB;
		}
		public ISprite GetVicScreen()
		{
			return new VictoryScreen(vic);
		}
	}
}
