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
            ControllerMappings.RegisterCommand(Keys.Y, new IterateBlock(gameObject));
            ControllerMappings.RegisterCommand(Keys.T, new previousBlock(gameObject));
            ControllerMappings.RegisterCommand(Keys.I, new IterateStaticItems(gameObject));
            ControllerMappings.RegisterCommand(Keys.U, new IterateRStaticItems(gameObject));
<<<<<<< HEAD
 
=======
            //TEST IDEA, MAY OR MAY NOT WORK, THIS IS FOR LINKS FUNCTIONALITY
            //Holding tilde iterates as the key is pressed not when pressed and then relased. Works!
            ControllerMappings.RegisterHoldCommand(Keys.OemTilde, new IterateRStaticItems(gameObject));

>>>>>>> 59f8a418948ef80ba9225bed212a8b8d956ce1c8
        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
