﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.GameState;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using LOZ.DungeonClasses;

namespace LOZ.Hud
{
    public class HeartComponent : HudComponent
    {
        public Point DrawPoint { get; set; }

        private const int heartOffset = 40;
        private Point _offset = new Point(0, 0);

        #region sprites
        private ISprite fullHeart;
        private ISprite halfHeart;
        #endregion    
        
        public HeartComponent(Point drawLocation)
        {
            fullHeart = DisplaySpriteFactory.Instance.GetHudHeart(true);
            halfHeart = DisplaySpriteFactory.Instance.GetHudHeart(false);
            DrawPoint = drawLocation;
        }

        public void OffsetHud(Point offset)
        {
            _offset.X += offset.X;
            _offset.Y += offset.Y;
        }

        public void ResetHud()
        {
            _offset = new Point();
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //725, 800 is draw location
            int linkCurrentHealth = Room.Link.Health;
            if (linkCurrentHealth < 0) return;


            Point currentDrawPoint = new Point(DrawPoint.X + _offset.X, DrawPoint.Y + _offset.Y);                           
            for (int i = 0; i < linkCurrentHealth / 2; i++)
            {
                fullHeart.Draw(spriteBatch, currentDrawPoint);
                currentDrawPoint.X += heartOffset;
            }

            if (linkCurrentHealth % 2 == 1)
            {
                halfHeart.Draw(spriteBatch, currentDrawPoint);
            }
        }
    }
}