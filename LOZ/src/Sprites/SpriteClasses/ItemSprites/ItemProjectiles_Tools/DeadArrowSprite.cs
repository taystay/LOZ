using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class DeadArrowSprite : ItemSpriteAbstract
	{
		public DeadArrowSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(106, 246, 136 - 105, 274 - 245);
		}
		public override void Update(GameTime gameTime) { }
	}
}
