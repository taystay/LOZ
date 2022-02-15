using Sprint2.GameState;
using Sprint2.ItemsClasses.Projectile_tools;
using Microsoft.Xna.Framework;

namespace Sprint2.CommandClasses
{
    class AttackSword :ICommand
    {
        private Point linkPosition;
        private double scale = 1;
        public AttackSword()
        {
            linkPosition = GameObjects.Instance.Link.GetPosition();
        }
        public void execute()
        {
            GameObjects.Instance.LinkItems.Add(new SwordBeamDown(linkPosition, scale));
        }
    }
}
