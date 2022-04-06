using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.Sound;
using LOZ.SpriteClasses;

namespace LOZ.ItemsClasses
{
    public class Portal : IGameObjects
    {
        private ISprite sprite;
        public Point _itemLocation;   
        private bool spriteActivity = true;
        private bool spriteChanged = false;
        private int framesPassed = 0;
        private Color _color;
        int width = 0, height = 0;
        int secondW = 0, secondH = 0;
        Vector2 velocity;

        #region type
        public bool hasCollided { get; set; } = false;
        public bool isBlue { get; set; } = false;
        public bool bottomSide { get; set; } = false;
        public bool upSide { get; set; } = false;
        public bool rightSide { get; set; } = false;
        public bool leftSide { get; set; } = false;
        #endregion

        /* 0 = up, 1 = right, 2 = down, 3 = left... 0 = blue, 1 = orange*/
        public Portal(Point itemLocation, int identifier, int color)
        {
            _itemLocation = itemLocation;

            if (color == 0)
            {
                _color = Color.Blue;
                isBlue = true;
            }
            else
            {
                _color = Color.Orange;
            }

            switch (identifier)
            {
                case 0:
                    width = 10;
                    height = 20;
                    secondW = 48;
                    secondH = 10;
                    bottomSide = true;
                    velocity = new Vector2(0,-4);
                    break;
                case 1:
                    width = 20;
                    height = 10;
                    secondW = 10;
                    secondH = 48;
                    leftSide = true;
                    velocity = new Vector2(4,0);
                    break;
                case 2:
                    width = 10;
                    height = 20;
                    secondW = 48;
                    secondH = 10;
                    upSide = true;
                    velocity = new Vector2(0,4);
                    break;
                default:
                    width = 20;
                    height = 10;
                    secondW = 10;
                    secondH = 48;
                    rightSide = true;
                    velocity = new Vector2(-4,0);
                    break;
            }

            sprite = DisplaySpriteFactory.Instance.GetMapWalk(width, height);
        }
        public void Collide()
        {
            hasCollided = true;
            velocity = new Vector2();
            sprite = DisplaySpriteFactory.Instance.GetMapWalk(secondW, secondH);
        }
        public void KillItem()
        {
            if (spriteChanged) return;
            spriteActivity = false;
        }
        public Hitbox GetHitBox()
        {
            if(!hasCollided)
                return  new Hitbox(_itemLocation.X - width / 2 , _itemLocation.Y - height / 2, width, height);
            else
                return new Hitbox(_itemLocation.X - secondW / 2, _itemLocation.Y - secondH / 2, secondW, secondH);
        }
        public void Update(GameTime gameTime)
        {
            _itemLocation.X += (int)velocity.X;
            _itemLocation.Y += (int)velocity.Y;
            sprite.Update(gameTime);
        }
        
        public void SetPosition(Point position)
        {
            _itemLocation = position;
        }
        public bool SpriteActive()
        {
            return spriteActivity;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, _itemLocation, _color);
        }
    }
}
