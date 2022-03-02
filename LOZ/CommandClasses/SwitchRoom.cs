using LOZ.GameState;
using LOZ.Collision;

namespace LOZ.CommandClasses
{
    class SwitchRoom : ICommand
    {
        public SwitchRoom()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Room;
            
            if(Type.Check(room, typeof(DevRoom)))
            {
                CurrentRoom.Room = new EmptyRoom();
            } else
            {
                CurrentRoom.Room = new DevRoom();
            }
            CurrentRoom.Instance.LoadContent();
        }
    }
}
