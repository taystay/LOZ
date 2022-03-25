using System.Collections.Generic;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.Sound;

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
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(Map)))
            {
                hasMap = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(ArrowItem)))
            {
                useItems.Add(item);
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(ArrowItem)))
            {
                useItems.Add(item);
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            } 
            else if (TypeC.Check(item, typeof(Rupee)))
            {
                countableItems.rupees++;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Rupee);
            }
        }

        public void UseRupee(int count)
        {
            countableItems.rupees -= count;
        }

        public void UseBomb()
        {
            countableItems.bombs--;
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Bomb_Drop);
        }

        public void UseKey()
        {
            countableItems.keys--;
        }
    }
}
