using System;

namespace CoursUML2
{
    class Soldat : Unite
    {
        private string? _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // constructeur
        public Soldat(string nom, int cout, string type) : base(nom, cout)
        {
            Type = type;
        }

        // méthodes
        public void Attaquer()
        {
            Console.WriteLine($"Le soldat {Type} attaque  !!");
        }
        
        public override void Afficher()
        {
            Console.WriteLine ($"Je suis un soldat du type {Type}");
        }

    }
}
