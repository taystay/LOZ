using LOZ.GameState;
using LOZ.Collision;
using Microsoft.Xna.Framework.Input;

namespace LOZ.CommandClasses
{
    class SwitchRoom : ICommand
    {
        public SwitchRoom()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Room;
            MouseState state = Mouse.GetState();

            /*
            if(Type.Check(room, typeof(DevRoom)))
            {
                CurrentRoom.Room = new EmptyRoom();
            } else
            {
                CurrentRoom.Room = new DevRoom();
            }
            */
            if(state.LeftButton == ButtonState.Pressed)
            {
                CurrentRoom.Room = CurrentRoom.Instance.NextRoom();
            }
            else if (state.RightButton == ButtonState.Pressed)
            {
                CurrentRoom.Room = CurrentRoom.Instance.PreviousRoom();
            }

            CurrentRoom.Instance.LoadContent();
        }
    }
}
