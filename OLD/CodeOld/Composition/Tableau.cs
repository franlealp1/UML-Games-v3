using System.Collections.Generic;
using System;


namespace Composition
{
    public class Tableau
    {
        private string _id;

        public List<Pion> pions = new List<Pion>();
        public List<Cheval> chevaux = new List<Cheval>();

        public Tableau(string id)
        {
            this._id = id;
            // les objets sont crées à l'intérieur. 
            // la destruction de cet objet implique la destruction des Pions et des Chevaux
            for (int i = 0; i < 16; i++)
            {
                pions.Add(new Pion(i + 1));
            }
            for (int i = 0; i < 16; i++)
            {
                chevaux.Add(new Cheval(i + 1));
            }
        }
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }



}