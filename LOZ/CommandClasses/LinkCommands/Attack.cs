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
            CurrentRoom.Instance.Room.Link.Attack(Weapon.Default);
        }
    }
}
