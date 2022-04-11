using LOZ.GameStateReference;
using LOZ.src.CameraStates;

namespace LOZ.CommandClasses.RoomCommands
{
    class LeaveBasement : ICommand
    {
        private Game1 _gameObject;
        public LeaveBasement(Game1 gameObj)
        {
            _gameObject = gameObj;
        }
        public void execute()
        {
            _gameObject.CameraState = new RoomTransition(_gameObject, 0, 0, -1);
        }
    }
}
