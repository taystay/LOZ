using LOZ.GameStateReference;
using LOZ.src.CameraStates;

namespace LOZ.CommandClasses.RoomCommands
{
    class EnterBasement : ICommand
    {
        private Game1 _gameObject;
        public EnterBasement(Game1 gameObj)
        {
            _gameObject = gameObj;
        }
        public void execute()
        {
            _gameObject.CameraState = new RoomTransition(_gameObject, 0, 0, 1);
        }
    }
}
