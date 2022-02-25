using Sprint2.LinkClasses;

namespace Sprint2.CommandClasses
{
    class AttackBomb :ICommand
    {
        private ILink link;
        public AttackBomb(ILink Link)
        {
            link = Link;
        }
        public void execute()
        {
            link.Attack(Weapon.Bomb);
        }
    }
}
