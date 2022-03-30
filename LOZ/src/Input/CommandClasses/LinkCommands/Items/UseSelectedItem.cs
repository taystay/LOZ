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
            if (Room.RoomInventory.selectedItem == Room.RoomInventory.bombId && Room.RoomInventory.hasBomb)
                Room.Link.Attack(Weapon.Bomb);
            else if (Room.RoomInventory.selectedItem == Room.RoomInventory.bowId && Room.RoomInventory.hasBow && Room.RoomInventory.getItemCounts().rupees > 0)
                Room.Link.Attack(Weapon.Arrow);
        }
    }
}