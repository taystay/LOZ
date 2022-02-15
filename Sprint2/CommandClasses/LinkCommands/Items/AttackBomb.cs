using Microsoft.Xna.Framework;
using Sprint2.ItemsClasses.Projectile_tools;
using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class AttackBomb :ICommand
    {
        private Point linkPosition;
        private double scale = 1;
        public AttackBomb()
        {
            linkPosition = GameObjects.Instance.Link.GetPosition();
        }
        public void execute()
        {
            GameObjects.Instance.LinkItems.Add(new Bomb(linkPosition, scale));
        }
    }
}
