using System;

namespace CoursUML
{
    class Skill 
    {

        private string? _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }


        private string? _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // implementer l'association
        // côté: Skill->SkillLevel
        private List<SkillLevel> _skillSkillLevels;


        // constructeur
        public Skill(string nom, string type)
        {
            Nom = nom;
            Type = type;
            // initialiser la liste
            _skillSkillLevels = new List<SkillLevel>(); // liste vide
        }

        public void AddSkillLevel(SkillLevel sk)
        {
            // rajouter dans la liste
            _skillSkillLevels.Add(sk);
            // affecter le Skill qui correspond
            sk.SetSkill(this);
        } 

        // méthodes
        public void Use()
        {
            Console.WriteLine($"Le character utilise le skill {Nom}  !!");
        }
        

    }
}
