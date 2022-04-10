using LOZ.MapIO;
using LOZ.ItemsClasses;

namespace LOZ.Room
{
    class Room31 : RoomAbstract
    {
       
        public Room31(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "3_1.csv");
            gameObjects.Add(new Key(GetCoorPoint(7, 2)));
        }
    }
}
