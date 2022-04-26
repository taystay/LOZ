using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;
using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class OpenRightDoor : ICommand
    {
        public OpenRightDoor() { }
        public void execute()
        {
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Secret);
            RoomReference.GetCurrRoom().UpdateExterior(DoorType.Hole, DoorLocation.Right);
            IRoom nextRoom = RoomReference.GetChangeRoom(1, 0, 0);
            if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Hole, DoorLocation.Left);
        }
    }
}
