using Sprint2.LinkClasses;
using LOZ.GameState;

namespace Sprint2.CommandClasses
{
    class AttackBomb : ICommand
    {
        private Room _room;
        public AttackBomb(Room room)
        {
            _room = room;
        }
        public void execute()
        {
            _room.Link.Attack(Weapon.Bomb);
        }
    }
}