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
            Room.Link.TakeDamage();
        }
    }
}
