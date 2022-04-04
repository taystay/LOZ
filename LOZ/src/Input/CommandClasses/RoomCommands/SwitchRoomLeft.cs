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
            //CurrentRoom.Instance.MoveRoomDirection(-1,0, 0);
            CurrentRoom.Instance.Transition(-1,0,0);
        }
    }
}
