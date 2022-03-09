using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;
using LOZ.GameState;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
using LOZ.CommandClasses;
using LOZ.LinkClasses; 

namespace LOZ.DungeonClasses
{
    public class ExteriorObject : IGameObjects
    {
		private ISprite sprite;
		private Point itemLocation;
        private List<IGameObjects> doors;
        private List<IGameObjects> currentItems;
        private DoorType _top, _right, _bottom, _left, changeType;
        private bool needsUpdate = false;
        private DoorLocation changeLocation;
        private bool hasChangedBefore = false;

        public ExteriorObject(DoorType top, DoorType right, DoorType bottom, DoorType left, List<IGameObjects> objectsInGame)
        {
            _top = top;
            _right = right;
            _bottom = bottom;
            _left = left;
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

        public void ChangeDoorOnUpdate(DoorLocation location, DoorType t)
        {
            if (!hasChangedBefore) { 
                 changeLocation = location;
                changeType = t;
                needsUpdate = true;
                hasChangedBefore = true;
            }
        }
        
		public void Update(GameTime timer)
        {
            
            
            if(needsUpdate)
            {
                List<IGameObjects> objectsInGame = CurrentRoom.Instance.Room.gameObjects;
                foreach (IGameObjects i in currentItems)
                {
                    objectsInGame.Remove(i);
                    System.Diagnostics.Debug.WriteLine("" + i.ToString());
                }
                doors = new List<IGameObjects>();
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
                ExteriorColliders.PlaceColliders(_top, _right, _bottom, _left, objectsInGame);
                ExteriorColliders.PlaceDoors(_top, _right, _bottom, _left, doors);
            }
            needsUpdate = false;
        }
		public Hitbox GetHitBox()
        {            
            return new Hitbox(0, 0,0 , 0);
        }
		public virtual void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, itemLocation);
            foreach(IGameObjects d in doors)
            {
                d.Draw(spriteBatch);
               
            }
		}

    }
}
