using System;
using LOZ.GameStateReference;
using Microsoft.Xna.Framework;

namespace LOZ.EnemyClass.Projectiles
{
    public static class ProjectileTypes
    {

        internal static void QuadShot(Point position)
        {
            Point linksPosition = RoomReference.GetLink().Position;
            RoomReference.AddItem(new DragonBreathe(position, linksPosition.X - position.X, linksPosition.Y - position.Y));
        }

        internal static void Shotgun(Point position)
        {
            System.Random r = new Random();//https://docs.microsoft.com/en-us/dotnet/api/system.random?view=net-6.0
            Point linksPosition = RoomReference.GetLink().Position;

            int differnceX = linksPosition.X - position.X;
            int differnceY = linksPosition.Y - position.Y;
            int i = 0;
            while (i != 8) {
                RoomReference.AddItem(new DragonBreathe(position, differnceX * r.Next(1,8), differnceY * r.Next(1,8)));
                i++;
            }

        }

        internal static void SingleShot(Point position)
        {
            Point linksPosition = RoomReference.GetLink().Position;
            RoomReference.AddItem(new DragonBreathe(position, linksPosition.X - position.X, linksPosition.Y - position.Y));
        }

        internal static void Wave(Point position)
        { 
            int i = -20;
            while (i != 20)
            {
                RoomReference.AddItem(new DragonBreathe(position,i*.2, 1));
                i++;
            }
        }
    }
}