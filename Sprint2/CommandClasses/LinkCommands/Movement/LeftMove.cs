using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class LeftMove :ICommand
    {
        private Game1 gameObject;
        public LeftMove(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionLeft();
            GameObjects.Instance.Link.Move();
        }
    }
}
