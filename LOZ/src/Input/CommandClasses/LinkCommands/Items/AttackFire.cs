using LOZ.LinkClasses;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class AttackFire : ICommand
    {
        private CurrentRoom _room;
        public AttackFire(CurrentRoom room)
        {
            _room = room;
        }
        public void execute()
        {
            CurrentRoom.link.Attack(Weapon.Fire);
        }
    }
}