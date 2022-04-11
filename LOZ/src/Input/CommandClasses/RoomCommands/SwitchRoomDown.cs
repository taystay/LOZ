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
           

            _gameObject.CameraState = new RoomTransition(_gameObject, 0, 1, 0);

          
        }
    }
}
