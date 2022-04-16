using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.GameStateReference;
using LOZ.ItemsClasses;
using LOZ.Sound;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class VictoryScreen : ISprite
	{
		private Texture2D _texture;
		private Rectangle leftBorder, rightBorder;
		private IItem triforce= null;
		private bool linkGotUpdate = false;
		private int numberOfUpdates = 0;
		private int maxUpdates = 1125, middleUpdates = 600;
		private bool soundPlayed = false;
		private int offsetToMiddle = 600, offsetDown = 0;
		private Rectangle destL, destR;

		public VictoryScreen(Texture2D texture)
		{
			_texture = texture;

			leftBorder = new Rectangle(0, 0, 128, 240);
			rightBorder = new Rectangle(128, 0, 128, 240);
			destL = new Rectangle(0 - offsetToMiddle, 0, Info.screenWidth/2, Info.screenHeight);
			destR = new Rectangle(Info.screenWidth/2 + offsetToMiddle, 0, Info.screenWidth / 2, Info.screenHeight);
		}

		public void Update(GameTime gameTime)
        {
			if(numberOfUpdates < maxUpdates) numberOfUpdates++;
			
			if(triforce == null)
            {
				List<IGameObjects> objs = RoomReference.GetCurrRoom().GetObjectsList();
				foreach (IGameObjects item in objs)
				{
					if (TypeC.Check(item, typeof(Triforce)))
					{
						triforce = (IItem)item;
						triforce.KillItem();
						RoomReference.GetCurrRoom().Update(gameTime);
						triforce = new Triforce(new Point(Info.screenWidth / 2, Info.screenHeight / 2 - 48));
						break;
					}
				}
			}
			if(!soundPlayed)
            {
				SoundManager.Instance.SoundToPlayInstance(SoundEnum.win);
				SoundManager.Instance.SoundToNotLoop(SoundEnum.Background);
				soundPlayed = true;
			}
			if(!linkGotUpdate)
            {
				RoomReference.GetLink().ChangePosition(new Point(Info.screenWidth / 2, Info.screenHeight / 2));
				RoomReference.GetLink().Update(gameTime);
				linkGotUpdate = true;
            }
			if (numberOfUpdates < maxUpdates)
            {
				if (triforce != null)
					triforce.Update(gameTime);
				if (numberOfUpdates <= middleUpdates)
					offsetToMiddle -= 1;
				else
					offsetDown += 1;
			}
			if (numberOfUpdates >= maxUpdates) return;
			leftBorder = new Rectangle(0, 0 + offsetDown, 128, 240);
			rightBorder = new Rectangle(128, 0 + offsetDown, 128 , 240);
			destL = new Rectangle(0 - offsetToMiddle, 0, Info.screenWidth / 2, Info.screenHeight);
			destR = new Rectangle(Info.screenWidth / 2 + offsetToMiddle, 0, Info.screenWidth / 2, Info.screenHeight);
		}
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Draw(spriteBatch, location, Color.Blue);
		}

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destL, leftBorder, Color.White);
			spriteBatch.Draw(_texture, destR, rightBorder, Color.White);
			spriteBatch.End();
			if(numberOfUpdates <= middleUpdates)
				RoomReference.GetLink().Draw(spriteBatch);
			if (triforce != null)
				triforce.Draw(spriteBatch);
		}
	}
}
