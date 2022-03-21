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
            CurrentRoom.Instance.Debug();
        }
    }
}
