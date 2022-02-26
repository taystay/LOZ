
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;
using LOZ.GameState;

namespace LOZ.ControllerClasses
{
    class KeyBindings
    {
        private KeyboardController ControllerMappings;

        public KeyBindings(Game1 gameObject)
        {
            ControllerMappings = new KeyboardController(gameObject);

            ControllerMappings.RegisterInitialCommand(Keys.Q, new QuitGame(gameObject));

            ControllerMappings.RegisterInitialCommand(Keys.D1, new AttackSword(gameObject.CurrentRoom));
            ControllerMappings.RegisterInitialCommand(Keys.D2, new AttackArrow(gameObject.CurrentRoom));
            ControllerMappings.RegisterInitialCommand(Keys.D3, new AttackBomb(gameObject.CurrentRoom));
            ControllerMappings.RegisterInitialCommand(Keys.D4, new AttackFire(gameObject.CurrentRoom));
            ControllerMappings.RegisterInitialCommand(Keys.NumPad1, new AttackSword(gameObject.CurrentRoom));
            ControllerMappings.RegisterInitialCommand(Keys.NumPad2, new AttackArrow(gameObject.CurrentRoom));
            ControllerMappings.RegisterInitialCommand(Keys.NumPad3, new AttackBomb(gameObject.CurrentRoom));
            ControllerMappings.RegisterInitialCommand(Keys.NumPad4, new AttackFire(gameObject.CurrentRoom));

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
            ControllerMappings.RegisterHoldCommand(Keys.Z, new Attack());
            ControllerMappings.RegisterHoldCommand(Keys.N, new Attack());
            ControllerMappings.RegisterHoldCommand(Keys.E, new TakeDamage());

            ControllerMappings.RegisterReleaseCommand(Keys.W, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.A, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.S, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.D, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Up, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Left, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Down, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Right, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.Z, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.N, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.E, new Idle());

        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
