using Sprint2.LinkClasses;

namespace Sprint2.CommandClasses
{
    class AttackSword :ICommand
    {
        private ILink link;
        public AttackSword(ILink Link)
        {
            link = Link;
        }
        public void execute()
        {
            link.Attack(Weapon.Swordbeam);
        }
    }
}
