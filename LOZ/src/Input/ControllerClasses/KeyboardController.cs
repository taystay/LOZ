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
        private Dictionary<Keys , ICommand> storedSeqCommands;
        public KeyboardController(Game1 GameObject)
        {
            storedInitCommands = new Dictionary<Keys, ICommand>();
            keysPressed = new List<Keys>();
            storedHoldCommands = new Dictionary<Keys, ICommand>();
            storedReleaseCommands = new Dictionary<Keys, ICommand>();
            releaseKeysPressed = new List<Keys>();
            storedSeqCommands = new Dictionary<Keys, ICommand>();
        }
        public void RegisterInitialCommand(Keys key, ICommand initialPressCommand) =>
            storedInitCommands.Add(key, initialPressCommand);
        public void RegisterHoldCommand(Keys key, ICommand holdCommand) =>
            storedHoldCommands.Add(key, holdCommand);
        public void RegisterReleaseCommand(Keys key, ICommand onReleaseCommand) =>
            storedReleaseCommands.Add(key, onReleaseCommand);
        public void RegisterSeqCommand(Keys key, ICommand command) =>
            storedSeqCommands.Add(key, command);

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
   
            KeyboardState pressedKeys = Keyboard.GetState();

                 //ExtraBombs
                if (pressedKeys.IsKeyDown(Keys.F) && pressedKeys.IsKeyDown(Keys.G) && pressedKeys.IsKeyDown(Keys.H))
                {
                storedSeqCommands[Keys.F].execute();
                }
                //UnlimitedArrows
                if (pressedKeys.IsKeyDown(Keys.W) && pressedKeys.IsKeyDown(Keys.U) && pressedKeys.IsKeyDown(Keys.H))
                {
                    storedSeqCommands[Keys.D9].execute();
                }




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
