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
        private static List<IIterable> iterableObjects;
        public static List<IIterable> IterableObjects
        {
            get
            {
                return iterableObjects;
            }
        }
        private List<IItem> linkItems;
        private static ILink link;
        private static Boolean damaged;
        public static ILink Link
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
        public static Boolean Damaged
        {
            get
            {
                return damaged;
            }
            set
            {
                damaged = value;
            }
        }
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
		public void LoadObjects(ContentManager Content)
        {
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            link = new Link(new Point(500,500));
            iterableObjects = new List<IIterable>()
            {
                {new IterableItem()},
                {new IterableEnemy()},
                {new IterableBlock()},
            };
            linkItems = new List<IItem>();
        }
        //--------------Core Functionality-------------------
		public void UpdateObjects(GameTime gameTime)
        {
            link.Update(gameTime);
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
            foreach(IIterable item in iterableObjects)
            {
                item.Update(gameTime);
            }
        }
		public void DrawObjects(SpriteBatch spriteBatch)
        {
            link.Draw(spriteBatch);
            foreach (IItem item in linkItems)
            {
                item.Draw(spriteBatch);
            }
            foreach(IIterable item in iterableObjects)
            {
                item.Draw(spriteBatch);
            }
        }
	}
}
