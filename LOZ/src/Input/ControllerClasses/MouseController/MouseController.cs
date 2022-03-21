using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.CommandClasses;
using Microsoft.Xna.Framework.Input;


namespace LOZ.ControllerClasses
{
    class MouseController : IController
    {
        private List<ICommand> leftClickCommands;
        private List<ICommand> rightClickCommands;
        private bool leftClicked = false;
        private bool rightClicked = false;
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
            MouseState state = Mouse.GetState();
            foreach (ICommand command in leftClickCommands)
            {
                if (state.LeftButton == ButtonState.Pressed && !leftClicked)
                {
                    command.execute();
                    leftClicked = true;
                }
                else if (state.LeftButton == ButtonState.Released && leftClicked)
                    leftClicked = false;
            }
            foreach(ICommand command in rightClickCommands)
            {
                if (state.RightButton == ButtonState.Pressed && !rightClicked)
                {
                    command.execute();
                    rightClicked = true;
                }
                else if (state.RightButton == ButtonState.Released && rightClicked)
                    rightClicked = false;
            }    
        }
    }
}
