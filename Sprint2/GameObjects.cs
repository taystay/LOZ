using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class GameObjects
    {
        //-------------ITEMS--------------------
		private static List<IItem> items;
        private Point itemLocations = new Point(700, 200);
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
        private Point blockLocation = new Point(700, 300);
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
        private static ILinkState link;

        public static ILinkState LinkState
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }
        }

        //----------ENEMIES-----------------------
        private IEnemy enemy;
        private List<IProjectile> projectiles;
        private static List<IEnemy> enemies;
        private static int enemyIndex = 0;
        public static int EnemeyIndex
        {
            get
            {
                return enemyIndex;
            }
            set
            {
                enemyIndex = value;
                if (enemyIndex >= enemies.Count)
                    enemyIndex = 0;
                if (enemyIndex < 0)
                    enemyIndex = enemies.Count - 1;
            }
        }

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
            
        }

        //-------------OBJECT FUNCTIONS---------------
		public void SpawnItem(IItem item)
        {
			items.Add(item);
        }

		public void LoadObjects(ContentManager Content)
        {
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            link = new Link(new Point(700, 400));
            linkItems = new List<IItem>();

            projectiles = new List<IProjectile>();
            enemies = new List<IEnemy>()
            {
                {new Dragon(new Point(700, 700), projectiles)},
                {new Skeleton(new Point(700, 700)) },
                {new Bat(new Point(700, 700)) },
                {new Jelly(new Point(700, 700)) },
                {new NPC(new Point(700,700))},
            };

            double scale = 2.0;
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
            int i = 0;
            //----LINK---
            link.Update(gameTime);
            //----ENEMY----
            enemies[enemyIndex].Update(gameTime);
            while (i < projectiles.Count)
            {
                IProjectile item = projectiles[i];
                item.Update(gameTime);
                if (!item.IsActive())
                {
                    projectiles.RemoveAt(i);
                    continue;
                }
                i++;
            }

            //----ITEM----
            items[itemIndex].Update(gameTime);
            items[itemIndex].Update(gameTime);

            //----LINK ITEM----
            i = 0;
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
            //----LINK---
            link.Draw(spriteBatch);

            //----ENEMY----
            enemies[enemyIndex].Draw(spriteBatch);
            foreach(IProjectile item in projectiles)
            {
                item.Draw(spriteBatch);
            }

            //----BLOCK----
            blocks[blockIndex].Draw(spriteBatch);

            //----ITEM----
            items[itemIndex].Draw(spriteBatch);

            //----LINK ITEM----
            foreach (IItem item in linkItems)
            {
                item.Draw(spriteBatch);
            }
        }
	}
}
