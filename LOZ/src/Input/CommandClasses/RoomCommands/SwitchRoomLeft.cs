using LOZ.GameState;
using Microsoft.Xna.Framework.Input;

namespace LOZ.CommandClasses
{
    class SwitchRoomLeft : ICommand
    {
        public SwitchRoomLeft()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            MouseState state = Mouse.GetState();

            CurrentRoom.Instance.MoveRoomDirection(-1,0, 0);
        }
    }
}
