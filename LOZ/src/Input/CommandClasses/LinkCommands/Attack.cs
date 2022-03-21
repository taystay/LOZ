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
            Room.Link.Attack(Weapon.Default);
        }
    }
}
