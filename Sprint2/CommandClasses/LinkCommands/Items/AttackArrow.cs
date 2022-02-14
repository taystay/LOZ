using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class AttackArrow :ICommand
    {
        private Game1 gameObject;
        private Point linkPosition;
        private double scale = 1;
        public AttackArrow(Game1 obj)
        {
            gameObject = obj;
            linkPosition = GameObjects.Instance.Link.GetPosition();
        }
        public void execute()
        {
            GameObjects.Instance.LinkItems.Add(new ArrowDownItem(linkPosition, scale));
        }
    }
}
