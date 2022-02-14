using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class LeftMove :ICommand
    {
        public LeftMove()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionLeft();
            GameObjects.Instance.Link.Move();
        }
    }
}
