using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    class SkeletronHand : ISpriteRotatable
    {
		public SkeletronHand(Texture2D texture, bool leftHand)
        {
			_texture = texture;
            if(leftHand)
			    frames.Add(new Rectangle(55, 26, 15, 15));
            else
                frames.Add(new Rectangle(55, 43, 15, 15));
        }
	}
}
