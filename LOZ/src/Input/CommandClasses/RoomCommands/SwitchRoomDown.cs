using LOZ.GameStateReference;
using LOZ.src.CameraStates;

namespace LOZ.CommandClasses
{
    class SwitchRoomDown : ICommand
    {
        private Game1 _gameObject;
        public SwitchRoomDown(Game1 gameObj)
        {
            _gameObject = gameObj;
        }
        public void execute()
        {
            //CurrentRoom.Instance.MoveRoomDirection(0,1, 0);
            //CurrentRoom.Instance.Transition(0,1,0);
            //CurrentRoom.currentLocation.Y += 1;
            //CurrentRoom.changeRoom = true;

            _gameObject.CameraState = new RoomTransition(_gameObject, 0, 1, 0);

            //RoomReference.SetRoomLocation(0, 1, 0);
            //RoomReference.SetChangeRoom();
        }
    }
}
