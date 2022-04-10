using LOZ.LinkClasses;
using LOZ.Room;
using LOZ.Inventory;
using LOZ.ItemsClasses;
using LOZ.Collision;

namespace LOZ.CommandClasses
{
    class UseSelectedItem : ICommand
    {
        private Game1 _gameObject;
        public UseSelectedItem(Game1 gameObject)
        {
            _gameObject = gameObject;
        }
        public void execute()
        {
            LinkInventory inv = RoomReference.GetInventory();
            int BItemIdx = inv.currentItem;
            if (BItemIdx < 0) return;
            if(TypeC.Check(inv.inventory[BItemIdx], typeof(Bomb)))
                RoomReference.GetLink().Attack(Weapon.Bomb);
            else if (TypeC.Check(inv.inventory[BItemIdx], typeof(Bow)) && inv.rupeeCount > 0)
                RoomReference.GetLink().Attack(Weapon.Arrow);
            else if (TypeC.Check(inv.inventory[BItemIdx], typeof(PortalGun)))
                RoomReference.GetLink().Attack(Weapon.Portal);
            
        }
    }
}