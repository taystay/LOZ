using LOZ.GameState;
using Microsoft.Xna.Framework.Input;

namespace LOZ.CommandClasses
{
    class SwitchRoomRightClick : ICommand
    {
        public SwitchRoomRightClick()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            MouseState state = Mouse.GetState();
            CurrentRoom.Instance.PreviousRoom();
            CurrentRoom.Instance.LoadContent();
        }
    }
}
