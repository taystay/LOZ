﻿using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class AttackSword : ICommand
    {
        private Room _room;
        public AttackSword(Room room)
        {
            _room = room;
        }
        public void execute()
        {
            _room.Link.Attack(Weapon.Swordbeam);
        }
    }
}