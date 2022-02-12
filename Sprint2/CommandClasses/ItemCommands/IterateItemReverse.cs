using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class IterateItemReverse :ICommand
    {
        private Game1 gameObject;
        public IterateItemReverse(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
            List<IIterable> objects = GameObjects.IterableObjects;
            foreach (IIterable item in objects)
            {
                if (item.GetType().IsInstanceOfType(new IterableItem()))
                {
                    item.IterateReverse();
                }
            }
        }
    }
}
