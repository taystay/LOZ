using System.Collections.Generic;
using LOZ.Collision;

namespace LOZ.Room
{
    class StartRoom : RoomAbstract
    {
        public StartRoom(List<IGameObjects> floorAndDoors)
        {
            gameObjects = floorAndDoors;
        }

        //will change the parser so that it passes the list of IGameobject of the floor and door and then
        // each room will have a private method to add the enemies and items
        //that is what I think could work easily and make it most accessible
    }
}
