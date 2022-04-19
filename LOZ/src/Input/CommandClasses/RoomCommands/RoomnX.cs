using LOZ.src.CameraStates;

namespace LOZ.CommandClasses
{
    class RoomnX : ICommand
    {
        private Game1 _gameObject;
        public RoomnX(Game1 gameObj) =>
            _gameObject = gameObj;
        public void execute()
        {
            if (GameStateReference.RoomReference.GetChangeRoom(-1, 0, 0) != null)
                _gameObject.CameraState = new RoomTransition(_gameObject, -1, 0, 0);
        }
    }
}
