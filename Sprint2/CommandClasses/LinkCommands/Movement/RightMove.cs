using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class RightMove :ICommand
    {
        public RightMove()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionRight();
            GameObjects.Instance.Link.Move();
        }
    }
}
