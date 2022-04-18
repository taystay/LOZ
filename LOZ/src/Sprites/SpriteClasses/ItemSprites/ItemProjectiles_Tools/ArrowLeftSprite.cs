using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class ArrowLeftSprite :ItemSpriteAbstract
	{
		public ArrowLeftSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(200, 65, 233 - 199, 76 - 64);
		}
		public override void Update(GameTime gameTime) { }
	}
}
