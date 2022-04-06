
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
		}
		public ISprite CreateEndScreen()
        {
			return new EndScreenAnimation(HUDSpritesheet);
        }
		public ISprite CreateSelectItemSprite()
        {
			return new SelectItemSprite(HUDSpritesheet);
		}

		public ISprite CreateTriforceIndicator()
		{
			return new TriforceIndicator(HUDSpritesheet);
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
	}
}
