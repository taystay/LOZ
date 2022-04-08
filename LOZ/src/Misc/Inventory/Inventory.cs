using System.Collections.Generic;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.Sound;
using LOZ.SpriteClasses;
using LOZ.Factories;
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
            bombCount = 10;
            rupeeCount = 20;
            keyCount = 0;
            for (int i = 0; i < bombCount; i++)
                inventory.Add(new Bomb(new Point()));
            for (int i = 0; i < rupeeCount; i++)
                inventory.Add(new Rupee(new Point()));
            for (int i = 0; i < keyCount; i++)
                inventory.Add(new Key(new Point()));
        }

        public void NextItem()
        {
            currentItem++;
            if (currentItem > inventory.Count - 1)
                currentItem = 0;
            if (inventory.Count == 0)
                currentItem = -1;
        }

        public void AddItem(IGameObjects item)
        {
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
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
                    if (inventory.IndexOf(item) >= currentItem)
                        currentItem--;
                    inventory.RemoveAt(i);
                    SelectType(itemType);
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
            if (UseItem(typeof(Rupee)))
                rupeeCount--;
        }

        public void UseBomb()
        {
            if (UseItem(typeof(Bomb)))
                bombCount--;
        }

        public void UseKey()
        {
            if (UseItem(typeof(Key)))
                keyCount--;
        }
    }
}
