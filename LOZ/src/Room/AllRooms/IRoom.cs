using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace LOZ.Room
{
    public interface IRoom 
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public void RemoveItems();
    }
}
