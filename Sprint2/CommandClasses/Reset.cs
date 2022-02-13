using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class Reset : ICommand
    {
        Game1 gameObject;
        public Reset(Game1 gameObj) {
            gameObject = gameObj;
    
        }

        public void execute() {

            GameObjects.Instance.LoadObjects(gameObject.Content);
        }
    }
}
