using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;
using System;

namespace LOZ.ControllerClasses
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> storedInitCommands;
        private List<Keys> keysPressed;
        private Dictionary<Keys, ICommand> storedHoldCommands;
        private Dictionary<Keys, ICommand> storedReleaseCommands;
        private List<Keys> releaseKeysPressed;
        private Keys keyBeingHeld = Keys.None;
        private Dictionary< Tuple<Keys, Keys, Keys> , ICommand> storedSeqCommands;
        public KeyboardController(Game1 GameObject)
        {
            storedInitCommands = new Dictionary<Keys, ICommand>();
            keysPressed = new List<Keys>();
            storedHoldCommands = new Dictionary<Keys, ICommand>();
            storedReleaseCommands = new Dictionary<Keys, ICommand>();
            releaseKeysPressed = new List<Keys>();
            storedSeqCommands = new Dictionary<Tuple<Keys, Keys, Keys>, ICommand>();
        }
        public void RegisterInitialCommand(Keys key, ICommand initialPressCommand) =>
            storedInitCommands.Add(key, initialPressCommand);
        public void RegisterHoldCommand(Keys key, ICommand holdCommand) =>
            storedHoldCommands.Add(key, holdCommand);
        public void RegisterReleaseCommand(Keys key, ICommand onReleaseCommand) =>
            storedReleaseCommands.Add(key, onReleaseCommand);
        public void RegisterSeqCommand(Tuple<Keys, Keys, Keys> tuple, ICommand command) =>
            storedSeqCommands.Add(tuple, command);

        private void UpdateInitPress()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach(Keys key in pressedKeys)
            {
                if (storedInitCommands.ContainsKey(key) && !keysPressed.Contains(key))
                {
                    keysPressed.Add(key);
                    storedInitCommands[key].execute();
                }
            }
            int i = keysPressed.Count - 1;
            while(i >= 0)
            {
                Keys key = keysPressed[i];
                if (Keyboard.GetState().IsKeyUp(key))
                {
                    keysPressed.Remove(key);
                }
                i--;
            }
        }
        private void UpdateHold()
        {
            foreach (Keys key in Keyboard.GetState().GetPressedKeys())
            {
                if (storedHoldCommands.ContainsKey(key) && keyBeingHeld == Keys.None)
                {
                    storedHoldCommands[key].execute();
                    keyBeingHeld = key;
                } else if(storedHoldCommands.ContainsKey(key) && keyBeingHeld == key)
                {
                    storedHoldCommands[key].execute();
                } else
                {
                    keyBeingHeld = Keys.None;
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

        private void UpdateSequence()
        {
            /* int j = 0;
             Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
             KeyboardState pressedKeys2 = Keyboard.GetState();
             Dictionary<Tuple<Keys, Keys, Keys>, ICommand>.KeyCollection keys = storedSeqCommands.Keys;
             Tuple<Keys, Keys, Keys>[] t = new Tuple<Keys, Keys, Keys>[3];
             keys.CopyTo(t, j);
            */
            //need to somehow get keys from dictionary when key is an array, or tuple.
            /*
            foreach (Keys key in pressedKeys)
            {
                if (storedSeqCommands.ContainsKey(key) && !keysPressed.Contains(key))
                {
                    keysPressed.Add(key);
                    storedInitCommands[key].execute();
                }
            }
            int i = keysPressed.Count - 1;
            while (i >= 0)
            {
                Keys key = keysPressed[i];
                if (Keyboard.GetState().IsKeyUp(key))
                {
                    keysPressed.Remove(key);
                }
                i--;
            }
            */

        }
            
        public void Update(GameTime gameTime)
        {
            UpdateInitPress();
            UpdateHold();
            UpdateRelease();
            UpdateSequence();
        }
    }
}
