using LOZ.GameState;

namespace Sprint2.CommandClasses
{
    class UpMove :ICommand
    {
        public UpMove()
        {
        }
        public void execute()
        {
            TestingRoom.Instance.Link.ChangeDirectionUp();
            TestingRoom.Instance.Link.Move();
        }
    }
}
