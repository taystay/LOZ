using LOZ.GameStateReference;
using LOZ.src.CameraStates;

namespace LOZ.CommandClasses
{
    class SwitchRoomLeft : ICommand
    {
        private Game1 _gameObject;
        public SwitchRoomLeft(Game1 gameObj)
        {
            _gameObject = gameObj;
        }
        public void execute()
        {
            //CurrentRoom.Instance.MoveRoomDirection(-1,0, 0);
            //CurrentRoom.Instance.Transition(-1,0,0);
            //CurrentRoom.currentLocation.X -= 1;
            //CurrentRoom.changeRoom = true;
            _gameObject.CameraState = new RoomTransition(_gameObject, -1, 0, 0);
            //RoomReference.SetRoomLocation(-1, 0, 0);
            //RoomReference.SetChangeRoom();
        }
    }
}
