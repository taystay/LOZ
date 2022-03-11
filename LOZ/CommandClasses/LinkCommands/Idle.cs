using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class Idle :ICommand
    {
        public Idle()
        {
        }
        public void execute()
        {
            Room.Link.Idle();
        }
    }
}
