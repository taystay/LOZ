using LOZ.LinkClasses;
using LOZ.GameStateReference;
using LOZ.ItemsClasses;



namespace LOZ.CommandClasses
{
    class AttackSword : ICommand
    {
        private Game1 _gameObject;
        public AttackSword(Game1 gameObject) =>
            _gameObject = gameObject;
        public void execute()
        {
                if (!RoomReference.GetInventory().HasItem(typeof(Sword))) return;
                if (RoomReference.GetLink().Health >= RoomReference.GetLink().MaxHealth)
                    RoomReference.GetLink().Attack(Weapon.Swordbeam);
                else
                    RoomReference.GetLink().Attack(Weapon.Default);
        }
    }
}