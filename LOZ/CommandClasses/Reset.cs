using LOZ.GameState;
using LOZ.Collision;

namespace LOZ.CommandClasses
{
    class Reset : ICommand
    {
        public Reset()
        {
        }
        public void execute()
        {
            CurrentRoom.Instance.Room = new DevRoom();
            CurrentRoom.Instance.LoadContent();
        }
    }
}
