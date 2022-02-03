using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Sprint2
{
    interface IEnemy
    {

        public void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch);



    }
}
