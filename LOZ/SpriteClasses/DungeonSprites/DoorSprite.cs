using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.BlockSprites
{
    class DoorSprite : AbstractDungeon
	{
		public DoorSprite(Texture2D texture, int number)
		{
			scale = 3.0;
			_texture = texture;
			switch (number)
			{
				case 1:
					frame = new Rectangle(848, 11, 879 - 847, 42 - 10);
					break;
				case 2:
					frame = new Rectangle(848, 44, 879 - 847, 42 - 10);
					break;
				case 3:
					frame = new Rectangle(848, 77, 879 - 847, 42 - 10);
					break;
				default:
					frame = new Rectangle(848, 110, 879 - 847, 42 - 10);
					break;
			}
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
