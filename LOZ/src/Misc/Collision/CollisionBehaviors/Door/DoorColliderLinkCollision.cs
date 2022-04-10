using Microsoft.Xna.Framework;
using LOZ.Room;
using LOZ.DungeonClasses;

namespace LOZ.Collision
{
    public static class DoorColliderLinkCollision
    {
        public static void Handle(IGameObjects obj)
        {
            
            //GET WHERE COLLIDER IS
            Point collider = obj.GetHitBox().ToRectangle().Location;

            //GET CENTER
            Point center = Info.Map.Location;
            center.X += Info.DoorToCornerWidth + 48;
            center.Y += Info.DoorToCornerHeight + 48;

            if (collider.X - center.X > 200) 
                PlaceLink.RightDungeonDoor();
            else if (center.X - collider.X > 200)
                PlaceLink.LeftDungeonDoor();
            else if (collider.Y - center.Y > 150)
                PlaceLink.BottomDungeonDoor();
            else if (center.Y - collider.Y > 150)
                PlaceLink.TopDungeonDoor();

        }
    }
}
