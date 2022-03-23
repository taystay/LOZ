using LOZ.LinkClasses;
using LOZ.GameState;
using LOZ.Sound;

namespace LOZ.CommandClasses
{
    class AttackBomb : ICommand
    {
        private Room _room;
        public AttackBomb(Room room)
        {
            _room = room;
        }
        public void execute()
        {
            Room.Link.Attack(Weapon.Bomb);
            //SoundManager.Instance.SoundToPlay(SoundEnum.Bomb_Blow);
        }
    }
}