using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.GameState;
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
                CurrentRoom.Instance.MoveRoomDirection(1, 0, 0);
            else if (center.X - collider.X > 200)
                CurrentRoom.Instance.MoveRoomDirection(-1, 0, 0);
            else if (collider.Y - center.Y > 150)
                CurrentRoom.Instance.MoveRoomDirection(0, 1, 0);
            else if (center.Y - collider.Y > 150)
                CurrentRoom.Instance.MoveRoomDirection(0, -1, 0);

        }
    }
}
