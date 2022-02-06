using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class KeyboardController : IController
    {
        //-------------------------------------------------------

        private readonly IDictionary<Keys, ICommand> controllerMappings;
        //-------------------------------------------------------
        public KeyboardController(Game1 GameObject)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update(GameTime gameTime)
        {
            foreach(Keys Key in Keyboard.GetState().GetPressedKeys())
            {
                if (controllerMappings.ContainsKey(Key))
                {
                    controllerMappings[Key].execute();
                }
            }
        }
    }
}
