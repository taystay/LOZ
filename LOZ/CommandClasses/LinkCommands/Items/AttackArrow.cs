using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.CommandClasses
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
           Room.Link.Attack(Weapon.Arrow);
        }
    }
}
