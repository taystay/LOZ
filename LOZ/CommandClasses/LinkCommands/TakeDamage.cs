using LOZ.GameState;

namespace LOZ.CommandClasses
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
