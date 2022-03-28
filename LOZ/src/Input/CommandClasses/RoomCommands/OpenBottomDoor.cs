using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.Collision;

namespace LOZ.CommandClasses
{
    class OpenBottomDoor : ICommand
    {
        public OpenBottomDoor()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            ExteriorObject exterior = room.exterior;
            if(exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Hole);
            }
                
        }
    }
}
