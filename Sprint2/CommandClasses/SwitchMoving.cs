using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class SwitchMoving : ICommand
    {
        Game1 GameObject;
        public SwitchMoving(Game1 gameObject)
        {
            GameObject = gameObject;
        }
        public void execute()
        {
            GameObject.Sprite = new MovingSprite(GameObject.GetTexture(), GameObject.GetStartingPosition());
        }
    }
}
