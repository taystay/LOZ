using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;
using LOZ.GameState;
using System;
using System.Collections.Generic;

namespace LOZ.ControllerClasses
{
    class KeyBindings
    {
        private KeyboardController ControllerMappings;
        private MouseController mouseControllerMappings;
        public KeyBindings(Game1 gameObject)
        {
            ControllerMappings = new KeyboardController(gameObject);
            mouseControllerMappings = new MouseController(gameObject);
            ControllerMappings.RegisterInitialCommand(Keys.Q, new QuitGame(gameObject));
            ControllerMappings.RegisterReleaseCommand(Keys.OemPipe, new EnterDebugMode());
            ControllerMappings.RegisterReleaseCommand(Keys.R, new Reset());
            ControllerMappings.RegisterReleaseCommand(Keys.M, new Mute());
            ControllerMappings.RegisterInitialCommand(Keys.B, new UseSelectedItem(gameObject));
            ControllerMappings.RegisterReleaseCommand(Keys.B, new Idle());
            ControllerMappings.RegisterInitialCommand(Keys.Z, new AttackSword(gameObject));
            ControllerMappings.RegisterHoldCommand(Keys.W, new UpMove());
            ControllerMappings.RegisterHoldCommand(Keys.A, new LeftMove());
            ControllerMappings.RegisterHoldCommand(Keys.S, new DownMove());
            ControllerMappings.RegisterHoldCommand(Keys.D, new RightMove());
            ControllerMappings.RegisterHoldCommand(Keys.Up, new UpMove());
            ControllerMappings.RegisterHoldCommand(Keys.Left, new LeftMove());
            ControllerMappings.RegisterHoldCommand(Keys.Down, new DownMove());
            ControllerMappings.RegisterHoldCommand(Keys.Right, new RightMove());
            ControllerMappings.RegisterHoldCommand(Keys.E, new TakeDamage());
            ControllerMappings.RegisterReleaseCommand(Keys.W, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.A, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.S, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.D, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Up, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Left, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Down, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Right, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.E, new Idle());
            ControllerMappings.RegisterKeySequenceCommand(new List<Keys>(){Keys.F, Keys.G} , new ExtraBombs(gameObject));
            ControllerMappings.RegisterKeySequenceCommand(new List<Keys>() { Keys.W, Keys.U }, new UnlimitedArrows(gameObject));
            ControllerMappings.RegisterKeySequenceCommand(new List<Keys>() { Keys.L, Keys.O }, new GetPortalGun(gameObject));
            mouseControllerMappings.RegisterLeftClickCommands(new SwitchRoomLeftClick());
            mouseControllerMappings.RegisterRightClickCommands(new SwitchRoomRightClick());
        }
        public KeyboardController GetKeyboardController() => ControllerMappings;
        public MouseController GetMouseController() => mouseControllerMappings;
    }
}
