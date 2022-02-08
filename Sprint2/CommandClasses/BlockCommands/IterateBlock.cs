using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class IterateBlock : ICommand
    {
        Game1 GameObj;
        public IterateBlock(Game1 gameObj)
        {
            GameObj = gameObj;
        }
        public void execute()
        {
            GameObj.Block++;
        }
    }
}
