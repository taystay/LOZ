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
		private ISprite walkway;
		private Color background = new Color(0,255,255);
		private bool increasing = false;

		public MainMenu(Texture2D texture)
		{
			_texture = texture;
			ActualMenu = new Rectangle(0, 0, 256, 240);
			menuWidth = Info.screenWidth;
            menuHeight = (int)(((double)ActualMenu.Height / (double)ActualMenu.Width) * menuWidth);
			//walkway = Factories.DisplaySpriteFactory.Instance.GetMapWalk(menuWidth, menuHeight);

		}

		public void Update(GameTime gameTime)
        {

			//if (increasing && background.B >= 255)
			//	increasing = false;
			//if (!increasing && background.B <= 0)
			//	increasing = true;

			//if(increasing)
   //         {
			//	background.B++;
   //         } else
   //         {
			//	background.B--;
   //         }

        }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Draw(spriteBatch, location, Color.White);
		}

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			//walkway.Draw(spriteBatch, location, background);
			Rectangle menuDestination = new Rectangle(location.X - menuWidth / 2, location.Y - menuHeight / 2 ,menuWidth , menuHeight);
			
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
