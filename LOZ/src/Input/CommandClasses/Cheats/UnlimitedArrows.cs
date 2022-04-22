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
    class UnlimitedArrows : ICommand
    {
        private Game1 game;
        public UnlimitedArrows(Game1 game) => this.game = game;
         
        public void execute()
        {
            //when bombs reach 0 will not work when adding bombs
            LinkInventory inv = RoomReference.GetInventory();
            inv.rupeeCount = 999;
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Secret);
        }
    }
}
