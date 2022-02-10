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
        //-------------ITEMS--------------------
		private static List<IItem> items;
		
        private Point itemLocations = new Point(500, 500);
        private static int itemIndex = 0;
        public static int ItemIndex
        {
            get
            {
                return itemIndex;
            }
            set
            {
                itemIndex = value;
                if (itemIndex >= items.Count)
                    itemIndex = 0;
                if (itemIndex < 0)
                    itemIndex = items.Count - 1;
            }
        }

        //-----------Enviornment-------------
        private static List<IEnvironment> blocks;
        private Point blockLocation = new Point(500, 500);
        private static int blockIndex = 0;
        public static int BlockIndex
        {
            get
            {
                return blockIndex;
            }
            set
            {
                blockIndex = value;
                if (blockIndex >= blocks.Count)
                    blockIndex = 0;
                if (blockIndex < 0)
                    blockIndex = blocks.Count - 1;
            }
        }

        //----------LINK-----------------------
        private List<IItem> linkItems;



        //-----------Singleton Declaration!-------------
        private static GameObjects instance = new GameObjects();
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
            linkItems = new List<IItem>();
        }

        //-------------OBJECT FUNCTIONS---------------
		public void SpawnItem(IItem item)
        {
			items.Add(item);
        }
		public void PopulateObjects()
        {
			double scale = 3.0;
            blocks = new List<IEnvironment>()
            {
                { new BlueSandBlock(blockLocation, scale) },
                { new BlackTileBlock(blockLocation, scale) },
                { new BlueTriangleBlock(blockLocation, scale) },
                { new DarkBlueBlock(blockLocation, scale) },
                { new MulticoloredBlock1(blockLocation, scale) },
                { new MulticoloredBlock2(blockLocation, scale) },
                { new SolidBlueBlock(blockLocation, scale) },
                { new StairsBlock(blockLocation, scale) },
            };
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

        //--------------Core Functionality-------------------
		public void UpdateObjects(GameTime gameTime)
        {
            items[itemIndex].Update(gameTime);
            items[itemIndex].Update(gameTime);

            int i = 0;
            while (i < linkItems.Count)
            {
                IItem item = linkItems[i];
                item.Update(gameTime);
                if (!item.SpriteActive())
                {
                    linkItems.RemoveAt(i);
                    continue;
                }
                i++;
            }
        }
		public void DrawObjects(SpriteBatch spriteBatch)
        {
            blocks[blockIndex].Draw(spriteBatch);
            items[itemIndex].Draw(spriteBatch);

            foreach (IItem item in linkItems)
            {
                item.Draw(spriteBatch);
            }
        }
	}
}
