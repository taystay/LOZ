using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class Idle :ICommand
    {
        public Idle()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.Idle();
        }
    }
}
