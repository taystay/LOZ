using LOZ.GameState;

namespace LOZ.Collision
{
    public static class LinkEnemyCollision
    {
        public static void Handle()
        {
            CurrentRoom.Room.Link.TakeDamage();
        }
    }
}
