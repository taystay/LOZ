using LOZ.GameStateReference;
using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class Heal :ICommand
    {
        public Heal() { }
        public void execute()
        {
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Heart);
            RoomReference.GetLink().Health += 2;
        }
    }
}
