using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class Pause : ICommand
    {
        private Game1 gameObject;
        public Pause(Game1 gameObj)
        {
            gameObject = gameObj;
        }
        public void execute()
        {
            if(gameObject.state == CameraState.Playing)
                gameObject.state = CameraState.Paused;
            else if(gameObject.state == CameraState.Paused)
                gameObject.state = CameraState.Playing;

        }
    }
}
