using System;
using System.Collections.Generic;

namespace ClasseAssociation
{
    public class Player
    {
        private string _nom;

        public Player(string nom)
        {
            this.details = new List<KillDetail>();
            this._nom = nom;
        }
        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
            }
        }
        public List<KillDetail> details;
    }


}