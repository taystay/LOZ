using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class SwordSprite : ItemSpriteAbstract
	{ 
		public SwordSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(261, 243, 11, 28);
		}
		public override void Update(GameTime gameTime) { }
		
	}
}
