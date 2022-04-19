using LOZ.src.CameraStates;

namespace LOZ.CommandClasses
{
    class RoompX : ICommand
    {
        private Game1 _gameObject;
        public RoompX(Game1 gameObj) =>
            _gameObject = gameObj;
        public void execute()
        {
            if (GameStateReference.RoomReference.GetChangeRoom(1, 0, 0) != null)
                _gameObject.CameraState = new RoomTransition(_gameObject, 1, 0, 0);
        }
    }
}
