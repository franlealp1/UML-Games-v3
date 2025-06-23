using System;

namespace ClasseAssociation
{
    public class KillDetail
    {
        private int _hitPoints;

        public Player player;
        public Boss boss;


        public int HitPoints
        {
            get
            {
                return _hitPoints;
            }
            set
            {
                _hitPoints = value;
            }
        }

        public KillDetail(Player player, Boss boss, int _hitPoints)
        {
            this.player = player;
            this.boss = boss;
            this._hitPoints = _hitPoints;
        }



    }

}