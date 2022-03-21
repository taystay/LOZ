using System;
using System.Collections.Generic;
using System.Text;
using LOZ.Collision;

namespace LOZ.src.Misc.Inventory
{
    class Inventory
    {
        private List<IGameObjects> objectsHeld;
        private itemCount countableItems;
        public Inventory()
        {
            objectsHeld = new List<IGameObjects>();
            countableItems = new itemCount(20, 0, 0);
        }
        public List<IGameObjects> getInventoryItems()
        {
            return objectsHeld;
        }

        public itemCount getItemCounts()
        {
            return countableItems;
        }

        public void AddItem(IGameObjects item)
        {
            if(TypeC.Check(item, null))
            {
                countableItems.bombs++;
            }
            objectsHeld.Add(item);
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
