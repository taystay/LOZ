using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class Idle :ICommand
    {
        public Idle() { }
        public void execute() =>
            RoomReference.GetLink().Idle();
    }
}
