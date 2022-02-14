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

            ControllerMappings.RegisterCommand(Keys.Q, new QuitGame(gameObject), null, null);
            ControllerMappings.RegisterCommand(Keys.R, new Reset(gameObject), null, null);

            ControllerMappings.RegisterCommand(Keys.Y, new IterateBlock(), null, null);
            ControllerMappings.RegisterCommand(Keys.T, new previousBlock(), null, null);
            ControllerMappings.RegisterCommand(Keys.I, new NextItem(), null, null);
            ControllerMappings.RegisterCommand(Keys.U, new PreviousItem(), null, null);
            ControllerMappings.RegisterCommand(Keys.O, new PreviousEnemy(),null, null);
            ControllerMappings.RegisterCommand(Keys.P, new NextEnemy(), null, null);

            ControllerMappings.RegisterCommand(Keys.W, null, new UpMove(), new Idle());
            ControllerMappings.RegisterCommand(Keys.A, null, new LeftMove(), new Idle());
            ControllerMappings.RegisterCommand(Keys.S, null, new DownMove(), new Idle());
            ControllerMappings.RegisterCommand(Keys.D, null, new RightMove(), new Idle());
            ControllerMappings.RegisterCommand(Keys.Up, null, new UpMove(), new Idle());
            ControllerMappings.RegisterCommand(Keys.Left, null, new LeftMove(), new Idle());
            ControllerMappings.RegisterCommand(Keys.Down, null, new DownMove(), new Idle());
            ControllerMappings.RegisterCommand(Keys.Right, null, new RightMove(), new Idle());
            ControllerMappings.RegisterCommand(Keys.Z, new Attack(), null, new Idle());
            ControllerMappings.RegisterCommand(Keys.N, new Attack(), null, new Idle());
            ControllerMappings.RegisterCommand(Keys.E, new TakeDamage(), null, null);
            ControllerMappings.RegisterCommand(Keys.D1, new AttackSword(), null, null);
            ControllerMappings.RegisterCommand(Keys.D2, new AttackArrow(GameObjects.Instance.LinkItems), null, null);
            ControllerMappings.RegisterCommand(Keys.D3, new AttackBomb(), null, null);
        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
