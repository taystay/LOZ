using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.Sound;
using LOZ.SpriteClasses;
using LOZ.GameState;
using System.Collections.Generic;
using LOZ.LinkClasses;

namespace LOZ.ItemsClasses
{
    public static class PortalManager
    {
        private static int currentColor = 0;
        private static IGameObjects orangePortal { get; set; }
        private static Point3D orangeRoom { get; set; }
        private static IGameObjects bluePortal { get; set; }
        private static Point3D blueRoom { get; set; }
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
            Hitbox portalBox = bp.GetHitBox();
            if (!op.hasCollided || !bp.hasCollided) return;
            if(TypeC.Check(o, typeof(ILink)))
            {
                ILink link = (ILink)o;
                CurrentRoom.Instance.linkCoor = blueRoom;
                if (bp.upSide)
                    Room.Link.Position = new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y - link.GetHitBox().ToRectangle().Height - 5);
                else if (bp.leftSide)
                    Room.Link.Position = new Point(portalBox.ToRectangle().X - link.GetHitBox().ToRectangle().Width - 5, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2);
                else if (bp.rightSide)
                    Room.Link.Position = new Point(portalBox.ToRectangle().X + link.GetHitBox().ToRectangle().Width + 5, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2);
                else if (bp.bottomSide)
                    Room.Link.Position = new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y + link.GetHitBox().ToRectangle().Height + 5);
            }
            else if (TypeC.Check(o, typeof(IItem)))
            {
                IItem item = (IItem)o;
                if (!blueRoom.Equals(orangeRoom))
                {
                    Room bluer = CurrentRoom.Instance.Rooms[blueRoom];
                    Room oranger = CurrentRoom.Instance.Rooms[orangeRoom];
                    bluer.GameObjects.Add(o);
                    oranger.GameObjects.Remove(o);
                }
                if (bp.upSide)
                    item.SetPosition(new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y - item.GetHitBox().ToRectangle().Height));
                else if (bp.leftSide)
                    item.SetPosition(new Point(portalBox.ToRectangle().X - item.GetHitBox().ToRectangle().Width, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2));
                else if (bp.rightSide)
                    item.SetPosition(new Point(portalBox.ToRectangle().X + item.GetHitBox().ToRectangle().Width, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2));
                else if (bp.bottomSide)
                    item.SetPosition(new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y + item.GetHitBox().ToRectangle().Height));
            }
        }
        private static void GoThroughBlue(IGameObjects o)
        {
            Portal op = (Portal)orangePortal;
            Portal bp = (Portal)bluePortal;
            Hitbox objectBox = o.GetHitBox();
            Hitbox portalBox = op.GetHitBox();
            if (!op.hasCollided || !bp.hasCollided) return;
            if (TypeC.Check(o, typeof(ILink)))
            {
                ILink link = (ILink)o;
                CurrentRoom.Instance.linkCoor = orangeRoom;
                if (op.upSide)
                    Room.Link.Position = new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y - link.GetHitBox().ToRectangle().Height - 5);
                else if (op.leftSide)
                    Room.Link.Position = new Point(portalBox.ToRectangle().X - link.GetHitBox().ToRectangle().Width - 5, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2);
                else if (op.rightSide)
                    Room.Link.Position = new Point(portalBox.ToRectangle().X + link.GetHitBox().ToRectangle().Width + 5, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2);
                else if (op.bottomSide)
                    Room.Link.Position = new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y + link.GetHitBox().ToRectangle().Height + 5);
            } else if (TypeC.Check(o, typeof(IItem)))
            {
                IItem item = (IItem)o;
                if(!blueRoom.Equals(orangeRoom))
                {
                    Room bluer = CurrentRoom.Instance.Rooms[blueRoom];
                    Room oranger = CurrentRoom.Instance.Rooms[orangeRoom];
                    bluer.GameObjects.Remove(o);
                    oranger.GameObjects.Add(o);
                }
                if (op.upSide)
                    item.SetPosition(new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y - item.GetHitBox().ToRectangle().Height));
                else if (op.leftSide)
                    item.SetPosition(new Point(portalBox.ToRectangle().X - item.GetHitBox().ToRectangle().Width, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2));
                else if (op.rightSide)
                    item.SetPosition(new Point(portalBox.ToRectangle().X + item.GetHitBox().ToRectangle().Width, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2));
                else if (op.bottomSide)
                    item.SetPosition(new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y + item.GetHitBox().ToRectangle().Height));
            }
        }
        public static void MoveThroughPortal(Portal p, IGameObjects o)
        {
            if (orangePortal == null || bluePortal == null) return;
            if (p.Equals(orangePortal))
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
                Room r;
                if (bluePortal != null)
                    r = CurrentRoom.Instance.Rooms[blueRoom];
                else
                    r = CurrentRoom.Instance.Room;
                blueRoom = CurrentRoom.Instance.linkCoor;    
                r.GameObjects.Remove(bluePortal);
                bluePortal = p;
            } else
            {
                Room r;
                if (orangePortal != null)
                    r = CurrentRoom.Instance.Rooms[orangeRoom];
                else
                    r = CurrentRoom.Instance.Room;
                orangeRoom = CurrentRoom.Instance.linkCoor;
                r.GameObjects.Remove(orangePortal);
                orangePortal = p;
            }
        }
    }
}
