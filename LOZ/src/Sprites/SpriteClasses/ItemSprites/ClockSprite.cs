using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class ClockSprite : ItemSpriteAbstract
	{ 
		public ClockSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(9, 6, 30, 35);
		}
		public override void Update(GameTime gameTime) { }	
	}
}
