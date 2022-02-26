using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;

namespace LOZ.ControllerClasses
{
    class MouseController : IController
    {
        private Dictionary<Rectangle,ICommand> LeftHitLocations;
        private List<ICommand> RightClickCommands;

        public MouseController()
        {
            LeftHitLocations = new Dictionary<Rectangle, ICommand>();
            RightClickCommands = new List<ICommand>();
        }

        public void RegisterRightClickCommands(ICommand command)
        {
            RightClickCommands.Add(command);
        }

        public void RegisterLeftClickLocation(Rectangle location, ICommand command)
        {
            LeftHitLocations.Add(location, command);
        }

        public void Update(GameTime gametime)
        {
            MouseState State = Mouse.GetState();
            if(State.RightButton == ButtonState.Pressed)
            {
                foreach(ICommand command in RightClickCommands)
                {
                    command.execute();
                }
            }

            if(State.LeftButton == ButtonState.Pressed)
            {
                foreach(KeyValuePair<Rectangle, ICommand> pair in LeftHitLocations)
                {
                    if(State.X >= pair.Key.X && 
                        State.Y >= pair.Key.Y && 
                        State.X <= pair.Key.X + pair.Key.Width && 
                        State.Y <= pair.Key.Y + pair.Key.Height)
                    {
                        pair.Value.execute();
                    }
                }
            }
        }
    }
}
