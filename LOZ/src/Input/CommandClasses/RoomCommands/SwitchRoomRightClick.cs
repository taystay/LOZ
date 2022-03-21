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
            CurrentRoom.Instance.NextRoom(-1);
        }
    }
}
