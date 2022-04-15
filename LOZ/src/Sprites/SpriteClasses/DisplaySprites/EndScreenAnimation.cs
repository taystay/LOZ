﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.GameStateReference;
using LOZ.ItemsClasses;
using LOZ.Sound;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class EndScreenAnimation : ISprite
	{
		private Texture2D _texture;
		private MapWalkWay leftBorder, rightBorder;
		int lefty = Info.screenHeight / 2 + 300, righty = Info.screenHeight / 2 + 300;
		int leftx = 100, rightx = 870;
		private IItem triforce= null;
		private bool linkGotUpdate = false;
		private int numberOfUpdates = 0;
		private int maxUpdates = 500;
		private bool soundPlayed = false;

		public EndScreenAnimation(Texture2D texture)
		{
			_texture = texture;
			
			leftBorder = new MapWalkWay(texture, 50, Info.screenHeight * 3);
			rightBorder = new MapWalkWay(texture, 50, Info.screenHeight * 3);
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
			if (numberOfUpdates >= maxUpdates) return;
			int change = 3;
			rightBorder.IncreaseWidth(change);
			leftBorder.IncreaseWidth(change);
			if(triforce != null)
				triforce.Update(gameTime);
        }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Draw(spriteBatch, location, Color.Blue);
		}

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			leftBorder.Draw(spriteBatch, new Point(leftx, lefty), Color.Black);
			rightBorder.Draw(spriteBatch, new Point(rightx, righty), Color.Black);
			RoomReference.GetLink().Draw(spriteBatch);
			if (triforce != null)
				triforce.Draw(spriteBatch);
		}
	}
}
