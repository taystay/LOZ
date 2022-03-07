using LOZ.GameState;
using Microsoft.Xna.Framework.Input;

namespace LOZ.CommandClasses
{
    class SwitchRoomUp : ICommand
    {
        public SwitchRoomUp()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            MouseState state = Mouse.GetState();
            CurrentRoom.Instance.MoveRoomDirection(0,-1, 0);
            CurrentRoom.Instance.LoadContent();
        }
    }
}
