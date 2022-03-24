using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;

namespace LOZ.ControllerClasses
{
    class KeyboardFix : IController
    {
        private Dictionary<Keys, ICommand> commands;
        public KeyboardFix(Game1 GameObject)
        {
            commands = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            commands.Add(key, command);
        }
        public void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach(Keys key in pressedKeys)
            {
                if (commands.ContainsKey(key)) commands[key].execute();
            }
        }
    }
}
