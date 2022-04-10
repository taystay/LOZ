using LOZ.MapIO;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room53 : RoomAbstract
    {
       
        public Room53(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "5_3.csv");
            gameObjects.Add(new Key(GetCoorPoint(8, 7)));
        }
    }
}
