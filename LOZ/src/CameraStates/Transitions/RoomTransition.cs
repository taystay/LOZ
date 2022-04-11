using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Hud;
using LOZ.Room;
using LOZ.GameStateReference;
using LOZ.DungeonClasses;

namespace LOZ.src.CameraStates
{
    public class RoomTransition : ICameraState
    {
        private int _dx;
        private int _dy;
        private int _dz;
        private int offsetDist = Info.DungeonWidth;
        private int updatesLeft;
        private int updates;
        private Point delta;
        private int deltaAmount = 8;
        private Game1 _gameObject;
        private bool hasUpdated = false;
        public RoomTransition(Game1 gameObject, int dx, int dy, int dz)
        {
            _gameObject = gameObject;
            
            _dx = dx;
            _dy = dy;
            _dz = dz;
            if (dx != 0)
                offsetDist = Info.DungeonWidth;
            else
                offsetDist = Info.DungeonHeight;
            updatesLeft = offsetDist / deltaAmount;
            if (dx < 0)
                delta = new Point(deltaAmount, 0);
            else if (dx > 0)
                delta = new Point(-deltaAmount, 0);

            if (dy < 0 || dz < 0)
                delta = new Point(0, deltaAmount);
            else if (dy > 0 || dz > 0)
                delta = new Point(0, -deltaAmount);

        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            if(!hasUpdated)
            {
                IRoom r = RoomReference.GetChangeRoom(_dx, _dy, _dz);
                if(r != null)
                    r.Update(gameTime);
                hasUpdated = true;
            }
            updatesLeft--;
            updates++;
            if (updatesLeft <= 0)
            {
                
                HudElement inv = new InventoryHud(RoomReference.GetInventory());
                inv.Offset(new Point(0, -630));
                RoomReference.SetLinkPosition(_dx, _dy, _dz);
                RoomReference.GetLink().Update(gameTime);
                RoomReference.SetRoomLocation(_dx, _dy, _dz);
                _gameObject.CameraState = new FirstDungeon(_gameObject, inv);
                         
            }             
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Point changeRoomOffset = new Point(-delta.X * updatesLeft, -delta.Y * updatesLeft);
            Point oldRoomOffset = new Point(delta.X * updates, delta.Y * updates);
            IRoom nextRoom = RoomReference.GetChangeRoom(_dx, _dy, _dz);
            if(nextRoom != null)
                nextRoom.DrawWithoutLink(spriteBatch, new Point() + changeRoomOffset);
            RoomReference.GetCurrRoom().DrawWithoutLink(spriteBatch, new Point()+ oldRoomOffset);
        }
    }
}
