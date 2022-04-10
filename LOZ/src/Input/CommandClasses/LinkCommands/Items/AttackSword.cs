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

                if (!OldRoom.RoomInventory.HasItem(typeof(Sword))) return;

                if (OldRoom.Link.Health >= OldRoom.Link.MaxHealth)
                    OldRoom.Link.Attack(Weapon.Swordbeam);
                else
                    OldRoom.Link.Attack(Weapon.Default);
        }
    }
}