using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class previousBlock : ICommand
    {
        public previousBlock()
        {
        }
        public void execute()
        {
            GameObjects.Blocks.IterateForward();
        }
    }
}
