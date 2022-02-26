using LOZ.GameState;

namespace Sprint2.CommandClasses
{
    class Idle :ICommand
    {
        public Idle()
        {
        }
        public void execute()
        {
            TestingRoom.Instance.Link.Idle();
        }
    }
}
