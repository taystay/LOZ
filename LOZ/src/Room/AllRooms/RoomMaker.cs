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
            rooms.Add(new Room26(_pathName));
            rooms.Add(new Room46(_pathName));
            rooms.Add(new Room35(_pathName));
            rooms.Add(new Room34(_pathName));
            rooms.Add(new Room24(_pathName));
            rooms.Add(new Room44(_pathName));
            rooms.Add(new Room33(_pathName));
            rooms.Add(new Room23(_pathName));
            rooms.Add(new Room13(_pathName));
            rooms.Add(new Room43(_pathName));
            rooms.Add(new Room53(_pathName));
            rooms.Add(new Room32(_pathName));
            rooms.Add(new Room31(_pathName));
            rooms.Add(new Room21(_pathName));
            rooms.Add(new Room52(_pathName));
            rooms.Add(new Room62(_pathName));
            rooms.Add(new DevRoom());
            return rooms;
        }
    }
}
