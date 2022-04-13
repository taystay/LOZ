using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.DungeonClasses;
using System.IO;
using System.Reflection;
using LOZ.Sound;
using LOZ.Factories;
using LOZ.src.CameraStates;
using LOZ.Room;
using LOZ.Hud;
using LOZ.GameStateReference;
using LOZ.GameState;

namespace LOZ
{

    internal class UpdateSpeed
    {
        internal const int LinkAttack = 10;
        internal const int LinkWalk = 5;
        internal const int SkeletonUpdate = 70;
        internal const int SkeletonSprite = 7;
        internal const int BatUpdate = 70;
        internal const int BatSprite = 5;
        internal const int JellyUpdate = 70;
        internal const int JellySprite = 5;
        internal const int DragonUpdate = 70;
        internal const int DragonSprite = 5;
        internal const int DragonShootUpdate = 100;
        internal const int DragonShotSprite = 40;
        internal const int SpikeTrapUpdate = 5;
    }
}
