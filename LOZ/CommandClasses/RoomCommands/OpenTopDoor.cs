using LOZ.GameState;
using Microsoft.Xna.Framework.Input;
using LOZ.DungeonClasses;
using LOZ.Collision;

namespace LOZ.CommandClasses
{
    class OpenTopDoor : ICommand
    {
        public OpenTopDoor()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            ExteriorObject exterior = null;
            foreach(IGameObjects i in  room.gameObjects)
            {
                if(TypeC.Check(i, typeof(ExteriorObject)))
                {
                    exterior = (ExteriorObject)i;
                }
            }
            if(exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Hole);
            }
                
        }
    }
}
