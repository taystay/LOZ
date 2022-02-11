﻿using System;
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
            ControllerMappings.RegisterCommand(Keys.O, new PreviousEnemy(gameObject));
            ControllerMappings.RegisterCommand(Keys.P, new NextEnemy(gameObject));

            ControllerMappings.RegisterHoldCommand(Keys.OemTilde, new IterateRStaticItems(gameObject));
        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
