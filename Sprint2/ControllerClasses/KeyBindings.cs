﻿using System;
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

            ControllerMappings.RegisterCommand(Keys.Y, new IterateBlock(gameObject), null, null);
            ControllerMappings.RegisterCommand(Keys.T, new previousBlock(gameObject), null, null);
            ControllerMappings.RegisterCommand(Keys.I, new IterateItemForward(gameObject), null, null);
            ControllerMappings.RegisterCommand(Keys.U, new IterateItemReverse(gameObject), null, null);
            ControllerMappings.RegisterCommand(Keys.O, new PreviousEnemy(gameObject),null, null);
            ControllerMappings.RegisterCommand(Keys.P, new NextEnemy(gameObject), null, null);

            ControllerMappings.RegisterCommand(Keys.W, null, new UpMove(gameObject), new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.A, null, new LeftMove(gameObject), new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.S, null, new DownMove(gameObject), new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.D, null, new RightMove(gameObject), new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.Up, null, new UpMove(gameObject), new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.Left, null, new LeftMove(gameObject), new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.Down, null, new DownMove(gameObject), new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.Right, null, new RightMove(gameObject), new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.Z, new Attack(gameObject), null, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.N, new Attack(gameObject), null, new Idle(gameObject));
            ControllerMappings.RegisterCommand(Keys.E, new TakeDamage(gameObject), null, null);
            //ControllerMappings.RegisterCommand(Keys.D1, new HoldSwordItem(gameObject), null, null);
            //ControllerMappings.RegisterCommand(Keys.D2, new HoldArrowItem(gameObject), null, null);
            //ControllerMappings.RegisterCommand(Keys.D3, new HoldBombItem(gameObject), null, null);
        }

        public KeyboardController GetController()
        {
            return ControllerMappings;
        }
    }
}
