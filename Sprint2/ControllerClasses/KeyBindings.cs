
using Microsoft.Xna.Framework.Input;
using Sprint2.CommandClasses;
using Sprint2.GameState;

namespace Sprint2.ControllerClasses
{
    class KeyBindings
    {
        private KeyboardController ControllerMappings;

        public KeyBindings(Game1 gameObject)
        {
            ControllerMappings = new KeyboardController(gameObject);

            ControllerMappings.RegisterInitialCommand(Keys.Q, new QuitGame(gameObject));
            ControllerMappings.RegisterInitialCommand(Keys.R, new Reset(gameObject));

            ControllerMappings.RegisterInitialCommand(Keys.Y, new IterateBlock());
            ControllerMappings.RegisterInitialCommand(Keys.T, new PreviousBlock());
            ControllerMappings.RegisterInitialCommand(Keys.I, new NextItem());
            ControllerMappings.RegisterInitialCommand(Keys.U, new PreviousItem());
            ControllerMappings.RegisterInitialCommand(Keys.O, new PreviousEnemy());
            ControllerMappings.RegisterInitialCommand(Keys.P, new NextEnemy());

            ControllerMappings.RegisterInitialCommand(Keys.D1, new AttackSword(GameObjects.Instance.Link));
            ControllerMappings.RegisterInitialCommand(Keys.D2, new AttackArrow(GameObjects.Instance.Link));
            ControllerMappings.RegisterInitialCommand(Keys.D3, new AttackBomb(GameObjects.Instance.Link));

            ControllerMappings.RegisterReleaseCommand(Keys.D1, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.D2, new Idle());
            ControllerMappings.RegisterReleaseCommand(Keys.D3, new Idle());

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
