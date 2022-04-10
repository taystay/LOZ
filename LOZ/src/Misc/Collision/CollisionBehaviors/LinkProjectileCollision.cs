using LOZ.GameStateReference;

namespace LOZ.Collision
{
    public static class LinkProjectileCollision
    {
        public static void Handle(IGameObjects p)
        {
            RoomReference.GetLink().TakeDamage(1);
        }
    }
}
