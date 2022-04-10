using LOZ.LinkClasses;
using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class AttackBomb : ICommand
    {

        public AttackBomb()
        {
           
        }
        public void execute()
        {
            RoomReference.GetLink().Attack(Weapon.Bomb);
        }
    }
}