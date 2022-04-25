using System;
using System.Collections.Generic;
using System.Text;
using LOZ.LinkClasses;
using LOZ.GameStateReference;
using LOZ.Inventory;
using LOZ.ItemsClasses;
using LOZ.Room;
using Microsoft.Xna.Framework;

namespace LOZ.CommandClasses
{
    class GetPortalGun : ICommand
    {
        private Game1 game;
        public GetPortalGun(Game1 game) => this.game = game;

        public void execute()
        {
            //when bombs reach 0 will not work when adding bombs
            LinkInventory inv = RoomReference.GetInventory();
            inv.AddItem(new PortalGun(new Point()));        
        }
    }
}