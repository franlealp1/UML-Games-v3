using System.Collections.Generic;
using System;

namespace Association
{
    public class Personnage
    {
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
        
        public List<Arme> armes = new List<Arme>();

        public void addArme(Arme uneArme)
        {
            armes.Add(uneArme);
        }
        public void afficherArmes()
        {
            Console.WriteLine("Les armes de " + _nom + " sont:");
            foreach (Arme arme in armes)
            {
                Console.WriteLine(arme.Nom);

            }

        }

    }

}