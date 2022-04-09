using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.ControllerClasses;
using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.MapIO;
using System.IO;
using System.Reflection;
using LOZ.Sound;
using LOZ.Hud;
using LOZ.SpriteClasses;
using LOZ.SpriteClasses.DisplaySprites;
using LOZ.Factories;
namespace LOZ.src.CameraStates
{
    public class StartingGame : ICameraState
    {
        private Game1 _gameObject;
        private ISprite _menu;
        private int dy = -10;
        private const int offsetDist = Info.screenHeight;
        private int numberOfUpdates;
        public StartingGame(Game1 gameObject, ISprite menu)
        {
            numberOfUpdates = -offsetDist / dy;
            _gameObject = gameObject;
            _menu = menu;
        }
        public void UpdateController(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {
            _menu.Update(gameTime);
            numberOfUpdates--;
            if (numberOfUpdates <= 0)
            {
                HudElement inv = new InventoryHud(Room.RoomInventory);
                inv.Offset(new Point(0,-630));
                _gameObject.CameraState = new FirstDungeon(_gameObject, inv);
            }

              
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _menu.Draw(spriteBatch, new Point(Info.screenHeight / 2, Info.screenWidth / 2) + new Point(0, -(offsetDist + numberOfUpdates * dy)));
            CurrentRoom.Instance.Room.Draw(spriteBatch, new Point(0, -numberOfUpdates * dy));
        }
    }
}
