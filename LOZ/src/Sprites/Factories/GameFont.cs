
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.SpriteClasses.BlockSprites;
using LOZ.SpriteClasses;

namespace LOZ.Factories
{
    class GameFont
    {
		private SpriteFont font;
		private static GameFont instance = new GameFont();
		public static GameFont Instance { get{return instance;} }
		private GameFont() { }
		public void LoadAllTextures(ContentManager content) => font = content.Load<SpriteFont>("File");	
		public void Write(SpriteBatch spriteBatch, string s, int x, int y)
		{
			spriteBatch.Begin();
			spriteBatch.DrawString(font, s, new Vector2(x, y), Color.White);
			spriteBatch.End();
		}
	}
}
