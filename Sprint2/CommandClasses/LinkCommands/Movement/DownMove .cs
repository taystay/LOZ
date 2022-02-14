using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class DownMove :ICommand
    {
        public DownMove()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionDown();
            GameObjects.Instance.Link.Move();
        }
    }
}
