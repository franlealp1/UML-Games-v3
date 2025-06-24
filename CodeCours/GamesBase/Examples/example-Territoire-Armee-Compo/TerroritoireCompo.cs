using System;

namespace CoursUML
{
    class TerritoireCompo
    {
        private string? _nom;

        private List<Unite> _unitList;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        // constructeur
        public TerritoireCompo(string nom)
        {
            Nom = nom;
            _unitList = new List<Unite>();
        }

        // méthodes
        public void AddUnit(string type,
                            string nom,
                            int cout,
                            string attr)
        {
            if (type == "Soldat")
            {
                _unitList.Add(new Soldat(nom, cout, attr));
            };
            if (type == "Tank") {
                _unitList.Add(new Tank(nom, cout, attr));  
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
