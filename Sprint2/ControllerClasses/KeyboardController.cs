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
        private List<Keys> pressedDownKeys;
        //-------------------------------------------------------
        public KeyboardController(Game1 GameObject)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            pressedDownKeys = new List<Keys>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        /* 
         * public void RegisterHoldCommand(Keys key, ICommand command)
         * {
         *   holdCommands.Add(key, command);
         * }
         * 
         */

        public void Update(GameTime gameTime)
        {
            //-----Register keys into currently pressed down keys-----
            foreach(Keys key in Keyboard.GetState().GetPressedKeys())
            {
                if (!controllerMappings.ContainsKey(key))
                    continue;
                if(!pressedDownKeys.Contains(key))
                    pressedDownKeys.Add(key);
            }

            //-----Cryptic logic but only execute keys when they were pressed down and THEN released-----
            int i = 0;
            while (i < pressedDownKeys.Count)
            {
                Keys key = pressedDownKeys[i++];
                if (Keyboard.GetState().IsKeyDown(key))
                    continue;
                controllerMappings[key].execute();
                pressedDownKeys.RemoveAt(--i);
            }
                
        }
    }
}
