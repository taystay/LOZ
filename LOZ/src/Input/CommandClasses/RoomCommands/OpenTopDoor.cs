using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;
using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class OpenTopDoor : ICommand
    {
        public OpenTopDoor() { }
        public void execute()
        {
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Secret);
            RoomReference.GetCurrRoom().UpdateExterior(DoorType.Hole, DoorLocation.Top);
            IRoom nextRoom = RoomReference.GetChangeRoom(0, -1, 0);
            if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Hole, DoorLocation.Bottom);
        }
    }
}
