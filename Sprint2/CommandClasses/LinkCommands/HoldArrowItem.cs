using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class HoldArrowItem :ICommand
    {
        private Game1 gameObject;
        public HoldArrowItem(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
            GameObjects.HeldItem = null;
        }
    }
}
