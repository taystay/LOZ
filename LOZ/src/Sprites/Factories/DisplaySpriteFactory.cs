
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses.DisplaySprites;
using LOZ.SpriteClasses;

namespace LOZ.Factories
{
    class DisplaySpriteFactory
    {
		private Texture2D HUDSpritesheet;

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
		}

		public ISprite CreateHUDSprite()
		{
			return new HUDSprite(HUDSpritesheet);
		}


	}
}
