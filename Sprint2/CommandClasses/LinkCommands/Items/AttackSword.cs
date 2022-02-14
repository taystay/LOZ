using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
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
