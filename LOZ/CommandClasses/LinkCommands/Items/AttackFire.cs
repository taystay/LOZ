using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.CommandClasses
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