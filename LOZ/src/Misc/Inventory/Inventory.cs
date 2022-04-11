using System.Collections.Generic;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.Sound;
using Microsoft.Xna.Framework;

namespace LOZ.Inventory
{

    public class LinkInventory
    {
        #region items
        public List<IGameObjects> inventory { get; set;}
        public int bombCount { get; set; }
        public int rupeeCount { get; set; }
        public int keyCount { get; set; }
        public int currentItem { get; set; } = 0;
        #endregion

        public LinkInventory()
        {
            inventory = new List<IGameObjects>();
            bombCount = 0;
            rupeeCount = 0;
            keyCount = 0;
        }
        public void Initialize()
        {
            inventory = new List<IGameObjects>();
            bombCount = 0;
            rupeeCount = 0;
            keyCount = 0;
            currentItem = 0;
            if(bombCount > 0)
                inventory.Add(new Bomb(new Point()));
            if(rupeeCount > 0)
                inventory.Add(new Rupee(new Point()));
            if(keyCount > 0)
                inventory.Add(new Key(new Point()));
        }
        public void NextItem()
        {
            if (inventory.Count == 0)
            {
                currentItem = -1;
                return;
            }
                
            for (int i = 0; i < 5 && i < inventory.Count; i++)
            {
                currentItem++;
                if (currentItem > inventory.Count - 1)
                    currentItem = 0;
                if (isInventoryItem(inventory[currentItem]))
                {
                    return;
                }
            }
            currentItem = -1;
        }
        public bool isInventoryItem(IGameObjects item)
        {
            IItem o = (IItem)item;
            return o.InventoryItem;
        }
        public bool IsCurrentItem(IGameObjects item)
        {
            return (inventory.IndexOf(item) == currentItem);
        }         
        public void AddItem(IGameObjects item)
        {
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            if(!HasItem(item.GetType()))
                inventory.Add(item);

            if (TypeC.Check(item, typeof(Rupee)))
                rupeeCount++;
            if (TypeC.Check(item, typeof(Key)))
                keyCount++;
        }
        private void SelectType(System.Type itemType)
        {
            foreach(IGameObjects item in  inventory)
            {
                if (TypeC.Check(item, itemType))
                    currentItem = inventory.IndexOf(item);
            }
        }
        private bool UseItem(System.Type itemType)
        {
            for (int i = inventory.Count - 1; i >= 0; i--)
            {
                IGameObjects item = inventory[i];
                if (TypeC.Check(item, itemType))
                {
                    if (currentItem >= i)
                        currentItem--;
                    inventory.RemoveAt(i);
                    SelectType(itemType);
                    if(currentItem < 0 || currentItem >= inventory.Count)
                        NextItem();
                    return true; //item found
                }
            }
            return false; //item not there
        }
        public bool HasItem(System.Type type)
        {
            foreach(IGameObjects item in  inventory)
            {
                if (TypeC.Check(item, type))
                    return true;
            }
            return false;
        }
        public void UseRupee()
        {
            rupeeCount--;
            if (rupeeCount <= 0)
                UseItem(typeof(Rupee));
        }
        public void UseBomb()
        {
            bombCount--;
            if (bombCount <= 0)
                UseItem(typeof(Bomb));
        }
        public void UseKey()
        {
            keyCount--;
            if (keyCount <= 0)
                UseItem(typeof(Key));
        }
    }
}
