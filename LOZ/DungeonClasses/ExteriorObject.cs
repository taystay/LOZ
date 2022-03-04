using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;
using LOZ.GameState;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;

namespace LOZ.DungeonClasses
{
    public class ExteriorObject : IGameObjects
    {

		private ISprite sprite;
		private Point itemLocation;
        private List<IGameObjects> objectsInGame;

        private List<IGameObjects> doors;
        public ExteriorObject(DoorType top, DoorType right, DoorType bottom, DoorType left, List<IGameObjects> objectsInGame)
        {
            sprite = Factories.DungeonFactory.Instance.GetExterior();
            itemLocation = DungeonInfo.Map.Location;
            doors = new List<IGameObjects>();
            this.objectsInGame = objectsInGame;

            PlaceInvisibleBlocks(top,right,bottom,left);

            //TOP
            Point location = DungeonInfo.Map.Location;
            location.X += DungeonInfo.DoorToCornerWidth;
            PlaceDoor(location, DoorLocation.Top, top);
            //LEFT
            location = DungeonInfo.Map.Location;
            location.Y += DungeonInfo.DoorToCornerHeight;
            PlaceDoor(location, DoorLocation.Left, left);
            //BOTTOM
            location = DungeonInfo.Map.Location;
            location.X += DungeonInfo.DoorToCornerWidth;
            location.Y += DungeonInfo.DungeonHeight - DungeonInfo.DoorHeight;
            PlaceDoor(location, DoorLocation.Bottom, bottom);
            //RIGHT
            location = DungeonInfo.Map.Location;
            location.Y += DungeonInfo.DoorToCornerHeight;
            location.X += DungeonInfo.DungeonWidth - DungeonInfo.DoorWidth;
            PlaceDoor(location, DoorLocation.Right, right);
        }

        public void PlaceInvisibleBlocks(DoorType top, DoorType right, DoorType Bottom, DoorType Left)
        {
            //TOP
            Point Location = DungeonInfo.Inside.Location;
            Location.Y -= 48;
            if (top != DoorType.Door && top != DoorType.Hole)
                objectsInGame.Add(new InvisibleBlock(Location, DungeonInfo.Inside.Width, 48));
            else
            {
                objectsInGame.Add(new InvisibleBlock(Location, DungeonInfo.Inside.Width / 2 - 24, 48));
                Location.X += DungeonInfo.DoorToCornerWidth - 24;
                objectsInGame.Add(new InvisibleBlock(Location, DungeonInfo.Inside.Width / 2 - 24, 48));
                Location.X -= 72;
                Location.Y -= 48;
                //objectsInGame.Add(new DoorObject(Location, DoorLocation.Top));
            }

            //LEFT
            Location = DungeonInfo.Inside.Location;
            Location.X -= 48;
            if (Left != DoorType.Door && Left != DoorType.Hole)
                objectsInGame.Add(new InvisibleBlock(Location, 48, DungeonInfo.Inside.Height));
            else
            {
                objectsInGame.Add(new InvisibleBlock(Location, 48, DungeonInfo.Inside.Height / 2 - 24));
                Location.Y += DungeonInfo.DoorToCornerHeight - 24;
                objectsInGame.Add(new InvisibleBlock(Location, 48, DungeonInfo.Inside.Height / 2 - 24));
                Location.X -= 48;
                Location.Y -= 72;
                objectsInGame.Add(new DoorObject(Location, DoorLocation.Left));
            }

            //RIGHT
            Location = DungeonInfo.Inside.Location;
            Location.X += DungeonInfo.Inside.Width;
            if (right != DoorType.Door && right != DoorType.Hole)
                objectsInGame.Add(new InvisibleBlock(Location, 48, DungeonInfo.Inside.Height));
            else
            {
                objectsInGame.Add(new InvisibleBlock(Location, 48, DungeonInfo.Inside.Height / 2 - 24));
                Location.Y += DungeonInfo.DoorToCornerHeight - 24;
                objectsInGame.Add(new InvisibleBlock(Location, 48, DungeonInfo.Inside.Height / 2 - 24));
                Location.Y -= 72;
                //objectsInGame.Add(new DoorObject(Location, DoorLocation.Right));
            }

            //BOTTOM
            Location = DungeonInfo.Inside.Location;
            Location.Y += DungeonInfo.Inside.Height;
            if (Bottom != DoorType.Door && Bottom != DoorType.Hole)
                objectsInGame.Add(new InvisibleBlock(Location, DungeonInfo.Inside.Width, 48));
            else
            {
                objectsInGame.Add(new InvisibleBlock(Location, DungeonInfo.Inside.Width / 2 - 24, 48));
                Location.X += DungeonInfo.DoorToCornerWidth - 24;
                objectsInGame.Add(new InvisibleBlock(Location, DungeonInfo.Inside.Width / 2 - 24, 48));
                Location.X -= 72;
                //objectsInGame.Add(new DoorObject(Location, DoorLocation.Bottom));
            }

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
            return new Hitbox(i.X, i.Y,0 , 0);
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
