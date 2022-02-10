using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class GameObjects
    {
        //----------ITEMS
		private static List<IItem> items;
		private static GameObjects instance = new GameObjects();
        private static int itemIndex = 0;

        //-----------LINK
        
        public static int ItemIndex
        {
            get
            {
                return itemIndex;
            }
            set
            {
                itemIndex = value;
            }
        }

        private Point itemLocations = new Point(500, 500);

		public static GameObjects Instance
		{
			get
			{
				return instance;
			}
		}

		private GameObjects()
		{
			items = new List<IItem>();
		}

		public void SpawnItem(IItem item)
        {
			items.Add(item);
        }

		public void AddSprint2Items()
        {
			double scale = 3.0;
            items = new List<IItem>()
            {
                { new ArrowItem(itemLocations, scale) },
                { new Bow(itemLocations, scale) },
                { new Clock(itemLocations, scale) },
                { new Compass(itemLocations, scale) },
                { new Fairy(itemLocations, scale) },
                { new FireItem(itemLocations, scale) },
                { new Heart(itemLocations, scale) },
                { new HeartContainer(itemLocations, scale) },
                { new Key(itemLocations, scale) },
                { new Map(itemLocations, scale) },
                { new Rupee(itemLocations, scale) },
                { new Triforce(itemLocations, scale) },
            };
        }

		public void UpdateItems(GameTime gameTime)
        {
            if (itemIndex >= items.Count)
                itemIndex = 0;
            if (itemIndex < 0)
                itemIndex = items.Count - 1;
            items[itemIndex].Update(gameTime);
        }

		public void DrawItems(SpriteBatch spriteBatch)
        {
            items[itemIndex].Draw(spriteBatch);
        }
	}
}
