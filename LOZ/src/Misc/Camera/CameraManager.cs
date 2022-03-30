using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LOZ.Camera
{
    class CameraManager
    {
        SpriteBatch spriteBatch;
        Matrix translation;
        Texture2D roomLayout;

        public CameraManager(ContentManager content)
        {
            translation = Matrix.CreateTranslation(0, 0, 0);
            roomLayout = content.Load<Texture2D>("dungeonRooms");
            translation = Matrix.CreateScale(2f);
        }

        public void TranslationToRoom(int x, int y) {



        }
        //what to do
        //using dungeons rooms I will create the scale
        //then in draw it will constantly update pixel by pixel for room translation
        //transition from the dungeonRoom png to show
        //then all the item spawn
        


    }
}
