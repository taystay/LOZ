using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;
using LOZ.Sound;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockLeft : ICommand
    {
        public UnlockLeft() { }
        public void execute()
        {
            if(RoomReference.GetInventory().keyCount > 0)
            {
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Door_Unlock);
                RoomReference.GetCurrRoom().UpdateExterior(DoorType.Door, DoorLocation.Left);
                RoomReference.GetInventory().UseKey();
                IRoom nextRoom = RoomReference.GetChangeRoom(-1, 0, 0);
                if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Door, DoorLocation.Right);
                else System.Diagnostics.Debug.WriteLine("error opening left");
            } 
            
        }
    }
}
