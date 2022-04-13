using LOZ.src.CameraStates;

namespace LOZ.CommandClasses
{
    class RoompY : ICommand
    {
        private Game1 _gameObject;
        public RoompY(Game1 gameObj)
        {
            _gameObject = gameObj;
        }
        public void execute()
        {
            if (GameStateReference.RoomReference.GetChangeRoom(0, 1, 0) != null)
                _gameObject.CameraState = new RoomTransition(_gameObject, 0, 1, 0);
        }
    }
}
