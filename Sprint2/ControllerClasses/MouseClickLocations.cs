using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class MouseClickLocations
    {
        private MouseController MyController;

        public MouseClickLocations(Game1 MyGame)
        {
            Point ScreenDimensions = MyGame.GetDim();
            int width = ScreenDimensions.X;
            int height = ScreenDimensions.Y;
            MyController = new MouseController();

            MyController.RegisterRightClickCommands(new QuitGame(MyGame));
            MyController.RegisterLeftClickLocation(new Rectangle(0, 0, width / 2, height / 2), new SwitchIdle(MyGame));
            MyController.RegisterLeftClickLocation(new Rectangle(width / 2, 0, width / 2, height / 2), new SwitchAnimated(MyGame));
            MyController.RegisterLeftClickLocation(new Rectangle(0, height / 2, width / 2, height / 2), new SwitchMoving(MyGame));
            MyController.RegisterLeftClickLocation(new Rectangle(width / 2, height / 2, width / 2, height / 2), new SwitchMovingAnimated(MyGame));
        }

        public MouseController GetController()
        {
            return MyController;
        }
    }
}
