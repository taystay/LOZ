using System.Collections.Generic;

namespace LOZ.Room
{
    public class RoomMaker
    {
        private string _pathName;
        private const int NUMBEROFROOMS = 18;

        //pathFile is being passed in through game1
        public RoomMaker(string pathFile)
        {
            _pathName = pathFile;
        }

        //the list of rooms will be returned to game1
        public List<IRoom> CreateAllRooms() {
            List<IRoom> rooms = new List<IRoom>();
            rooms.Add(new StartRoom(_pathName));
            return rooms;
        }
    }
}
