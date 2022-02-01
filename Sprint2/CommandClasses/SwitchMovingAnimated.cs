using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class SwitchMovingAnimated : ICommand
    {
        private Game1 GameObject;
        public SwitchMovingAnimated(Game1 gameObject)
        {
            GameObject = gameObject;
        }
        public void execute()
        {
            GameObject.Sprite = new MovingAnimatedSprite(GameObject.GetTexture(), GameObject.GetStartingPosition());
        }
    }
}
