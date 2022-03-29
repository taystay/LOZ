using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class AttackSword : ICommand
    {
        private Room _room;
        public AttackSword(Room room)
        {
            _room = room;
        }
        public void execute()
        {       
            if (!Room.RoomInventory.hasSword) return;

            if (Room.Link.Health == Room.Link.MaxHealth)
                Room.Link.Attack(Weapon.Swordbeam);
            else
                Room.Link.Attack(Weapon.Default);
        }
    }
}