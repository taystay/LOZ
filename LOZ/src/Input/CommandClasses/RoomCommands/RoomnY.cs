using LOZ.GameStateReference;
using LOZ.src.CameraStates;
namespace LOZ.CommandClasses
{
    class RoomnY : ICommand
    {
        private Game1 _gameObject;
        public RoomnY(Game1 gameObj)
        {
            _gameObject = gameObj;
        }
        public void execute()
        {
            if (RoomReference.GetChangeRoom(0, -1, 0) != null)
                _gameObject.CameraState = new RoomTransition(_gameObject, 0, -1, 0);
           
        }
    }
}
