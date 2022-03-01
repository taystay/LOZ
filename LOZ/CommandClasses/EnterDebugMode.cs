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
            TestingRoom room = TestingRoom.Instance;
            room.DEBUGMODE = !room.DEBUGMODE;
        }
    }
}
