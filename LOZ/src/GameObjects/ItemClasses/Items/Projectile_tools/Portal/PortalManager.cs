using Microsoft.Xna.Framework;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.ItemsClasses
{
    public static class PortalManager
    {
        private static int currentColor = 0;
        private static IGameObjects orangePortal { get; set; }
        private static Point3D orangeRoom { get; set; }
        private static IGameObjects bluePortal { get; set; }
        private static Point3D blueRoom { get; set; }
        public static int getColor() => currentColor;           
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
                RoomReference.GetLink().Position = new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y - link.GetHitBox().ToRectangle().Height - 5);
            else if (p.leftSide)
                RoomReference.GetLink().Position = new Point(portalBox.ToRectangle().X - link.GetHitBox().ToRectangle().Width - 5, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2);
            else if (p.rightSide)
                RoomReference.GetLink().Position = new Point(portalBox.ToRectangle().X + link.GetHitBox().ToRectangle().Width + 5, portalBox.ToRectangle().Y + portalBox.ToRectangle().Height / 2);
            else if (p.bottomSide)
                RoomReference.GetLink().Position = new Point(portalBox.ToRectangle().X + portalBox.ToRectangle().Width / 2, portalBox.ToRectangle().Y + link.GetHitBox().ToRectangle().Height + 5);
        }
        private static void ChangeItemDirection(int portal, IPlayerProjectile o)
        {
            Portal p;
            switch(portal)
            {
                case 0:
                    p = (Portal)bluePortal;
                    break;
                default:
                    p = (Portal)orangePortal;
                    break;
            }
            if (p.bottomSide)
            {      
                o.ChangeDirection(2);
                o.SetPosition(new Point(o._itemLocation.X, o._itemLocation.Y + 20));
            } else if (p.upSide)
            {
                o.ChangeDirection(0);
                o.SetPosition(new Point(o._itemLocation.X, o._itemLocation.Y - 20));
            } else if (p.rightSide)
            {
                o.ChangeDirection(1);
                o.SetPosition(new Point(o._itemLocation.X + 20, o._itemLocation.Y));
            } else
            {
                o.ChangeDirection(3);
                o.SetPosition(new Point(o._itemLocation.X - 20, o._itemLocation.Y));
            }
        }

        public static void MoveThroughPortal(Portal p, IGameObjects o)
        {
            Portal op = (Portal)orangePortal;
            Portal bp = (Portal)bluePortal;
            if (orangePortal == null || bluePortal == null) return;
            if (!op.hasCollided || !bp.hasCollided) return;
            int endroomint;
            Point3D start;
            Point3D end;
            if (p.Equals(orangePortal))
            {
                endroomint = 0;
                start = orangeRoom;
                end = blueRoom;
            } else
            {
                endroomint = 1;
                start = blueRoom;
                end = orangeRoom;
            }
            if (TypeC.Check(o, typeof(ILink)))
            {
                ILink link = (ILink)o;
                RoomReference.SetRoomLocationPoint(end);
                SetLinkPosition(endroomint, link);
            }
            else if (TypeC.Check(o, typeof(IItem)))
            {
                
                if(TypeC.Check(o, typeof(IPlayerProjectile)))
                    ChangeItemDirection(endroomint, (IPlayerProjectile)o);
                SetItemPosition(endroomint, (IItem)o);
                if (blueRoom.Equals(orangeRoom)) return;
                IRoom startr = RoomReference.GetAllRooms()[start];
                IRoom endr = RoomReference.GetAllRooms()[end];
                startr.RemovedInDetection.Add(o);
                endr.GetObjectsList().Add(o);
                
            }
        }
        public static void AddPortal(Portal p)
        {
            nextColor();
            if(p.isBlue)
            {
                IRoom r;
                if (bluePortal != null)
                    r = RoomReference.GetAllRooms()[blueRoom];
                else
                    r = RoomReference.GetCurrRoom();
                blueRoom = RoomReference.GetCurrLocation();    
                r.GetObjectsList().Remove(bluePortal);
                bluePortal = p;
            } else
            {
                IRoom r;
                if (orangePortal != null)
                    r = RoomReference.GetAllRooms()[orangeRoom];
                else
                    r = RoomReference.GetCurrRoom();
                orangeRoom = RoomReference.GetCurrLocation();
                r.GetObjectsList().Remove(orangePortal);
                orangePortal = p;
            }
        }
    }
}
