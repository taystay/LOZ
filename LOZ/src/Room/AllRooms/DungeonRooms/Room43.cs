using LOZ.MapIO;

namespace LOZ.Room
{
    class Room43 : RoomAbstract
    {
       
        public Room43(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "4_3.csv");
        }
    }
}
