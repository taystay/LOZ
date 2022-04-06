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
        private static void SetItemPosition(int portal, IItem item)
        {
            Hitbox portalBox;
            Portal p;
            switch (portal)
            {
                case 0: // blue
                    p = (Portal)bluePortal;
                    break;
                default: //orange
                    p = (Portal)orangePortal;
                    break;
            }
            portalBox = p.GetHitBox();
            if (p.upSide)
                item.SetPositionOnUpdate(new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y - item.GetHitBox().ToRectangle().Height));
            else if (p.leftSide)
                item.SetPositionOnUpdate(new Point(portalBox.ToRectangle().X - item.GetHitBox().ToRectangle().Width, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2));
            else if (p.rightSide)
                item.SetPositionOnUpdate(new Point(portalBox.ToRectangle().X + item.GetHitBox().ToRectangle().Width, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2));
            else if (p.bottomSide)
                item.SetPositionOnUpdate(new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y + item.GetHitBox().ToRectangle().Height));
        }
        private static void SetLinkPosition(int portal, ILink link)
        {
            Hitbox portalBox;
            Portal p;
            switch (portal)
            {
                case 0: // blue
                    p = (Portal)bluePortal;
                    break;
                default: //orange
                    p = (Portal)orangePortal;
                    break;
            }
            portalBox = p.GetHitBox();
            if (p.upSide)
                Room.Link.Position = new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y - link.GetHitBox().ToRectangle().Height - 5);
            else if (p.leftSide)
                Room.Link.Position = new Point(portalBox.ToRectangle().X - link.GetHitBox().ToRectangle().Width - 5, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2);
            else if (p.rightSide)
                Room.Link.Position = new Point(portalBox.ToRectangle().X + link.GetHitBox().ToRectangle().Width + 5, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2);
            else if (p.bottomSide)
                Room.Link.Position = new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y + link.GetHitBox().ToRectangle().Height + 5);
        }
        private static void GoThroughOrange(IGameObjects o)
        {
            Portal op = (Portal)orangePortal;
            Portal bp = (Portal)bluePortal;
            if (!op.hasCollided || !bp.hasCollided) return;
            if(TypeC.Check(o, typeof(ILink)))
            {
                ILink link = (ILink)o;
                CurrentRoom.Instance.linkCoor = blueRoom;
                SetLinkPosition(0, link); // set to blue portal
            }
            else if (TypeC.Check(o, typeof(IItem)))
            {
                IItem item = (IItem)o;
                if (!blueRoom.Equals(orangeRoom))
                {
                    Room bluer = CurrentRoom.Instance.Rooms[blueRoom];
                    Room oranger = CurrentRoom.Instance.Rooms[orangeRoom];
                    bluer.GameObjects.Add(o);
                    oranger.RemovedInDetection.Add(o);
                }
                SetItemPosition(0, item); //set to blue portal
            }
        }
        private static void GoThroughBlue(IGameObjects o)
        {
            Portal op = (Portal)orangePortal;
            Portal bp = (Portal)bluePortal;
            if (!op.hasCollided || !bp.hasCollided) return;
            if (TypeC.Check(o, typeof(ILink)))
            {
                ILink link = (ILink)o;
                CurrentRoom.Instance.linkCoor = orangeRoom;
                SetLinkPosition(1, link); //set to orange portal
            } else if (TypeC.Check(o, typeof(IItem)))
            {
                IItem item = (IItem)o;
                if(!blueRoom.Equals(orangeRoom))
                {
                    Room bluer = CurrentRoom.Instance.Rooms[blueRoom];
                    Room oranger = CurrentRoom.Instance.Rooms[orangeRoom];
                    bluer.RemovedInDetection.Add(o);
                    oranger.GameObjects.Add(o);
                }
                SetItemPosition(1, item); // set to orange portal
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
