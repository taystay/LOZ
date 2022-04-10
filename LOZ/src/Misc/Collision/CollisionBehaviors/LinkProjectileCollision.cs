using LOZ.Room;

namespace LOZ.Collision
{
    public static class LinkProjectileCollision
    {
        public static void Handle(IGameObjects p)
        {
            CurrentRoom.link.TakeDamage(1);
        }
    }
}
