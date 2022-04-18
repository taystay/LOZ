using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.BlockSprites
{
    class DoorSprite : AbstractDungeon
	{
		public DoorSprite(Texture2D texture, DoorLocation number)
		{
			scale = 3.0;
			_texture = texture;
			switch (number)
			{
				case DoorLocation.Top:
					frame = new Rectangle(848, 11, 879 - 847, 42 - 10);
					break;
				case DoorLocation.Left:
					frame = new Rectangle(848, 44, 879 - 847, 42 - 10);
					break;
				case DoorLocation.Right:
					frame = new Rectangle(848, 77, 879 - 847, 42 - 10);
					break;
				default:
					frame = new Rectangle(848, 110, 879 - 847, 42 - 10);
					break;
			}
		}
		public override void Update(GameTime gameTime) { }
	}
}
