using LOZ.GameStateReference;
using LOZ.src.CameraStates;

namespace LOZ.CommandClasses.RoomCommands
{
    class RoomnZ : ICommand
    {
        private Game1 _gameObject;
        public RoomnZ(Game1 gameObj) =>
            _gameObject = gameObj;
        public void execute()
        {
            if(RoomReference.GetChangeRoom(0,0,-1) != null)
                _gameObject.CameraState = new RoomTransition(_gameObject, 0, 0, -1);
        }   
    }
}
