using LOZ.GameState;

namespace Sprint2.CommandClasses
{
    class TakeDamage :ICommand
    {
        public TakeDamage()
        {
        }
        public void execute()
        {
            TestingRoom.Instance.Link.TakeDamage();
        }
    }
}
