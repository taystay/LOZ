using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class UpMove :ICommand
    {
        public UpMove()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionUp();
            GameObjects.Instance.Link.Move();
        }
    }
}
