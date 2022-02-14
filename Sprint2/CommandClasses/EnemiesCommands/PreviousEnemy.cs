using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class PreviousEnemy :ICommand
    {
        public PreviousEnemy()
        {
        }
        public void execute()
        {
            GameObjects.Enemies.IterateReverse();
        }
    }
}
