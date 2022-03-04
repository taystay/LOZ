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
            CurrentRoom.Instance.Room.Link.TakeDamage();
        }
    }
}
