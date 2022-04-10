using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class AttackFire : ICommand
    {
        private OldRoom _room;
        public AttackFire(OldRoom room)
        {
            _room = room;
        }
        public void execute()
        {
            OldRoom.Link.Attack(Weapon.Fire);
        }
    }
}