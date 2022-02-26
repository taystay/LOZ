using Sprint2.LinkClasses;
using LOZ.GameState;

namespace Sprint2.CommandClasses
{
    class AttackFire : ICommand
    {
        private Room _room;
        public AttackFire(Room room)
        {
            _room = room;
        }
        public void execute()
        {
            _room.Link.Attack(Weapon.Fire);
        }
    }
}