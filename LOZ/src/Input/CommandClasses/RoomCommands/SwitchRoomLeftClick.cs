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
            CurrentRoom.Instance.NextRoom(1);
        }
    }
}
