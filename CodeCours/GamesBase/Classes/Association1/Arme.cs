using System;

namespace CoursUML
{
    class Arme
    {
        // propriétés
        private string _nom;

        private int _puissance;

        public int Puissance
        {
            get { return _puissance; }
            set { _puissance = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        // constructeur
        public Arme(string nom, int puissance)
        {
            Puissance = puissance;
            Nom = nom;
        }

        // méthodes
        public void ProvoquerDegats()
        {
            Console.WriteLine($"On utilise l'arme {Nom} !!");
        }

    }
}
