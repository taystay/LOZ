using Sprint2.LinkClasses;
using LOZ.GameState;

namespace Sprint2.CommandClasses
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
            _room.Link.Attack(Weapon.Swordbeam);
        }
    }
}