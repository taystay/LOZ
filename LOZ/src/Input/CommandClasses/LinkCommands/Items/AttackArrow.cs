using LOZ.LinkClasses;
using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class AttackArrow :ICommand
    {
       
        public AttackArrow()
        { 
        }
        public void execute()
        {
            RoomReference.GetLink().Attack(Weapon.Arrow);
        }
    }
}
