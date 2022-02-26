using LOZ.GameState;

namespace LOZ.CommandClasses
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
