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

            ControllerMappings.RegisterCommand(Keys.D1, new SwitchIdle(gameObject));
            ControllerMappings.RegisterCommand(Keys.NumPad1, new SwitchIdle(gameObject));

            ControllerMappings.RegisterCommand(Keys.D2, new SwitchAnimated(gameObject));
            ControllerMappings.RegisterCommand(Keys.NumPad2, new SwitchAnimated(gameObject));

            ControllerMappings.RegisterCommand(Keys.D3, new SwitchMoving(gameObject));
            ControllerMappings.RegisterCommand(Keys.NumPad3, new SwitchMoving(gameObject));

            ControllerMappings.RegisterCommand(Keys.D4, new SwitchMovingAnimated(gameObject));
            ControllerMappings.RegisterCommand(Keys.NumPad4, new SwitchMovingAnimated(gameObject));
        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
