using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.CommandClasses
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
            CurrentRoom.Instance.Room.Link.Attack(Weapon.Bomb);
        }
    }
}