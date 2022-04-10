using LOZ.LinkClasses;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class AttackBomb : ICommand
    {
        private CurrentRoom _room;
        public AttackBomb(CurrentRoom room)
        {
            _room = room;
        }
        public void execute()
        {
            CurrentRoom.link.Attack(Weapon.Bomb);
            
            //SoundManager.Instance.SoundToPlay(SoundEnum.Bomb_Blow);
        }
    }
}