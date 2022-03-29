
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;
using LOZ.GameState;
using LOZ.Sound;

namespace LOZ.ControllerClasses
{
    class KeyBindings
    {
        private KeyboardController ControllerMappings;
        private MouseController mouseControllerMappings;
        public KeyBindings(Game1 gameObject)
        {
            ControllerMappings = new KeyboardController(gameObject);
            mouseControllerMappings = new MouseController();
            ControllerMappings.RegisterInitialCommand(Keys.Q, new QuitGame(gameObject));
            ControllerMappings.RegisterReleaseCommand(Keys.LeftShift, new EnterDebugMode());
            ControllerMappings.RegisterReleaseCommand(Keys.R, new Reset());
            ControllerMappings.RegisterReleaseCommand(Keys.M, new Mute());
            ControllerMappings.RegisterReleaseCommand(Keys.Escape, new Pause(gameObject));


            //ControllerMappings.RegisterInitialCommand(Keys.D1, new AttackSword(CurrentRoom.Instance.Room));
            //ControllerMappings.RegisterInitialCommand(Keys.D2, new AttackArrow(CurrentRoom.Instance.Room));
            //ControllerMappings.RegisterInitialCommand(Keys.D3, new AttackBomb(CurrentRoom.Instance.Room));
            //ControllerMappings.RegisterInitialCommand(Keys.D4, new AttackFire(CurrentRoom.Instance.Room));
            ControllerMappings.RegisterInitialCommand(Keys.B, new UseSelectedItem(CurrentRoom.Instance.Room));
            ControllerMappings.RegisterReleaseCommand(Keys.B, new Idle());
            ControllerMappings.RegisterInitialCommand(Keys.Z, new AttackSword(CurrentRoom.Instance.Room));
            ControllerMappings.RegisterReleaseCommand(Keys.Z, new Idle());
            ///ControllerMappings.RegisterInitialCommand(Keys.NumPad2, new AttackArrow(CurrentRoom.Instance.Room));
            //ControllerMappings.RegisterInitialCommand(Keys.NumPad3, new AttackBomb(CurrentRoom.Instance.Room));
            //ControllerMappings.RegisterInitialCommand(Keys.NumPad4, new AttackFire(CurrentRoom.Instance.Room));

            ControllerMappings.RegisterReleaseCommand(Keys.D1, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.D2, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.D3, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.D4, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.NumPad1, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.NumPad2, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.NumPad3, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.NumPad4, new Idle());

            ControllerMappings.RegisterHoldCommand(Keys.W,new UpMove());
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
            ControllerMappings.RegisterReleaseCommand(Keys.N, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.E, new Idle());

            mouseControllerMappings.RegisterLeftClickCommands(new SwitchRoomLeftClick());
            mouseControllerMappings.RegisterRightClickCommands(new SwitchRoomRightClick());
        }

        public KeyboardController GetKeyboardController()
        {
            return ControllerMappings;
        }

        public MouseController GetMouseController()
        {
            return mouseControllerMappings;
        }
    }
}
