using LOZ.GameStateReference;
using LOZ.src.CameraStates;

namespace LOZ.CommandClasses
{
    class SwitchRoomRight : ICommand
    {
        private Game1 _gameObject;
        public SwitchRoomRight(Game1 gameObj)
        {
            _gameObject = gameObj;
        }
        public void execute()
        {
            
            _gameObject.CameraState = new RoomTransition(_gameObject, 1, 0, 0);
         
        }
    }
}
