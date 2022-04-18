using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class SwordBeamRightSprite : ItemSpriteAbstract
	{
		public SwordBeamRightSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(156,161,181 - 155,174 - 160);
		}
		public override void Update(GameTime gameTime) { }
	}
}
