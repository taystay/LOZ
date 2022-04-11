using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    public interface IRoom
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Point offSet);
        //public void DrawRoomTransition(SpriteBatch spriteBatch, Point offSet);
        public void DrawWithoutLink(SpriteBatch spriteBatch, Point offset);
        public void RemoveItems();
        public ExteriorObject GetExtObj();
        public void AddItem(IGameObjects item);
        public List<IGameObjects> GetObjectsList();
    }
}
