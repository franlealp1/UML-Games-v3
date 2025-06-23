using System;
using System.Collections.Generic;

namespace Reflexive
{
    public class Personne
    {
        private string _nom;
		public string Nom {
			get {
				return _nom;
			}
			set {
				_nom = value;
			}
		}

        public List<Personne> enfants;


        public Personne(string nom)
        {
            this._nom = nom;
            this.enfants = new List<Personne>();

        }
        public void afficheEnfants()
        {
			Console.WriteLine ("Les enfants de " + this._nom + " sont : ");

            foreach (Personne unePersonne in enfants)
            {
               Console.WriteLine(unePersonne._nom);
            }
        }
        public void addEnfant(Personne enfant)
        {
            enfants.Add(enfant);
        }

    }
}