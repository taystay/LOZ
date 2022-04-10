using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class IntroText : ISprite
	{
		private Texture2D _texture;
		private Rectangle ActualMenu;
		private int menuWidth;
		private int menuHeight;

		public IntroText(Texture2D texture)
		{
			_texture = texture;

			ActualMenu = new Rectangle(14, 242, 241 - 13, 441 - 243);
			menuWidth = Info.screenWidth;
			menuHeight = (int)(((double)ActualMenu.Height / (double)ActualMenu.Width) * menuWidth);
		}

		public void Update(GameTime gameTime)
        {

        }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Draw(spriteBatch, location, Color.White);
		}

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			//Rectangle destinationRectangle;

			//--------FRAME 1---------
			Rectangle menuDestination = new Rectangle(location.X - menuWidth / 2, location.Y - menuHeight / 2, menuWidth, menuHeight);

			//for SpriteBatch.Begin(...)
			//the paramater idea was from:
			//https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
			//https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, menuDestination, ActualMenu, c);
			spriteBatch.End();
		}
	}
}
