using System;

namespace CoursUML
{
    abstract class Unite
    {
        private string? _nom;
        private int _cout;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int Cout
        {
            get { return _cout; }
            set { _cout = value; }
        }

        // constructeur
        public Unite(string nom, int cout)
        {
            Nom = nom;
            Cout = cout;
        }

        public abstract void Afficher();

    }
}
