using Sprint2.LinkClasses;
using LOZ.GameState;

namespace Sprint2.CommandClasses
{
    class AttackArrow :ICommand
    {
        private Room _room;
        public AttackArrow(Room room)
        {
            _room = room;
        }
        public void execute()
        {
            _room.Link.Attack(Weapon.Arrow);
        }
    }
}
