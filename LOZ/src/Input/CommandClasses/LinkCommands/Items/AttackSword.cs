using LOZ.LinkClasses;
using LOZ.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace LOZ.CommandClasses
{
    class AttackSword : ICommand
    {
        private Room _room;
        //private bool buttonPressed = false;
        public AttackSword(Room room)
        {
            _room = room;
        }
        public void execute()
        {
                if (!Room.RoomInventory.hasSword) return;

                if (Room.Link.Health == Room.Link.MaxHealth)
                    Room.Link.Attack(Weapon.Swordbeam);
                else
                    Room.Link.Attack(Weapon.Default);
        }
    }
}