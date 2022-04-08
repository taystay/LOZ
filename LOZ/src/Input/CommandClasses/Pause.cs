using LOZ.Sound;
using LOZ.src.CameraStates;
using LOZ.SpriteClasses;

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
            gameObject.CameraState = new Paused(gameObject);
        }
    }
}
