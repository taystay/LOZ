using LOZ.ItemsClasses;

namespace LOZ.Collision
{
    public static class LinkItemCollision
    {
        public static void Handle(IGameObjects item)
        {
            IItem item_user = (IItem)item;
            if(!Type.Check(item, typeof(IPlayerProjectile)))
                item_user.KillItem();
        }
    }
}
