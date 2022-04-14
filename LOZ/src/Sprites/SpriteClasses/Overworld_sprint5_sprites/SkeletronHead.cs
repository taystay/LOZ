using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    class SkeletronHead : ISpriteRotatable
    {
		public SkeletronHead(Texture2D texture)
        {
			_texture = texture;
			frames.Add(new Rectangle(3, 27, 21, 29));
        }
	}
}
