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
        private List<ICommand> alreadyExecuted;

        public MouseController()
        {
            leftClickCommands = new List<ICommand>();
            rightClickCommands = new List<ICommand>();
            alreadyExecuted = new List<ICommand>();
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
                if(state.LeftButton == ButtonState.Pressed)
                {
                    if (alreadyExecuted.Contains(command)) continue;
                    //command.execute();
                    alreadyExecuted.Add(command);
                }
            }
            if(state.LeftButton != ButtonState.Pressed)
            {
                while(alreadyExecuted.Count > 0)
                {
                    alreadyExecuted.RemoveAt(0);
                }
            }
            foreach(ICommand command in rightClickCommands)
            {
                if (state.RightButton == ButtonState.Released)
                {
                    //command.execute();
                }
            }    
        }
    }
}
