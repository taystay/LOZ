using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class Mute : ICommand
    {
        public Mute()
        {
        }
        public void execute()
        {
            SoundManager.Instance.ToggleMute();
        }
    }
}
