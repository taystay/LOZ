using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;
using LOZ.GameState;
using System.Collections.Generic;

namespace LOZ.DungeonClasses
{
    public class ExteriorObject : IGameObjects
    {

		private ISprite sprite;
		private Point itemLocation;

        private List<IGameObjects> doors;
        public ExteriorObject(DoorType top, DoorType right, DoorType Bottom, DoorType Left)
        {
            sprite = Factories.DungeonFactory.Instance.GetExterior();
            itemLocation = DungeonInfo.Map.Location;
            doors = new List<IGameObjects>();

            Point location = DungeonInfo.Map.Location;
            location.X += DungeonInfo.DoorToCornerWidth;
            PlaceDoor(location, DoorLocation.Top, top);
            location = DungeonInfo.Map.Location;
            location.Y += DungeonInfo.DoorToCornerHeight;
            PlaceDoor(location, DoorLocation.Right, right);
            location = DungeonInfo.Map.Location;
            location.X += DungeonInfo.DoorToCornerWidth;
            location.Y += DungeonInfo.DungeonHeight - DungeonInfo.DoorHeight;
            PlaceDoor(location, DoorLocation.Bottom, Bottom);
            location = DungeonInfo.Map.Location;
            location.Y += DungeonInfo.DoorToCornerHeight;
            location.X += DungeonInfo.DungeonWidth - DungeonInfo.DoorWidth;
            PlaceDoor(location, DoorLocation.Left, Left);
        }

        public void PlaceDoor(Point location, DoorLocation side, DoorType t)
        {
            switch (t)
            {
                case DoorType.CrackedDoor:
                    doors.Add(new CrackDoor(location, side));
                    break;
                case DoorType.Hole:
                    doors.Add(new HoleWall(location, side));
                    break;
                case DoorType.Wall:
                    doors.Add(new Wall(location, side));
                    break;
                case DoorType.KeyDoor:
                    doors.Add(new KeyDoor(location, side));
                    break;
                default:
                    doors.Add(new DoorObject(location, side));
                    break;
            }
        }

		public void Update(GameTime timer)
        {

        }

		public Hitbox GetHitBox()
        {
            Rectangle i = DungeonInfo.Inside;
            return new Hitbox(i.X, i.Y, i.Width, i.Height);
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
