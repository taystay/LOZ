using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    public interface IRoom
    {
        public List<IGameObjects> RemovedInDetection { get; set; }
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Point offSet);
        public void DrawWithoutLink(SpriteBatch spriteBatch, Point offset);
        public void RemoveItems();
        public ExteriorObject GetExtObj();
        public void AddItem(IGameObjects item);
        public List<IGameObjects> GetObjectsList();
        public void UpdateExterior(DoorType t, DoorLocation l);
        public void PlaceLinkX(int dx);
        public void PlaceLinkY(int dy);
        public void PlaceLinkZ(int dz);
    }
}
