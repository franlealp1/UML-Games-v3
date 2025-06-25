using System;

namespace CoursUML
{
    class Personnage
    {
        // propriétés
        private int _hp;
        private string _nom;
        private List<Arme> _listeArmes;

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }


        public List<Arme> ListeArmes
        {
            get { return _listeArmes; }
            set { _listeArmes = value; }
        }


        // constructeur
        public Personnage(int hp, string nom)
        {
            Hp = hp;
            Nom = nom;
            ListeArmes = new List<Arme>();
        }

        // méthodes
        public void Attaquer()
        {
            Console.WriteLine("On attaque!!");
        }

        public void SeDeplacer(int posX, int posY)
        {
            Console.WriteLine($"On se deplace vers {posX}, {posY}");
        }
    }
}
