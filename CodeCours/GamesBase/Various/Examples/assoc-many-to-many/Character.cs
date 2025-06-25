using System;

namespace CoursUML
{
    class Character
    {
        private string? _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        // implementer l'association côté
        // Character->SkillLevel
        private List<SkillLevel> _characterSkillLevels;

        public void AddSkillLevel(SkillLevel sk)
        {
            // rajoute dans la liste de SkillLevels du Character
            _characterSkillLevels.Add(sk);
            // fixer le Character pour le SkillLevel
            sk.SetCharacter(this);

        }

        // constructeur
        public Character(string nom)
        {
            Nom = nom;
            _characterSkillLevels = new List<SkillLevel>(); // liste vide
        }

        // méthodes
        public void Attaquer()
        {
            Console.WriteLine($"Le character {Nom} attaque  !!");
        }


        public void Display()
        {
            foreach (SkillLevel sk in this._characterSkillLevels)
            {
                Console.WriteLine(sk.Valeur);
                Console.WriteLine(sk.CoolDown);

            }
        }

    }
}
