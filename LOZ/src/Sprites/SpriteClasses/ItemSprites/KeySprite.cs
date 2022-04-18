using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class KeySprite : ItemSpriteAbstract
	{
		public KeySprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(62, 9, 20, 30);
		}
		public override void Update(GameTime gameTime) { }		
	}
}
