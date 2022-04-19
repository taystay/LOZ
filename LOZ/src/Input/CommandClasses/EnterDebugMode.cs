using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class EnterDebugMode : ICommand
    {
        public EnterDebugMode() { }
        public void execute() =>
            RoomReference.ToggleDebug();
    }
}
