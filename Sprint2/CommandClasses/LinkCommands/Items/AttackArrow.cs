using Sprint2.LinkClasses;

namespace Sprint2.CommandClasses
{
    class AttackArrow :ICommand
    {
        private ILink link;
        public AttackArrow(ILink Link)
        {
            link = Link;
        }
        public void execute()
        {
            link.Attack(Weapon.Arrow);
        }
    }
}
