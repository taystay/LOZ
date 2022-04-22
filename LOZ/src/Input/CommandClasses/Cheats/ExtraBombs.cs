using System;
using System.Collections.Generic;
using System.Text;
using LOZ.LinkClasses;
using LOZ.GameStateReference;
using LOZ.Inventory;
using LOZ.ItemsClasses;
using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class ExtraBombs : ICommand
    {
        private Game1 game;
        public ExtraBombs(Game1 game) => this.game = game;
         
        public void execute()
        {
            //when bombs reach 0 will not work when adding bombs
            LinkInventory inv = RoomReference.GetInventory();
            inv.bombCount = inv.bombCount + 20;
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Secret);
        }
    }
}
