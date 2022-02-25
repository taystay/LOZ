using Sprint2.GameState;
using Sprint2.LinkClasses;

namespace Sprint2.CommandClasses
{
    class Attack :ICommand
    {
        public Attack()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.Attack(Weapon.Default);
        }
    }
}
