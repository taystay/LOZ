using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class MainMenu : ISprite
	{
		private Texture2D _texture;
		private Rectangle ActualMenu;
		int menuWidth;
		int menuHeight;

		public MainMenu(Texture2D texture)
		{
			_texture = texture;
			ActualMenu = new Rectangle(0, 0, 256, 240);
			menuWidth = Info.screenWidth;
            menuHeight = (int)(((double)ActualMenu.Height / (double)ActualMenu.Width) * menuWidth);
		}
		public void Update(GameTime gameTime) { }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			Rectangle menuDestination = new Rectangle(location.X - menuWidth / 2, location.Y - menuHeight / 2 ,menuWidth , menuHeight);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);	
			spriteBatch.Draw(_texture, menuDestination, ActualMenu, c);
			spriteBatch.End();
		}
	}
}
