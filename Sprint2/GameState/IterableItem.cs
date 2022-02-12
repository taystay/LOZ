using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class IterableItem : IIterable
    {
        private List<IItem> items;
        private int itemIndex = 0;
        private double scale = 1;
        private Point itemLocations = new Point(700, 200);
        public IterableItem()
        {
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
