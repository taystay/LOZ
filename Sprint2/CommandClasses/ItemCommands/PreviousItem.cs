using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class PreviousItem :ICommand
    {
        public PreviousItem()
        {
        }
        public void execute()
        {
            GameObjects.Items.IterateForward();
        }
    }
}
