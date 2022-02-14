using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class NextEnemy :ICommand
    {
        public NextEnemy()
        {
        }
        public void execute()
        {
            GameObjects.Enemies.IterateForward();
        }
    }
}
