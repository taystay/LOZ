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
            itemLocation = Info.Map.Location;
            doors = new List<IGameObjects>();
            this.objectsInGame = objectsInGame;

            PlaceInvisibleBlocks(top,right,bottom,left);

            Point location = new Point(Info.Map.X + Info.DoorToCornerWidth, Info.Map.Y);
            PlaceDoor(location, DoorLocation.Top, top);

            location = new Point(Info.Map.X, Info.Map.Y + Info.DoorToCornerHeight);
            PlaceDoor(location, DoorLocation.Left, left);

            location = new Point(Info.Map.X + Info.DoorToCornerWidth, Info.Map.Y + Info.DungeonHeight - Info.DoorHeight);
            PlaceDoor(location, DoorLocation.Bottom, bottom);

            location = new Point(Info.Map.X + Info.DungeonWidth - Info.DoorWidth, Info.Map.Y + Info.DoorToCornerHeight);
            PlaceDoor(location, DoorLocation.Right, right);
        }

        public void PlaceInvisibleBlocks(DoorType top, DoorType right, DoorType Bottom, DoorType Left)
        {
            //TOP
            Point Location = Info.Inside.Location;
            Location.Y -= Info.BlockWidth;
            if (top != DoorType.Door && top != DoorType.Hole)
                objectsInGame.Add(new InvisibleBlock(Location, Info.Inside.Width, Info.BlockWidth));
            else
            {
                objectsInGame.Add(new InvisibleBlock(Location, Info.Inside.Width / 2 - Info.BlockWidth / 2, Info.BlockWidth));
                Location.X += Info.DoorToCornerWidth - Info.BlockWidth / 2;
                objectsInGame.Add(new DoorCollider(Location.X - Info.DoorWidth, Location.Y - Info.BlockWidth, Info.BlockWidth * 3, Info.BlockWidth));
                objectsInGame.Add(new InvisibleBlock(Location, Info.Inside.Width / 2 - Info.BlockWidth / 2, Info.BlockWidth));
                Location.X -= Info.BlockWidth + Info.BlockWidth / 2;
                Location.Y -= Info.BlockWidth;            
            }

            //LEFT
            Location = Info.Inside.Location;
            Location.X -= Info.BlockWidth;
            if (Left != DoorType.Door && Left != DoorType.Hole)
                objectsInGame.Add(new InvisibleBlock(Location, Info.BlockWidth, Info.Inside.Height));
            else
            {
                objectsInGame.Add(new InvisibleBlock(Location, Info.BlockWidth, Info.Inside.Height / 2 - Info.BlockWidth / 2));
                Location.Y += Info.DoorToCornerHeight - Info.BlockWidth / 2;
                objectsInGame.Add(new DoorCollider(Location.X - Info.BlockWidth, Location.Y - Info.DoorWidth, Info.BlockWidth, Info.BlockWidth * 3));
                objectsInGame.Add(new InvisibleBlock(Location, Info.BlockWidth, Info.Inside.Height / 2 - Info.BlockWidth / 2));
                Location.X -= Info.BlockWidth;
                Location.Y -= Info.BlockWidth + Info.BlockWidth / 2;
            }

            //RIGHT
            Location = Info.Inside.Location;
            Location.X += Info.Inside.Width;
            if (right != DoorType.Door && right != DoorType.Hole)
                objectsInGame.Add(new InvisibleBlock(Location, Info.BlockWidth, Info.Inside.Height));
            else
            {
                objectsInGame.Add(new InvisibleBlock(Location, Info.BlockWidth, Info.Inside.Height / 2 - Info.BlockWidth / 2));
                Location.Y += Info.DoorToCornerHeight - Info.BlockWidth / 2;
                objectsInGame.Add(new DoorCollider(Location.X + Info.BlockWidth, Location.Y - Info.DoorWidth, Info.BlockWidth, Info.BlockWidth * 3));
                objectsInGame.Add(new InvisibleBlock(Location, Info.BlockWidth, Info.Inside.Height / 2 - Info.BlockWidth / 2));
                Location.Y -= Info.BlockWidth + Info.BlockWidth / 2;            
            }

            //BOTTOM
            Location = Info.Inside.Location;
            Location.Y += Info.Inside.Height;
            if (Bottom != DoorType.Door && Bottom != DoorType.Hole)
                objectsInGame.Add(new InvisibleBlock(Location, Info.Inside.Width, Info.BlockWidth));
            else
            {
                objectsInGame.Add(new InvisibleBlock(Location, Info.Inside.Width / 2 - Info.BlockWidth / 2, Info.BlockWidth));
                Location.X += Info.DoorToCornerWidth - Info.BlockWidth / 2;
                objectsInGame.Add(new DoorCollider(Location.X - Info.DoorWidth, Location.Y + Info.BlockWidth, Info.BlockWidth * 3, Info.BlockWidth));
                objectsInGame.Add(new InvisibleBlock(Location, Info.Inside.Width / 2 - Info.BlockWidth / 2, Info.BlockWidth));
                Location.X -= 72;            
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
