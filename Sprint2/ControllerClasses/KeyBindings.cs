using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class KeyBindings
    {
        private KeyboardController ControllerMappings;

        public KeyBindings(Game1 gameObject)
        {
            ControllerMappings = new KeyboardController(gameObject);

            ControllerMappings.RegisterCommand(Keys.D0, new QuitGame(gameObject));
            ControllerMappings.RegisterCommand(Keys.NumPad0, new QuitGame(gameObject));
            ControllerMappings.RegisterCommand(Keys.Y, new IterateBlock(gameObject));
            ControllerMappings.RegisterCommand(Keys.T, new previousBlock(gameObject));
            ControllerMappings.RegisterCommand(Keys.I, new IterateStaticItems(gameObject));
            ControllerMappings.RegisterCommand(Keys.U, new IterateRStaticItems(gameObject));
            ControllerMappings.RegisterCommand(Keys.O, new PreviousEnemy(gameObject));
            ControllerMappings.RegisterCommand(Keys.P, new NextEnemy(gameObject));

            //---------------------LINK COMMANDS
            ControllerMappings.RegisterHoldCommand(Keys.Up, new UpMove(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.Down, new DownMove(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.Left, new LeftMove(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.Right, new RightMove(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.W, new UpMove(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.S, new DownMove(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.A, new LeftMove(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.D, new RightMove(gameObject));
            ControllerMappings.RegisterCommand(Keys.Up, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.Down, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.Left, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.Right, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.W, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.S, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.A, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.D, new Idle(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.Z, new Attack(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.N, new Attack(gameObject));
            ControllerMappings.RegisterCommand(Keys.Z, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.N, new Idle(gameObject));

            ControllerMappings.RegisterHoldCommand(Keys.OemTilde, new IterateRStaticItems(gameObject));
        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
