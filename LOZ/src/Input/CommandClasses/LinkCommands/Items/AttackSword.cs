using LOZ.LinkClasses;
using LOZ.GameState;
using LOZ.ItemsClasses;



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

                if (!Room.RoomInventory.HasItem(typeof(Sword))) return;

                if (Room.Link.Health >= Room.Link.MaxHealth)
                    Room.Link.Attack(Weapon.Swordbeam);
                else
                    Room.Link.Attack(Weapon.Default);
        }
    }
}