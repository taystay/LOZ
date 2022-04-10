using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    public interface IRoom
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Point offSet);
        //public void DrawRoomTransition(SpriteBatch spriteBatch, Point offSet);
        public void RemoveItems();
        public ExteriorObject GetExtObj();
    }
}
