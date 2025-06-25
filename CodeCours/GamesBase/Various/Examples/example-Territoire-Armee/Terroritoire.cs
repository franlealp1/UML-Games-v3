using System;

namespace CoursUML
{
    class Territoire
    {
        private string? _nom;

        private List<Unite> _unitList;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        // constructeur
        public Territoire(string nom)
        {
            Nom = nom;
            _unitList = new List<Unite>();
        }

        // méthodes
        public void AddUnit(Unite unite)
        {


            // si l'unité ne se trouve pas encore dans la liste, on rajout
            if (!_unitList.Contains(unite))
            {
                _unitList.Add(unite);
            }
        }

        public void RemoveUnit(Unite unite)
        {
            if (_unitList.Contains(unite))
            {
                _unitList.Remove(unite);
            }
        }

        public void Afficher()
        {
            Console.WriteLine($"Je suis le territoire: {Nom}");
            foreach (Unite unite in _unitList)
            {
                unite.Afficher();
            }

        }

    }
}
