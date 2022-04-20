using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.GameStateReference;

namespace LOZ.DungeonClasses
{
    public class ExteriorObject : IGameObjects
    {
		private ISprite sprite;
		private Point itemLocation;
        private List<IGameObjects> doors;
        private List<IGameObjects> currentItems;
        private List<IGameObjects> gameObjectsReference;
        private DoorType _top, _right, _bottom, _left, changeType;
        private bool needsUpdate = false;
        private DoorLocation changeLocation;

        public ExteriorObject(DoorType top, DoorType right, DoorType bottom, DoorType left, List<IGameObjects> objectsInGame)
        {
            _top = top;
            _right = right;
            _bottom = bottom;
            _left = left;
            gameObjectsReference = objectsInGame;
            sprite = Factories.DungeonFactory.Instance.GetExterior();
            itemLocation = Info.Map.Location;
            doors = new List<IGameObjects>();
            currentItems = new List<IGameObjects>();

            ExteriorColliders.PlaceColliders(top, right, bottom, left, currentItems);
            ExteriorColliders.PlaceDoors(top, right, bottom, left, doors);       
            
            foreach(IGameObjects i in  currentItems)
            {
                objectsInGame.Add(i);
            }
        }
        public bool IsActive() => true;
        public bool CanGoUp() =>
            _top == DoorType.Door || _top == DoorType.Hole;
        public bool CanGoRight() =>
            _right == DoorType.Door || _right == DoorType.Hole;
        public bool CanGoDown() =>
            _bottom == DoorType.Door || _bottom == DoorType.Hole;
        public bool CanGoLeft() =>
            _left == DoorType.Door || _left == DoorType.Hole;
        public void ChangeDoorOnUpdate(DoorLocation location, DoorType t)
        {
            changeLocation = location;
            changeType = t;
            needsUpdate = true;
        }
        
		public void Update(GameTime timer)
        {                  
            if(needsUpdate)
            {
                foreach (IGameObjects i in currentItems)
                {
                    gameObjectsReference.Remove(i);
                }
                doors = new List<IGameObjects>();
                currentItems = new List<IGameObjects>();
                switch (changeLocation)
                {
                    case DoorLocation.Bottom:
                        _bottom = changeType;
                        break;
                    case DoorLocation.Left:
                        _left = changeType;
                        break;
                    case DoorLocation.Right:
                        _right = changeType;
                        break;
                    default:
                        _top = changeType;
                        break;
                }
                ExteriorColliders.PlaceColliders(_top, _right, _bottom, _left, currentItems);
                ExteriorColliders.PlaceDoors(_top, _right, _bottom, _left, doors);
                foreach (IGameObjects i in currentItems)
                {
                    gameObjectsReference.Add(i);
                }
                needsUpdate = false;
            }
            
        }
		public Hitbox GetHitBox() =>
            new Hitbox(0, 0,0 , 0);
		public virtual void Draw(SpriteBatch spriteBatch) =>
            Draw(spriteBatch, new Point(0, 0));
        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            foreach (IGameObjects door in doors)
            {
                door.Draw(spriteBatch, offset);
            }
            sprite.Draw(spriteBatch, itemLocation + offset);
            foreach (IGameObjects door in doors)
            {
                door.Draw(spriteBatch, offset);               
            }
        }

    }
}
