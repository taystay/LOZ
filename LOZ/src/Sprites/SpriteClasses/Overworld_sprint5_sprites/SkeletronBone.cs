using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    class SkeletronBone : ISpriteRotatable
    {
		public SkeletronBone(Texture2D texture, bool leftHand)
        {
			_texture = texture;
            if(leftHand)
			    frames.Add(new Rectangle(25, 27, 28, 10));
            else
                frames.Add(new Rectangle(25, 47, 28, 10));
        }
	}
}
