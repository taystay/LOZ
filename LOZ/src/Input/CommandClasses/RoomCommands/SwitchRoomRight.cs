using LOZ.GameState;
using LOZ.Collision;
using Microsoft.Xna.Framework.Input;

namespace LOZ.CommandClasses
{
    class SwitchRoomRight : ICommand
    {
        public SwitchRoomRight()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            MouseState state = Mouse.GetState();

            CurrentRoom.Instance.MoveRoomDirection(1,0, 0);
        }
    }
}
