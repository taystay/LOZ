using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class RightMove :ICommand
    {
        private Game1 gameObject;
        public RightMove(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
            GameObjects.LinkState.ChangeDirectionRight();
            GameObjects.LinkState.Move();
        }
    }
}
