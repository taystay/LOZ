using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.BlockSprites
{
    class CrackDoorSprite : AbstractDungeon
	{
		public CrackDoorSprite(Texture2D texture, DoorLocation number)
		{
			int offset = DungeonInfo.DoorWidth / 3 + 1;
			scale = 3.0;
			_texture = texture;
			switch (number)
			{
				case DoorLocation.Top:
					frame = new Rectangle(848 + 2* offset, 11, 879 - 847, 42 - 10);
					break;
				case DoorLocation.Right:
					frame = new Rectangle(848 + 2*offset, 44, 879 - 847, 42 - 10);
					break;
				case DoorLocation.Left:
					frame = new Rectangle(848 + 2* offset, 77, 879 - 847, 42 - 10);
					break;
				default:
					frame = new Rectangle(848 + 2*offset, 110, 879 - 847, 42 - 10);
					break;
			}
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
