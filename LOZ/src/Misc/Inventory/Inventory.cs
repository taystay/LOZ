using System;
using System.Collections.Generic;
using System.Text;
using LOZ.Collision;
using LOZ.ItemsClasses;

namespace LOZ.Inventory
{
    public class LinkInventory
    {
        public List<IGameObjects> useItems { get; set; }
        public bool hasMap { get; set; } = false;
        private itemCount countableItems;
        public LinkInventory()
        {
            useItems = new List<IGameObjects>();
            countableItems = new itemCount(20, 0, 5);
        }

        public itemCount getItemCounts()
        {
            return countableItems;
        }

        public void AddItem(IGameObjects item)
        {
            if (TypeC.Check(item, typeof(Key)))
            {
                countableItems.keys++;
            }
            else if (TypeC.Check(item, typeof(Map)))
            {
                hasMap = true;
            }
            else if (TypeC.Check(item, typeof(ArrowItem)))
            {
                useItems.Add(item);
            }
            else if (TypeC.Check(item, typeof(ArrowItem)))
            {
                useItems.Add(item);
            } 
            else if (TypeC.Check(item, typeof(Rupee)))
            {
                countableItems.rupees++;
            }
        }

        public void UseRupee(int count)
        {
            countableItems.rupees -= count;
        }

        public void UseBomb()
        {
            countableItems.bombs--;
        }

        public void UseKey()
        {
            countableItems.keys--;
        }
    }
}
