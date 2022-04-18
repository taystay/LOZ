using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class CompassSprite :ItemSpriteAbstract
	{
		public CompassSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(105, 56, 26, 31);
		}
		public override void Update(GameTime gameTime) { }
	
	}
}
