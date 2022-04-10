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
        public Dictionary<Point3D,IRoom> CreateAllRooms() {
            Dictionary<Point3D,IRoom> rooms = new Dictionary<Point3D, IRoom>();

            rooms.Add(new Point3D(3,6,0),new StartRoom(_pathName));
            rooms.Add(new Point3D(2, 6, 0),new Room26(_pathName));
            rooms.Add(new Point3D(4, 6, 0),new Room46(_pathName));
            rooms.Add(new Point3D(3, 5, 0),new Room35(_pathName));
            rooms.Add(new Point3D(3, 4, 0),new Room34(_pathName));
            rooms.Add(new Point3D(2, 4, 0),new Room24(_pathName));
            rooms.Add(new Point3D(4, 4, 0),new Room44(_pathName));
            rooms.Add(new Point3D(3, 3, 0),new Room33(_pathName));
            rooms.Add(new Point3D(2, 3, 0),new Room23(_pathName));
            rooms.Add(new Point3D(1, 3, 0),new Room13(_pathName));
            rooms.Add(new Point3D(4, 3, 0),new Room43(_pathName));
            rooms.Add(new Point3D(5, 3, 0),new Room53(_pathName));
            rooms.Add(new Point3D(3, 2, 0),new Room32(_pathName));
            rooms.Add(new Point3D(3, 1, 0),new Room31(_pathName));
            rooms.Add(new Point3D(2, 1, 0),new Room21(_pathName));
            rooms.Add(new Point3D(5, 2, 0),new Room52(_pathName));
            rooms.Add(new Point3D(6, 2, 0),new Room62(_pathName));
            rooms.Add(new Point3D(2, 1, 1), new Room211(_pathName));
            rooms.Add(new Point3D(2, 6, 0),new DevRoom());
            return rooms;
        }
    }
}
