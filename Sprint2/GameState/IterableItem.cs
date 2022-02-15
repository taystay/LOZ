using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.ItemsClasses;

namespace Sprint2.GameState
{ 
    class IterableItem : IIterable
    {
        private List<IItem> items;
        private int itemIndex = 0;
        private Point itemLocations = new Point(700, 200);
        public IterableItem()
        {
            items = new List<IItem>()
            {
                { new ArrowItem(itemLocations) },
                { new Bow(itemLocations) },
                { new Clock(itemLocations) },
                { new Compass(itemLocations) },
                { new Fairy(itemLocations) },
                { new FireItem(itemLocations) },
                { new Heart(itemLocations) },
                { new HeartContainer(itemLocations) },
                { new Key(itemLocations) },
                { new Map(itemLocations) },
                { new Rupee(itemLocations) },
                { new Triforce(itemLocations) },
            };
        }

        public void SetToDefault()
        {
            itemIndex = 0;
        }

        public void IterateForward()
        {
            itemIndex++;
            if (itemIndex >= items.Count)
                itemIndex = 0;

        }
        public void IterateReverse()
        {
            itemIndex--;
            if (itemIndex < 0)
                itemIndex = items.Count - 1;
        }
        public void Update(GameTime gameTime)
        {
            items[itemIndex].Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            items[itemIndex].Draw(spriteBatch);
        }

    }
}
