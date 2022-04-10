 using LOZ.LinkClasses;
using LOZ.GameState;
using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class AttackBomb : ICommand
    {
        private OldRoom _room;
        public AttackBomb(OldRoom room)
        {
            _room = room;
        }
        public void execute()
        {
            OldRoom.Link.Attack(Weapon.Bomb);
            
            //SoundManager.Instance.SoundToPlay(SoundEnum.Bomb_Blow);
        }
    }
}