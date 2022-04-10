using LOZ.LinkClasses;
using LOZ.GameState;
//using LOZ.Room;

namespace LOZ.CommandClasses
{
    class AttackArrow :ICommand
    {
        private OldRoom _room;
        public AttackArrow(OldRoom room)
        {
            _room = room;
        }
        public void execute()
        {
            OldRoom.Link.Attack(Weapon.Arrow);
        }
    }
}
