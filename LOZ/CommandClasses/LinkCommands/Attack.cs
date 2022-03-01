using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class Attack :ICommand
    {
        public Attack()
        {
        }
        public void execute()
        {
            CurrentRoom.Room.Link.Attack(Weapon.Default);
        }
    }
}
