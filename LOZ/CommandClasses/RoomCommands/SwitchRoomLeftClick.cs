using LOZ.GameState;
using Microsoft.Xna.Framework.Input;

namespace LOZ.CommandClasses
{
    class SwitchRoomLeftClick : ICommand
    {
        public SwitchRoomLeftClick()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            MouseState state = Mouse.GetState();
            CurrentRoom.Instance.NextRoom();
            CurrentRoom.Instance.LoadContent();
        }
    }
}
