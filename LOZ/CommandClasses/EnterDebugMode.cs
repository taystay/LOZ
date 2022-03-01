using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class EnterDebugMode : ICommand
    {
        public EnterDebugMode()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Room;
            room.DEBUGMODE = !room.DEBUGMODE;
        }
    }
}
