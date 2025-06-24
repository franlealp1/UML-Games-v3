using System;

namespace CoursUML
{
    class SkillLevel
    {
        private int _valeur;
        private int _coolDown;

        // implementer rélations
        private Character _character;
        private Skill _skill;

        public int Valeur
        {
            get { return _valeur; }
            set { _valeur = value; }
        }

        public int CoolDown
        {
            get { return _coolDown; }
            set { _coolDown = value; }
        }

        // constructeur
        public SkillLevel(Character c, Skill s, int valeur, int coolDown)
        {
            Valeur = valeur;
            CoolDown = coolDown;
            SetCharacter(c);
            SetSkill(s);
        }

        // implementer association côté SkillLevel->Character
        public void SetCharacter(Character c)
        {
            _character = c;
        }
        // implementer association côté SkillLevel->Skill
        public void SetSkill(Skill s)
        {
            _skill = s;
        }


    }
}
