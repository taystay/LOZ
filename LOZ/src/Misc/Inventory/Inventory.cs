using System;
using System.Collections.Generic;
using System.Text;
using LOZ.Collision;
using LOZ.ItemsClasses;

namespace LOZ.src.Misc.Inventory
{
    class LinkInventory
    {
        public List<LinkItems> linkItemsHeld { get; set; } // maybe make it ISprites so then you can just draw the sprite that is selected instead. ??
        private List<IGameObjects> objectsHeld;
        private itemCount countableItems;
        public LinkInventory()
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
            if(TypeC.Check(item, typeof(ArrowItem)))
            {
                linkItemsHeld.Add(LinkItems.Arrow);
            } 
            else if (TypeC.Check(item, typeof(FireItem)))
            {
                linkItemsHeld.Add(LinkItems.Fire);
            }
            else if (TypeC.Check(item, typeof(FireItem)))
            {
                linkItemsHeld.Add(LinkItems.Fire);
            }
            else if (TypeC.Check(item, typeof(Bomb)))
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
