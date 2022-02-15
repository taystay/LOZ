using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Sprint2.GameState;
using Sprint2.ItemsClasses.Projectile_tools;

namespace Sprint2.CommandClasses
{
    class AttackArrow :ICommand
    {
        private Point linkPosition;
        private double scale = 1;
        private List<IItem> linkItems;
        public AttackArrow(List<IItem> LinkItems)
        {
            linkItems = LinkItems;
            linkPosition = GameObjects.Instance.Link.GetPosition();
        }
        public void execute()
        {
            linkItems.Add(new ArrowDownItem(linkPosition, scale));
        }
    }
}
