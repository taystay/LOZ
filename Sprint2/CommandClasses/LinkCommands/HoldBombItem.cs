using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class HoldBombItem :ICommand
    {
        private Game1 gameObject;
        private Point position = GameObjects.Link.Position;
        private double scale = 3;
        public HoldBombItem(Game1 obj)
        {
            gameObject = obj;
        }
        public void execute()
        {
<<<<<<< HEAD
            GameObjects.HeldItem = new Bomb(, scale);
=======
            GameObjects.HeldItem = new Bomb(position, scale);
>>>>>>> 79fa08eb9149f094020bd8d059c90416ff778588
        }
    }
}
