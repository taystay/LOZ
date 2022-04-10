using LOZ.LinkClasses;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class AttackArrow :ICommand
    {
        private CurrentRoom _room;
        public AttackArrow(CurrentRoom room)
        {
            _room = room;
        }
        public void execute()
        {
            CurrentRoom.link.Attack(Weapon.Arrow);
        }
    }
}
