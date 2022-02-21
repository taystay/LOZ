using Sprint2.LinkClasses;

namespace Sprint2.CommandClasses
{
    class AttackFire :ICommand
    {
        private ILink link;
        public AttackFire(ILink Link)
        {
            link = Link;
        }
        public void execute()
        {
            link.Attack(Weapon.Fire);
        }
    }
}
