using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.BlockSprites
{
    class Exterior : AbstractDungeon
	{
		public Exterior(Texture2D texture)
		{
			scale = 3.0;
			_texture = texture;
			frame = new Rectangle(521, 11, 776 - 521 + 1,  186 - 11 + 1);
			
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime) { }
	}
}
