using System;

namespace CoursUML2
{
    class Tank : Unite
    {
        private string? _modele;

        public string Modele
        {
            get { return _modele; }
            set { _modele = value; }
        }

        // constructeur
        public Tank(string nom, int cout, string modele) : base(nom, cout)
        {
            Modele = modele;
        }

        // méthodes
        public void Attaquer()
        {
            Console.WriteLine($"Le tank {Modele} va tout détruire attaque  !!");
        }

        public override void Afficher()
        {
            Console.WriteLine ($"Je suis une tanque du type {Modele}");
        }

    }
}
