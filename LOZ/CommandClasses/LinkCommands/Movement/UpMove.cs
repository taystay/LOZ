using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class UpMove :ICommand
    {
        public UpMove()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionUp();
            GameObjects.Instance.Link.Move();
        }
    }
}
