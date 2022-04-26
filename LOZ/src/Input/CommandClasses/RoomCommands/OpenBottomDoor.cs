using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;
using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class OpenBottomDoor : ICommand
    {
        public OpenBottomDoor() { }
        public void execute()
        {
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Secret);
            RoomReference.GetCurrRoom().UpdateExterior(DoorType.Hole, DoorLocation.Bottom);
            IRoom nextRoom = RoomReference.GetChangeRoom(0, 1, 0);
            if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Hole, DoorLocation.Top);
        }
    }
}
