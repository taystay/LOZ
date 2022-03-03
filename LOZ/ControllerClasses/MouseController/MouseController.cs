using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;

namespace LOZ.ControllerClasses
{
    class MouseController : IController
    {
        private List<ICommand> leftClickCommands;
        private List<ICommand> rightClickCommands;

        public MouseController()
        {
            leftClickCommands = new List<ICommand>();
            rightClickCommands = new List<ICommand>();
        }

        public void RegisterRightClickCommands(ICommand command)
        {
            rightClickCommands.Add(command);
        }

        public void RegisterLeftClickCommands(ICommand command)
        {
            leftClickCommands.Add(command);
        }

        public void Update(GameTime gametime)
        {
            MouseState State = Mouse.GetState();
            if(State.RightButton == ButtonState.Pressed)
            {
                foreach(ICommand command in rightClickCommands)
                {
                    command.execute();
                }
            }

            if(State.LeftButton == ButtonState.Pressed)
            {
                foreach (ICommand command in leftClickCommands)
                {
                    command.execute();
                }
            }
        }
    }
}
