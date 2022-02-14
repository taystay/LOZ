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
        public static List<IIterable> IterableObjects { get; set; }
        public List<IItem> LinkItems { get; set; }
        public ILink Link { get; set; }
        public bool Damaged { get; set; }
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
            Link = new Link(new Point(500,500));
            IterableObjects = new List<IIterable>()
            {
                {new IterableItem()},
                {new IterableEnemy()},
                {new IterableBlock()},
            };
            LinkItems = new List<IItem>();
        }
        //--------------Core Functionality-------------------
		public void UpdateObjects(GameTime gameTime)
        {
            Link.Update(gameTime);
            int i = 0;
            while (i < LinkItems.Count)
            {
                IItem item = LinkItems[i];
                item.Update(gameTime);
                if (!item.SpriteActive())
                {
                    LinkItems.RemoveAt(i);
                    continue;
                }
                i++;
            }
            foreach(IIterable item in IterableObjects)
            {
                item.Update(gameTime);
            }
        }
		public void DrawObjects(SpriteBatch spriteBatch)
        {
            Link.Draw(spriteBatch);
            foreach (IItem item in LinkItems)
            {
                item.Draw(spriteBatch);
            }
            foreach(IIterable item in IterableObjects)
            {
                item.Draw(spriteBatch);
            }
        }
	}
}
