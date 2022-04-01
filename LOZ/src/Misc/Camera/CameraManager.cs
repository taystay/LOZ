﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.GameState;
using LOZ.DungeonClasses;
using System.Collections.Generic;
using LOZ.Factories;


namespace LOZ.Camera
{
    class CameraManager
    {
        private SpriteBatch spriteBatch;
        
        private Matrix translation;
        private Texture2D transparentB;
        private Dictionary<Point3D, List<Room>> _rooms;
        Point middle;
        //private int xPosition;
        //private int yPosition;

        public CameraManager(ContentManager content, Dictionary<Point3D, List<Room>> roomList)
        {
            transparentB = DisplaySpriteFactory.Instance.TransparentBackground();
             middle = new Point(Info.Map.Width / 2, Info.Map.Height / 2);
            _rooms = roomList;
        }

        public void TranslationToRoom(Point3D roomCoord)
        {
            Point3D link = CurrentRoom.Instance.linkCoor;
            //Positive X mean the transition to the left otherwise right
            //Positive Y mean going up in rooms
            if (link.X < roomCoord.X)
            {   //going to the right
                middle.X += 1;
            }
            else
            {     
                middle.X -= 1;
            }

            if (link.Y < roomCoord.Y)
            {//going up 
                middle.Y -= 1;
            }
            else
            {
                middle.Y += 1;
            }


        }

        public void Draw() {

            //Figuire out what text to draw in... Maybe past the room object in here and then load the translation matrix to
            //each to show a transition over thousands of iteration 

            translation = Matrix.CreateTranslation(middle.X, middle.Y, 0);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp,null,null,null,translation);
            spriteBatch.Draw(transparentB, new Vector2(Info.Map.X, Info.Map.Y), Color.White);
            spriteBatch.End();


        }


    }
}