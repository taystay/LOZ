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

            ControllerMappings.RegisterCommand(Keys.D0, new QuitGame(gameObject),          null, null);
            ControllerMappings.RegisterCommand(Keys.NumPad0, new QuitGame(gameObject),     null, null);

            ControllerMappings.RegisterCommand(Keys.Y, new IterateBlock(gameObject),       null, null);
            ControllerMappings.RegisterCommand(Keys.T, new previousBlock(gameObject),      null, null);
            ControllerMappings.RegisterCommand(Keys.I, new IterateItemForward(gameObject), null, null);
            ControllerMappings.RegisterCommand(Keys.U, new IterateItemReverse(gameObject), null, null);
            ControllerMappings.RegisterCommand(Keys.O, new PreviousEnemy(gameObject),      null, null);
            ControllerMappings.RegisterCommand(Keys.P, new NextEnemy(gameObject),          null, null);
        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
