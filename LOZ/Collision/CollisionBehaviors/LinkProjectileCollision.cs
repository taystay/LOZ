using LOZ.GameState;

namespace LOZ.Collision
{
    public static class LinkProjectileCollision
    {
        public static void Handle(IGameObjects p)
        {
            Room.Link.TakeDamage();
        }
    }
}
