using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint2.CommandClasses;

namespace Sprint2.ControllerClasses
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> storedInitCommands;
        private Dictionary<Keys, int> initKeysTimeHeld;
        private Dictionary<Keys, ICommand> storedHoldCommands;
        private Dictionary<Keys, ICommand> storedReleaseCommands;
        private List<Keys> initKeysPressed;
        private List<Keys> releaseKeysPressed;

        public KeyboardController(Game1 GameObject)
        {
            initKeysTimeHeld = new Dictionary<Keys, int>();
            storedInitCommands = new Dictionary<Keys, ICommand>();
            storedHoldCommands = new Dictionary<Keys, ICommand>();
            storedReleaseCommands = new Dictionary<Keys, ICommand>();
            initKeysPressed = new List<Keys>();
            releaseKeysPressed = new List<Keys>();
        }

        public void RegisterInitialCommand(Keys key, ICommand initialPressCommand)
        {
            storedInitCommands.Add(key, initialPressCommand);
        }
        public void RegisterHoldCommand(Keys key, ICommand holdCommand)
        {
            storedHoldCommands.Add(key, holdCommand);
        }
        public void RegisterReleaseCommand(Keys key, ICommand onReleaseCommand)
        {
            storedReleaseCommands.Add(key, onReleaseCommand);
        }

        private void UpdateInitPress()
        {
            int i;
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (initKeysPressed.Contains(key)) continue;
                if (!storedInitCommands.ContainsKey(key)) continue;
                initKeysPressed.Add(key);
                if (!initKeysTimeHeld.ContainsKey(key))
                    initKeysTimeHeld.Add(key, 20);
                storedInitCommands[key].execute();
            }
            i = 0;
            while (i < initKeysPressed.Count)
            {
                Keys key = initKeysPressed[i++];
                if (initKeysTimeHeld[key] == 0)
                {
                    initKeysTimeHeld.Remove(key);
                    initKeysPressed.Remove(key);
                    continue;
                }
                else
                {
                    initKeysTimeHeld[key]--;
                }
                if (Keyboard.GetState().IsKeyDown(key)) continue;
                initKeysPressed.RemoveAt(--i);
            }
        }

        private void UpdateHold()
        {
            foreach (Keys key in Keyboard.GetState().GetPressedKeys())
            {
                if (storedHoldCommands.ContainsKey(key))
                {
                    storedHoldCommands[key].execute();
                }
            }
        }

        private void UpdateRelease()
        {
            int i;
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (releaseKeysPressed.Contains(key)) continue;
                if (!storedReleaseCommands.ContainsKey(key)) continue;
                releaseKeysPressed.Add(key);
            }
            i = 0;
            while (i < releaseKeysPressed.Count)
            {
                Keys key = releaseKeysPressed[i++];
                if (Keyboard.GetState().IsKeyDown(key)) continue;
                storedReleaseCommands[key].execute();
                releaseKeysPressed.RemoveAt(--i);
            }
        }

        public void Update(GameTime gameTime)
        {
            UpdateInitPress();
            UpdateHold();
            UpdateRelease();
              
        }
    }
}
