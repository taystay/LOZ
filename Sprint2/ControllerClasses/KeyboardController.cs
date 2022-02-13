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
        private Dictionary<Keys, ICommand> initialPressCommands;
        private Dictionary<Keys, ICommand> holdCommands;
        private Dictionary<Keys, ICommand> onReleaseCommands;
        private List<Keys> initialPressedKeys;
        private List<Keys> onReleaseKeys;

        public KeyboardController(Game1 GameObject)
        {
            initialPressCommands = new Dictionary<Keys, ICommand>();
            holdCommands = new Dictionary<Keys, ICommand>();
            onReleaseCommands = new Dictionary<Keys, ICommand>();
            initialPressedKeys = new List<Keys>();
            onReleaseKeys = new List<Keys>();
        }

        public void RegisterCommand(Keys key, ICommand initialPressCommand, ICommand holdCommand, ICommand onReleaseCommand)
        {
            if(initialPressCommand != null)
                initialPressCommands.Add(key, initialPressCommand);
            if(holdCommand != null)
                holdCommands.Add(key, holdCommand);
            if (onReleaseCommand != null)
                onReleaseCommands.Add(key, onReleaseCommand);
        }

        public void Update(GameTime gameTime)
        {
            int i;
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            //-----ON INITIAL PRESS-----
            foreach (Keys key in pressedKeys)
            {
                if (initialPressedKeys.Contains(key)) continue;
                if (!initialPressCommands.ContainsKey(key)) continue;
                initialPressedKeys.Add(key);
                initialPressCommands[key].execute();
            }
            i = 0;
            while(i < initialPressedKeys.Count)
            {
                Keys key = initialPressedKeys[i++];
                if (Keyboard.GetState().IsKeyDown(key)) continue;
                initialPressedKeys.RemoveAt(--i);
            }

            //-----HOLD-----
            foreach (Keys key in Keyboard.GetState().GetPressedKeys())
            {
                if(holdCommands.ContainsKey(key))
                {
                    holdCommands[key].execute();
                }
            }
            //-----ON RELEASE-----
            foreach (Keys key in pressedKeys)
            {
                if (onReleaseKeys.Contains(key)) continue;
                if (!onReleaseCommands.ContainsKey(key)) continue;
                onReleaseKeys.Add(key);
            }

            i = 0;
            while (i < onReleaseKeys.Count)
            {
                Keys key = onReleaseKeys[i++];
                if (Keyboard.GetState().IsKeyDown(key)) continue;
                onReleaseCommands[key].execute();
                onReleaseKeys.RemoveAt(--i);
            }   
        }
    }
}
