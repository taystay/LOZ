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
            yellowPixel = Factories.ItemFactory.Instance.CreateYellowPixelSprite();
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
            for (int i = 0; i < box.Width; i += 2)
                yellowPixel.Draw(spriteBatch, new Point(box.X + i, box.Y));

            for (int i = 0; i < box.Width; i += 2)
                yellowPixel.Draw(spriteBatch, new Point(box.X + i, box.Y + box.Height));

            for (int i = 0; i < box.Height; i += 2)
                yellowPixel.Draw(spriteBatch, new Point(box.X, box.Y + i));

            for (int i = 0; i < box.Height; i += 2)
                yellowPixel.Draw(spriteBatch, new Point(box.X + box.Width, box.Y + i));

        }
    }
}
