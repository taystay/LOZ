using LOZ.LinkClasses;
using LOZ.GameState;

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
            if (_gameObject.state != CameraState.Paused && _gameObject.state != CameraState.Pausing)
            {
                if (Room.RoomInventory.selectedItem == Room.RoomInventory.bombId && Room.RoomInventory.hasBomb)
                    Room.Link.Attack(Weapon.Bomb);
                else if (Room.RoomInventory.selectedItem == Room.RoomInventory.bowId && Room.RoomInventory.hasBow && Room.RoomInventory.getItemCounts().rupees > 0)
                    Room.Link.Attack(Weapon.Arrow);
                else if (Room.RoomInventory.selectedItem == Room.RoomInventory.gunId && Room.RoomInventory.hasPortalGun)
                {
                    Room.Link.Attack(Weapon.Portal);
                }
            }
        }
    }
}