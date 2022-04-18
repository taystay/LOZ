using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.BlockSprites
{
    class ExteriorSprite : AbstractDungeon
	{
		public ExteriorSprite(Texture2D texture)
		{
			scale = 3.0;
			_texture = texture;
			frame = new Rectangle(521, 11, 776 - 521 + 1,  186 - 11 + 1);

		}
		public override void Update(GameTime gameTime) { }
	}
}
