using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class BowSprite : ItemSpriteAbstract
	{ 
		public BowSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(159, 104, 176 - 158, 131 - 103);
		}
		public override void Update(GameTime gameTime) { }
		
	}
}
