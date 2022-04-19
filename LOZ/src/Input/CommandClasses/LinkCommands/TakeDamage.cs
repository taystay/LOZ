using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class TakeDamage :ICommand
    {
        public TakeDamage() { }
        public void execute() =>
            RoomReference.GetLink().TakeDamage(1);
    }
}
