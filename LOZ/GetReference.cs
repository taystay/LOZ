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

    public static class GetReference
    {
        private static Game1 reference;
        public static void SetReference(Game1 refer)
        {
            reference = refer;
        }

        public static Game1 GetRef()
        {
            return reference;
        }

    }
}
