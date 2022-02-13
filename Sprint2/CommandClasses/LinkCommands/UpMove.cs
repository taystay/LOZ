using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class UpMove :ICommand
    {
        private Game1 gameObject;
        public UpMove(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionUp();
            GameObjects.Instance.Link.Move();
        }
    }
}
