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
                idInUse %= 3 + 1;
                int i = 0;
                while (!HasItem(idInUse) && i < 3)
                {
                    i++;
                    idInUse++;
                    idInUse %= 3 + 1;
                }
                    
            }
        }
        public bool hasMap { get; private set; } = false;
        public bool hasCompass { get; private set; } = false;
        public bool hasBomb { get; private set; } = true;
        public int bombId { get; private set; } = 1;
        public bool hasBow { get; private set; } = false;
        public int bowId { get; private set; } = 2;
        public bool hasPortalGun { get; private set; } = false;
        public int gunId { get; private set; } = 3;
        public bool hasClock { get; private set; } = false;
        private int clockDuration = 400;
        private int clockTimeLeft = 400;
        public bool hasSword { get; private set; } = false;
        public bool hasTriforce { get; private set; } = false;
        #endregion

        public LinkInventory()
        {
            countableItems = new itemCount(20, 0, 5);
            selectedItem = 2;
        }

        public void Reset()
        {
            countableItems = new itemCount(20, 0, 5);
            selectedItem = 2;
            hasMap = false;
            hasCompass = false;
            hasBomb = true;
            hasBow = false;
            hasPortalGun = false;
            hasSword = false;
            hasTriforce = false;
        }

        public void Update(GameTime gameTime)
        {
            if(hasClock)
            {
                clockTimeLeft--;
                if (clockTimeLeft <= 0)
                {
                    hasClock = false;
                }
            }
        }

        public bool HasItem(int id) // has item available to draw in B Slot
        {
            if (id == bombId && hasBomb) return true;
            else if (id == bowId && hasBow) return true;
            else if (id == gunId && hasPortalGun) return true;
            return false;
        }

        public ISprite GetSpriteById(int id)
        {
            ISprite sprite = null;
            if (id == bombId)
                sprite = ItemFactory.Instance.CreateBombSprite();
            else if (id == bowId)
                sprite = ItemFactory.Instance.CreateBowSprite();
            else if (id == gunId)
                sprite = ItemFactory.Instance.CreatePortalGun();
            if (sprite != null)
                sprite.ChangeScale(1.5);
            return sprite;
        }

        public ISprite GetSelectedItemSprite()
        {
            ISprite sprite = null;
            if (selectedItem == bombId && hasBomb)
                sprite = ItemFactory.Instance.CreateBombSprite();
            else if (selectedItem == bowId && hasBow)
                sprite = ItemFactory.Instance.CreateBowSprite();
            else if (selectedItem == gunId && hasPortalGun)
                sprite = ItemFactory.Instance.CreatePortalGun();
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
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Fanfare);
            }
            else if (TypeC.Check(item, typeof(PortalGun)))
            {
                hasPortalGun = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Fanfare);
            }
            else if (TypeC.Check(item, typeof(Map)))
            {
                hasMap = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Fanfare);
            }
            else if (TypeC.Check(item, typeof(ArrowItem)))
            {
                countableItems.rupees++;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Item);
            }
            else if (TypeC.Check(item, typeof(Compass)))
            {
                hasCompass = true;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Fanfare);
            }
            else if (TypeC.Check(item, typeof(Heart)))
            {
                //Room.Link.Health += 2;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Heart);
            }
            else if (TypeC.Check(item, typeof(Clock)))
            {
                hasClock = true;
                clockTimeLeft = clockDuration;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Fanfare);
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
                hasTriforce = true;
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
