﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class PreviousEnemy :ICommand
    {
        private Game1 gameObject;
        public PreviousEnemy(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
            List<IIterable> objects = GameObjects.IterableObjects;
            foreach (IIterable item in objects)
            {
                if (item.GetType().IsInstanceOfType(new IterableEnemy()))
                {
                    item.IterateReverse();
                }
            }
        }
    }
}
