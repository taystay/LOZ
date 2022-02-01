using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class QuitGame : ICommand
    {
        Game1 GameObj;
        public QuitGame(Game1 gameObj)
        {
            GameObj = gameObj;
        }
        public void execute()
        {
            GameObj.Exit();
        }
    }
}
