using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
    class SwitchAnimated :ICommand
    {
        Game1 GameObject;
        public SwitchAnimated(Game1 gameObject)
        {
            GameObject = gameObject;
        }
        public void execute()
        {
            GameObject.Sprite = new AnimatedSprite(GameObject.GetTexture());
            
        }
    }
}
