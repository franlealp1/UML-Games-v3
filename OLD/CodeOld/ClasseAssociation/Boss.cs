using System;
using System.Collections.Generic;

namespace ClasseAssociation
{
    public class Boss
    {
        private string _nom;

        public Boss(string nom)
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