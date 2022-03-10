﻿using Microsoft.Xna.Framework;
using LOZ.Collision;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses
{
    public enum Weapon : int
    {
        Swordbeam,
        Arrow,
        Bomb,
        Fire,
        Default
    }
    public interface ILink : IGameObjects
    {
        public Point Position { get; set; }
        public void ChangeDirectionUp();
        public void ChangeDirectionDown();
        public void ChangeDirectionLeft();
        public void ChangeDirectionRight();
        public void Move();
        public void Idle();
        public void RaiseItem(IItem item);
        public void Attack(Weapon currentUse);
        public void TakeDamage();
        public Point GetPosition();
    }
}
