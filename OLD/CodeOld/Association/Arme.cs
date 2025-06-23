using System;
using System.Collections.Generic;

namespace Association
{
    public class Arme
    {
        public List<Personnage> personnages = new List<Personnage>();

        public void addPersonnage(Personnage unPersonnage)
        {
            personnages.Add(unPersonnage);
        }
        public void afficherPersonnages()
        {
            Console.WriteLine("Les porteurs de l'arme " + _nom + " sont:");
            foreach (Personnage personnage in personnages)
            {
                Console.WriteLine(personnage.Nom);

            }

        }

        public string _nom;
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

    }

}