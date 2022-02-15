using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.LinkClasses;


namespace Sprint2.GameState
{
    class GameObjects
    {
        public static IIterable Items { get; set; }
        public static IIterable Enemies { get; set; }
        public static IIterable Blocks { get; set; }
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
            Items = new IterableItem();
            Enemies = new IterableEnemy();
            Blocks = new IterableBlock();
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
            Items.Update(gameTime);
            Enemies.Update(gameTime);
            Blocks.Update(gameTime);
        }
		public void DrawObjects(SpriteBatch spriteBatch)
        {
            Link.Draw(spriteBatch);
            foreach (IItem item in LinkItems)
            {
                item.Draw(spriteBatch);
            }
            Items.Draw(spriteBatch);
            Enemies.Draw(spriteBatch);
            Blocks.Draw(spriteBatch);
        }
	}
}
