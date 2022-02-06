using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class KeyBindings
    {
        private KeyboardController ControllerMappings;

        public KeyBindings(Game1 gameObject)
        {
            ControllerMappings = new KeyboardController(gameObject);

            ControllerMappings.RegisterCommand(Keys.D0, new QuitGame(gameObject));
            ControllerMappings.RegisterCommand(Keys.NumPad0, new QuitGame(gameObject));
            ControllerMappings.RegisterCommand(Keys.T, new IterateBlock(gameObject));
            ControllerMappings.RegisterCommand(Keys.Y, new IterateBlock(gameObject));
            ControllerMappings.RegisterCommand(Keys.P, new IterateStaticItems(gameObject));

        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
