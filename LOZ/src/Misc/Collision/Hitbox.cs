using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;

namespace LOZ.Collision
{
    public class Hitbox
    {
        private Rectangle box;
        private ISprite yellowPixel;
        public Hitbox(int x, int y, int width, int height)
        {
            box = new Rectangle(x,y,width,height);
            yellowPixel = Factories.ItemFactory.Instance.CreateYellowPixelSprite(box);
        }
        public void Update(int x, int y, int width, int height)
        {
            box = new Rectangle(x, y, width, height);
        }
        public void Update(int dx, int dy)
        {
            box.X += dx;
            box.Y += dy;
        }
        public Rectangle ToRectangle()
        {
            return box;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            yellowPixel.Draw(spriteBatch, new Point());
        }
        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            //yellowPixel.Draw(spriteBatch,)
        }
    }
}
