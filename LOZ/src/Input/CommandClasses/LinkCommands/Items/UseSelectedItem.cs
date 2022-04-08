using LOZ.LinkClasses;
using LOZ.GameState;
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
            LinkInventory inv = Room.RoomInventory;
            int BItemIdx = inv.currentItem;
            if (BItemIdx < 0) return;
            if(TypeC.Check(inv.inventory[BItemIdx], typeof(Bomb)))
                Room.Link.Attack(Weapon.Bomb);
            else if (TypeC.Check(inv.inventory[BItemIdx], typeof(Bow)) && inv.rupeeCount > 0)
                Room.Link.Attack(Weapon.Arrow);
            else if (TypeC.Check(inv.inventory[BItemIdx], typeof(PortalGun)))
                Room.Link.Attack(Weapon.Portal);
            
        }
    }
}