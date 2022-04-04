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
            CurrentRoom.Instance.MoveRoomDirection(1,0, 0);
            CurrentRoom.Instance.Transition();
        }
    }
}
