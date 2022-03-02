
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses.BlockSprites;
using LOZ.SpriteClasses;

namespace LOZ.Factories
{
    class DungeonFactory
    {
		private Texture2D blockSpritesheet;

		private static DungeonFactory instance = new DungeonFactory();

		public static DungeonFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private DungeonFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			blockSpritesheet = content.Load<Texture2D>("8376");
		}

		public ISprite GetExterior()
        {
			return new Exterior(blockSpritesheet);
        }



	}
}
