using System.Collections.Generic;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.Sound;
using LOZ.SpriteClasses;
using LOZ.Factories;
using LOZ.GameState;

namespace LOZ.Inventory
{

    public class LinkInventory
    {

        private itemCount countableItems;

        #region items
        private int idInUse = 2; // B SLOT ITEM
        public int selectedItem { 
            get
            {
                return idInUse;
            }
            set
            {
                idInUse = value;
                idInUse %= 5 + 1;
                int i = 0;
                while (!HasItem(idInUse) && i < 6)
                {
                    i++;
                    idInUse++;
                    idInUse %= 5 + 1;
                }
                    
            }
        }
        public bool hasMap { get; private set; } = true;
        public int mapId { get; private set; } = 1; // get rid of id
        public bool hasCompass { get; private set; } = true;
        public int compassId { get; private set; } = 2; // get rid of id
        public bool hasBomb { get; private set; } = true;
        public int bombId { get; private set; } = 3;
        public bool hasBow { get; private set; } = true;
        public int bowId { get; private set; } = 4;
        public bool hasClock { get; private set; } = true;
        public int clockId { get; private set; } = 5; // get rid of id
        public bool hasSword { get; private set; } = true;
        #endregion

        public LinkInventory()
        {
            countableItems = new itemCount(20, 0, 5);
            selectedItem = 2;
        }

        public bool HasItem(int id) // has item available to draw in B Slot
        {
            if (id == mapId && hasMap) return true; //delete
            else if (id == compassId && hasCompass) return true;//delete
            else if (id == bombId && hasBomb) return true;
            else if (id == bowId && hasBow) return true;
            else if (id == clockId && hasClock) return true;//delete
            return false;
        }

        public ISprite GetSpriteById(int id)
        {
            ISprite sprite = null;
            if (id == compassId)
                sprite = ItemFactory.Instance.CreateCompassSprite();
            else if (id == bombId)
                sprite = ItemFactory.Instance.CreateBombSprite();
            else if (id == mapId)
                sprite = ItemFactory.Instance.CreateMapSprite();
            else if (id == bowId)
                sprite = ItemFactory.Instance.CreateBowSprite();
            else if (id == clockId)
                sprite = ItemFactory.Instance.CreateClockSprite();
            if (sprite != null)
                sprite.ChangeScale(1.5);
            return sprite;
        }

        public ISprite GetSelectedItemSprite()
        {
            ISprite sprite = null;
            if (selectedItem == compassId && hasCompass)
                sprite = ItemFactory.Instance.CreateCompassSprite();
            else if (selectedItem == bombId && hasBomb)
                sprite = ItemFactory.Instance.CreateBombSprite();
            else if (selectedItem == bowId && hasBow)
                sprite = ItemFactory.Instance.CreateBowSprite();
            else if (selectedItem == mapId && hasMap)
                sprite = ItemFactory.Instance.CreateMapSprite();
            else if (selectedItem == clockId && hasClock)
                sprite = ItemFactory.Instance.CreateClockSprite();
            if (sprite != null)
                sprite.ChangeScale(1.5);
            return sprite;
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
            else if (TypeC.Check(item, typeof(Sword)))
            {
                hasSword = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(Map)))
            {
                hasMap = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(ArrowItem)))
            {
                countableItems.rupees++;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(Compass)))
            {
                hasCompass = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(Heart)))
            {
                Room.Link.Health += 2;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Heart);
            }
            else if (TypeC.Check(item, typeof(Clock)))
            {
                hasClock = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Heart);
            }
            else if (TypeC.Check(item, typeof(Rupee)))
            {
                countableItems.rupees++;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Rupee);
            }
            else if (TypeC.Check(item, typeof(HeartContainer)))
            {
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(Triforce)))
            {
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Fanfare);
            }
            else if (TypeC.Check(item, typeof(Bow)))
            {
                hasBow = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Fanfare);
            }
            else
            {
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
        }
        public void UseRupee(int count)
        {
            countableItems.rupees -= count;
        }
        public void UseBomb()
        {
            countableItems.bombs--;
            if (countableItems.bombs == 0) hasBomb = false;
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Bomb_Drop);
        }
        public void UseKey()
        {
            countableItems.keys--;
        }
    }
}
