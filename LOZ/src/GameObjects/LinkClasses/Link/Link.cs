using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.Inventory;
using LOZ.GameStateReference;


namespace LOZ.LinkClasses
{
    class Link : ILink
    {
        public Point Position { get; set; }
        public ILinkState LinkState { get; set; }
        private int health = 6;
        public LinkInventory Inventory { get; set; }
        public bool Damaged { get; set; }
        private bool updatePosition = false;
        private Point newPos;
        public int Health
        {
            get { return health; }
            set
            {
                health = value;
                if (health > MaxHealth)
                {
                    health = MaxHealth;
                }
            }
        }
        public int MaxHealth { get; set; }
        public Link(Point location)
        {
            MaxHealth = 6;
            Position = location;
            LinkState = new DownIdleLinkState(this);
            Inventory = new LinkInventory();
            Inventory.Initialize();
        }
        public bool IsActive() =>
            true; 
        public void ChangeDirectionUp() =>
            LinkState.Up();
        public void ChangeDirectionDown() =>
            LinkState.Down();
        public void ChangeDirectionLeft() =>
            LinkState.Left();
        public void ChangeDirectionRight() =>
            LinkState.Right();
        public void Move() =>
            LinkState.Move();
        public void Idle() =>
            LinkState.Idle();
        public void RaiseItem(IItem item) =>
            LinkState.RaiseItem(item);
        public void Attack(Weapon currentUse) =>
            LinkState.Attack(currentUse, Position);
        public void Die() =>
            LinkState.Die();    
        public Point GetPosition() =>
            Position;
        public Hitbox GetHitBox() =>
            new Hitbox(Position.X - 48 / 2 + 14, Position.Y - 48 / 2 + 14, 20, 20);     
        public void Draw(SpriteBatch spriteBatch) =>
            LinkState.Draw(spriteBatch, Position);
        public void Draw(SpriteBatch spriteBatch, Point offset) =>
            LinkState.Draw(spriteBatch, Position + offset);

        public void KnockBack(Point vel)
        {
            if (!RoomReference.GetDebug())
                LinkState.KnockBack(vel);
        }
        public void ChangePosition(Point p)
        {
            newPos = p;
            updatePosition = true;
        }
        public void TakeDamage(int damage)
        {
            if (!RoomReference.GetDebug())
                LinkState.TakeDamage(damage);
        }
        public void Update(GameTime timer)
        {
            if (updatePosition)
            {
                Position = newPos;
                updatePosition = false;
            }
            Inventory.Update();
            LinkState.Update(timer);
        }
    }
}
