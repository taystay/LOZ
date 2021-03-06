using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.Sound;

namespace LOZ.ItemsClasses
{
    class Bomb : IPlayerProjectile
    {
        private bool spriteChanged = false;
        private int framesPassed = 0;
        private const int bombActiveTime = 100;
        private const int deadFrames = 25;
        public Bomb(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateBombSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 34;
            Damage = 3;
            InventoryItem = true;
        }
        public override void KillItem()
        {
            if (spriteChanged) return;
            spriteActivity = false;
        }
        public override Hitbox GetHitBox()
        {
            if (spriteChanged)
                return  new Hitbox(_itemLocation.X - 75 / 2 , _itemLocation.Y - 75 / 2, 75, 75);
            else
                return new Hitbox(-50, -50,0,0);
        }
        public override void Update(GameTime gameTime)
        {
            if (spriteActivity && framesPassed >= bombActiveTime)
                spriteActivity = false;
            UpdatePosition();
            sprite.Update(gameTime);
            framesPassed++;
            if (spriteChanged) return;
            if (framesPassed >= bombActiveTime - deadFrames) {
                spriteChanged = true;
                sprite = ItemFactory.Instance.CreateDeadBombSprite();
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Bomb_Blow);
            }          
        }
    }
}
