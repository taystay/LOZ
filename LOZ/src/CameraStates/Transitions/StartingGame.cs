using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.DungeonClasses;
using LOZ.Hud;
using LOZ.SpriteClasses;
using LOZ.Room;
using LOZ.Factories;


namespace LOZ.src.CameraStates
{
    public class StartingGame : ICameraState
    {
        private Game1 _gameObject;      

        #region constants
        private const int dy = -2;
        private const int offsetDist = Info.screenHeight * 2;
        private const int fractionTillSkipable = 7;
        private int numberOfUpdates;
        private int numberOfUpdatesLeft;
        #endregion

        #region sprites
        private ISprite introText;
        private ISprite _menu;
        #endregion

        public StartingGame(Game1 gameObject, ISprite menu)
        {
            _gameObject = gameObject;
            _menu = menu;

            numberOfUpdates = -offsetDist / dy;
            numberOfUpdatesLeft = numberOfUpdates;
            introText = DisplaySpriteFactory.Instance.GetIntroText();
        }
        public void UpdateController(GameTime gameTime)
        {
            bool canSkip = numberOfUpdatesLeft <=  (fractionTillSkipable - 1) * numberOfUpdates / fractionTillSkipable;
            bool buttonPressed = Keyboard.GetState().GetPressedKeyCount() > 0;
            if ( canSkip && buttonPressed)
            {
                HudElement inv = new InventoryHud(RoomReference.GetInventory());
                inv.Offset(new Point(0, -630));
                _gameObject.CameraState = new FirstDungeon(_gameObject,inv);
            }

        }
        public void Update(GameTime gameTime)
        {
            _menu.Update(gameTime);
            numberOfUpdatesLeft--;
            if (numberOfUpdatesLeft <= 0)
            {
                HudElement inv = new InventoryHud(RoomReference.GetInventory());
                inv.Offset(new Point(0,-630));
                _gameObject.CameraState = new FirstDungeon(_gameObject, inv);
            }
        }
        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _menu.Draw(spriteBatch, new Point(Info.screenHeight / 2, Info.screenWidth / 2) + new Point(0, -(offsetDist + numberOfUpdatesLeft * dy)));
            introText.Draw(spriteBatch, new Point(Info.screenHeight / 2, Info.screenWidth / 2) + new Point(0, -(offsetDist / 2 + numberOfUpdatesLeft * dy)));
            CurrentRoom.Instance.DrawOffset(spriteBatch, new Point(0, -numberOfUpdatesLeft * dy));
            //CurrentRoom.Instance.Room.Draw(spriteBatch, new Point(0, -numberOfUpdatesLeft * dy));
        }
    }
}
