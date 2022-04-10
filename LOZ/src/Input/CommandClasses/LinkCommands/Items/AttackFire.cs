using LOZ.LinkClasses;
using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class AttackFire : ICommand
    {

        public AttackFire()
        {
           
        }
        public void execute()
        {
            RoomReference.GetLink().Attack(Weapon.Fire);
        }
    }
}