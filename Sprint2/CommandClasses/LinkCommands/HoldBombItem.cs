using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class HoldBombItem :ICommand
    {
        private Game1 gameObject;
        private Point position;
        private double scale = 3;
        public HoldBombItem(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
            //GameObjects.HeldItem = new Bomb(position, scale);
        }
    }
}
