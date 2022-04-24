using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class EnterBossFight : ICommand
    {
        public EnterBossFight() { }
        public void execute()
        {
            RoomReference.SetAbsoluteRoom(4, 6, 1);
        }
    }
}
