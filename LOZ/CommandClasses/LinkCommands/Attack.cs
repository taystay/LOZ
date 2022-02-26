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
            TestingRoom.Instance.Link.Attack(Weapon.Default);
        }
    }
}
