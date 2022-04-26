using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;
using LOZ.Sound;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockRight : ICommand
    {
        public UnlockRight() { }
        public void execute()
        {
            if(RoomReference.GetInventory().keyCount > 0)
            {
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Door_Unlock);
                RoomReference.GetCurrRoom().UpdateExterior(DoorType.Door, DoorLocation.Right);
                RoomReference.GetInventory().UseKey();
                IRoom nextRoom = RoomReference.GetChangeRoom(1, 0, 0);
                if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Door, DoorLocation.Left);
                else System.Diagnostics.Debug.WriteLine("error opening right");
            }
        }
    }
}
