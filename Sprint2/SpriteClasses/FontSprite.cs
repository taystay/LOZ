using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class FontSprite : ISprite
    {
        private String Text;
        private SpriteFont Font;
        public FontSprite(SpriteFont font, string text)
        {
            Font = font;
            Text = text;
        }
        public void LoadContent() { }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(Font, Text, location.ToVector2(), Color.White);

            spriteBatch.End();
        }
    }
}
