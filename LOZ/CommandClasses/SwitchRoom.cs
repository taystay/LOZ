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
            
            if(Type.Check(room, typeof(TestRoom)))
            {
                CurrentRoom.Room = new RandomRoomOfNothingness();
            } else
            {
                CurrentRoom.Room = new TestRoom();
            }
            CurrentRoom.Instance.LoadContent();
        }
    }
}
