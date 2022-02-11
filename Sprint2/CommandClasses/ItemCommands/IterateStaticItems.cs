using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class IterateStaticItems :ICommand
    {
        private Game1 gameObject;
        public IterateStaticItems(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
            GameObjects.ItemIndex++;  
        }
    }
}
