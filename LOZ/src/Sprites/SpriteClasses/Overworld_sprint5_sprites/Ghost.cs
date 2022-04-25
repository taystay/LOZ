using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    class GhostSprite : ISpriteRotatable
    {
		public GhostSprite(Texture2D texture)
        {
			_texture = texture;
            frames.Add(new Rectangle(88, 118, 19, 27));
            Scale = 1.0;
        }
	}
}
