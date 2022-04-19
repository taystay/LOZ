using LOZ.src.CameraStates;

namespace LOZ.CommandClasses.RoomCommands
{
    class RoompZ : ICommand
    {
        private Game1 _gameObject;
        public RoompZ(Game1 gameObj) =>
            _gameObject = gameObj;
        public void execute()
        {
            if (GameStateReference.RoomReference.GetChangeRoom(0, 0, 1) != null)
                _gameObject.CameraState = new RoomTransition(_gameObject, 0, 0, 1);
        }
    }
}
