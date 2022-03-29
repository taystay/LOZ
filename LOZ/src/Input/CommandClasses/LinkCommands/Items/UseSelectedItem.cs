using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class UseSelectedItem : ICommand
    {
        private Room _room;
        public UseSelectedItem(Room room)
        {
            _room = room;
        }
        public void execute()
        {
            if (Room.RoomInventory.selectedItem == Room.RoomInventory.bombId)
                Room.Link.Attack(Weapon.Bomb);
            else if (Room.RoomInventory.selectedItem == Room.RoomInventory.bowId)
                Room.Link.Attack(Weapon.Arrow);
        }
    }
}