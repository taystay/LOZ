using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
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
