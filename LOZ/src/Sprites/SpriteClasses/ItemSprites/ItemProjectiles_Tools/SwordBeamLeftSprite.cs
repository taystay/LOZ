using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class SwordBeamLeftSprite : ItemSpriteAbstract
	{
		public SwordBeamLeftSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(58, 159, 82 - 57, 172 - 158);
		}
		public override void Update(GameTime gameTime) {  }
	}
}
