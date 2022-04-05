using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.Sound;
using LOZ.SpriteClasses;
using LOZ.GameState;
using System.Collections.Generic;

namespace LOZ.ItemsClasses
{
    public static class PortalManager
    {
        private static int currentColor = 0;
        private static IGameObjects orangePortal { get; set; }
        private static IGameObjects bluePortal { get; set; }
        public static int getColor()
        {          
            return currentColor;           
        }
        public static void nextColor()
        {
            currentColor++;
            currentColor %= 2;
        }
        private static void GoThroughOrange(IGameObjects o)
        {
            Portal op = (Portal)orangePortal;
            Portal bp = (Portal)bluePortal;
            Hitbox objectBox = o.GetHitBox();
            Hitbox portalBox = bp.GetHitBox();
            if (!op.hasCollided || !bp.hasCollided) return;
        }
        private static void GoThroughBlue(IGameObjects o)
        {
            Portal op = (Portal)orangePortal;
            Portal bp = (Portal)bluePortal;
            Hitbox objectBox = o.GetHitBox();
            Hitbox portalBox = op.GetHitBox();
            if (!op.hasCollided || !bp.hasCollided) return;
        }
        public static void MoveThroughPortal(Portal p, IGameObjects o)
        {
            if(p.Equals(orangePortal))
            {
                GoThroughOrange(o);
            } else
            {
                GoThroughBlue(o);
            }
        }
        public static void AddPortal(Portal p)
        {
            nextColor();
            if(p.isBlue)
            {
                CurrentRoom.Instance.Room.GameObjects.Remove(bluePortal);
                bluePortal = p;
            } else
            {
                CurrentRoom.Instance.Room.GameObjects.Remove(orangePortal);
                orangePortal = p;
            }
        }
    }
}
