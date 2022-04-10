using LOZ.Room;

namespace LOZ.CommandClasses
{
    class EnterDebugMode : ICommand
    {
        public EnterDebugMode()
        {
        }
        public void execute()
        {
            CurrentRoom.DebugMode = !CurrentRoom.DebugMode;
        }
    }
}
