using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class MapSprite : ItemSpriteAbstract
	{
		public MapSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(303, 108, 18, 27);
		}
		public override void Update(GameTime gameTime) { }
	}
}
