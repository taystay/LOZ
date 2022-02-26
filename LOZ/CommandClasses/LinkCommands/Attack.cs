using Sprint2.LinkClasses;
using LOZ.GameState;

namespace Sprint2.CommandClasses
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
