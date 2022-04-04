using LOZ.LinkClasses;
using LOZ.GameState;



namespace LOZ.CommandClasses
{
    class AttackSword : ICommand
    {
        private Game1 _gameObject;
        public AttackSword(Game1 gameObject)
        {
            _gameObject = gameObject;
        }
        public void execute()
        {
            if (_gameObject.state != CameraState.Paused && _gameObject.state != CameraState.Pausing)
            {
                if (!Room.RoomInventory.hasSword) return;

                if (Room.Link.Health == Room.Link.MaxHealth)
                    Room.Link.Attack(Weapon.Swordbeam);
                else
                    Room.Link.Attack(Weapon.Default);
            }
        }
    }
}