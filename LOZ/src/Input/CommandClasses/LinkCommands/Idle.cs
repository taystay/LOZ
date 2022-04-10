using LOZ.Room;

namespace LOZ.CommandClasses
{
    class Idle :ICommand
    {
        public Idle()
        {
        }
        public void execute()
        {
            CurrentRoom.link.Idle();
        }
    }
}
