using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.GameState;
using LOZ.DungeonClasses;
using System.Collections.Generic;


namespace LOZ.Camera
{
    class CameraManager
    {
        SpriteBatch spriteBatch;
        Matrix translation;
        Texture2D roomLayout;
        Dictionary<Point3D, List<Room>> _rooms;
        Point middle; 

        public CameraManager(ContentManager content, Dictionary<Point3D, List<Room>> roomList)
        {
            translation = Matrix.CreateTranslation(Info.Map.Width / 2, Info.Map.Height / 2, 0);
            _rooms = roomList;
            //middle = new Point(Info.Map.Width / 2, Info.Map.Height / 2);
        }

        public void TranslationToRoom(Point3D roomCoord) {

            //translation = Matrix.CreateTranslation();
        }
        //what to do
        //using dungeons rooms I will create the scale
        //then in draw it will constantly update pixel by pixel for room translation
        //transition from the dungeonRoom png to show
        //then all the item spawn
        


    }
}
