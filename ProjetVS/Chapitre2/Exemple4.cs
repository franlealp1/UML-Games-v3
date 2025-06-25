using System;
using System.Collections.Generic;
using System.Linq;

namespace UMLGames.Examples.Chapitre2.Exemple4
{
    /// <summary>
    /// Classe représentant un personnage du jeu
    /// </summary>
    class Character
    {
        // Champs privés
        private string _name;
        private int _level;
        // ===== IMPLÉMENTATION DE LA RELATION MANY-TO-MANY AVEC CLASSE D'ASSOCIATION =====
        // Un Character peut apprendre plusieurs Skill via CharacterSkill
        // Un Skill peut être appris par plusieurs Character via CharacterSkill
        // CharacterSkill relie un Character et un Skill, et stocke des infos spécifiques (niveau, expérience)
        private List<CharacterSkill> _characterSkills;

        // Propriétés publiques
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION MANY-TO-MANY AVEC CLASSE D'ASSOCIATION =====
        // Cette propriété permet d'accéder à toutes les compétences apprises par le personnage (via CharacterSkill)
        public List<CharacterSkill> CharacterSkills
        {
            get { return _characterSkills; }
            set { _characterSkills = value; }
        }

        /// <summary>
        /// Constructeur de la classe Character
        /// </summary>
        /// <param name="name">Nom du personnage</param>
        /// <param name="level">Niveau du personnage</param>
        public Character(string name, int level)
        {
            Name = name;
            Level = level;
            CharacterSkills = new List<CharacterSkill>();
        }

        /// <summary>
        /// Permet au personnage d'apprendre une nouvelle compétence
        /// </summary>
        /// <param name="skill">Compétence à apprendre</param>
        public void LearnSkill(Skill skill)
        {
            if (skill == null)
                return;
            if (CharacterSkills.Any(cs => cs.Skill == skill))
            {
                Console.WriteLine($"{Name} connaît déjà la compétence {skill.Name}.");
                return;
            }
            var cs = new CharacterSkill(this, skill);
            CharacterSkills.Add(cs);
            skill.CharacterSkills.Add(cs);
            Console.WriteLine($"{Name} a appris la compétence {skill.Name}.");
        }

        /// <summary>
        /// Permet au personnage d'utiliser une compétence
        /// </summary>
        /// <param name="skill">Compétence à utiliser</param>
        public void UseSkill(Skill skill)
        {
            var cs = CharacterSkills.FirstOrDefault(x => x.Skill == skill);
            if (cs == null)
            {
                Console.WriteLine($"{Name} n'a pas appris la compétence {skill?.Name}.");
                return;
            }
            skill.Cast();
            cs.IncreaseLevel();
            Console.WriteLine($"{Name} utilise {skill.Name} (niveau {cs.SkillLevel}, expérience {cs.Experience}).");
        }

        /// <summary>
        /// Affiche les compétences du personnage
        /// </summary>
        public void ShowSkills()
        {
            Console.WriteLine($"\nCompétences de {Name} :");
            if (CharacterSkills.Count == 0)
                Console.WriteLine("Aucune compétence.");
            else
            {
                foreach (var cs in CharacterSkills)
                {
                    Console.WriteLine($"- {cs.Skill.Name} (Niveau: {cs.SkillLevel}, Exp: {cs.Experience})");
                }
            }
        }
    }

    /// <summary>
    /// Classe représentant une compétence du jeu
    /// </summary>
    class Skill
    {
        // Champs privés
        private string _name;
        private int _manaCost;
        private string _description;
        // ===== IMPLÉMENTATION DE LA RELATION MANY-TO-MANY AVEC CLASSE D'ASSOCIATION =====
        // Cette liste stocke tous les CharacterSkill associés à cette compétence
        private List<CharacterSkill> _characterSkills;

        // Propriétés publiques
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int ManaCost
        {
            get { return _manaCost; }
            set { _manaCost = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION MANY-TO-MANY AVEC CLASSE D'ASSOCIATION =====
        // Cette propriété permet d'accéder à tous les CharacterSkill associés à cette compétence
        public List<CharacterSkill> CharacterSkills
        {
            get { return _characterSkills; }
            set { _characterSkills = value; }
        }

        /// <summary>
        /// Constructeur de la classe Skill
        /// </summary>
        /// <param name="name">Nom de la compétence</param>
        /// <param name="manaCost">Coût en mana</param>
        /// <param name="description">Description</param>
        public Skill(string name, int manaCost, string description)
        {
            Name = name;
            ManaCost = manaCost;
            Description = description;
            CharacterSkills = new List<CharacterSkill>();
        }

        /// <summary>
        /// Lance la compétence (affiche un message)
        /// </summary>
        public void Cast()
        {
            Console.WriteLine($"La compétence {Name} est lancée !");
        }

        /// <summary>
        /// Retourne le coût en mana de la compétence
        /// </summary>
        public int GetManaCost()
        {
            return ManaCost;
        }

        /// <summary>
        /// Affiche les personnages ayant appris cette compétence
        /// </summary>
        public void ShowCharacters()
        {
            Console.WriteLine($"\nPersonnages ayant appris {Name} :");
            if (CharacterSkills.Count == 0)
                Console.WriteLine("Aucun personnage.");
            else
            {
                foreach (var cs in CharacterSkills)
                {
                    Console.WriteLine($"- {cs.Character.Name} (Niveau: {cs.SkillLevel}, Exp: {cs.Experience})");
                }
            }
        }
    }

    /// <summary>
    /// Classe d'association entre Character et Skill
    /// </summary>
    class CharacterSkill
    {
        // Champs privés
        // ===== IMPLÉMENTATION DE LA RELATION MANY-TO-MANY AVEC CLASSE D'ASSOCIATION =====
        // Référence vers le Character et le Skill associés
        private Character _character;
        private Skill _skill;
        private int _skillLevel;
        private int _experience;

        // Propriétés publiques
        public Character Character
        {
            get { return _character; }
            set { _character = value; }
        }
        public Skill Skill
        {
            get { return _skill; }
            set { _skill = value; }
        }
        public int SkillLevel
        {
            get { return _skillLevel; }
            set { _skillLevel = value; }
        }
        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }

        /// <summary>
        /// Constructeur de la classe CharacterSkill
        /// </summary>
        /// <param name="character">Personnage</param>
        /// <param name="skill">Compétence</param>
        public CharacterSkill(Character character, Skill skill)
        {
            Character = character;
            Skill = skill;
            SkillLevel = 1;
            Experience = 0;
        }

        /// <summary>
        /// Augmente le niveau de compétence et l'expérience
        /// </summary>
        public void IncreaseLevel()
        {
            Experience += 10;
            if (Experience >= SkillLevel * 100)
            {
                Experience = 0;
                SkillLevel++;
                Console.WriteLine($"{Character.Name} a monté {Skill.Name} au niveau {SkillLevel} !");
            }
        }

        /// <summary>
        /// Retourne le personnage associé
        /// </summary>
        public Character GetCharacter() => Character;
        /// <summary>
        /// Retourne la compétence associée
        /// </summary>
        public Skill GetSkill() => Skill;
        /// <summary>
        /// Retourne l'expérience
        /// </summary>
        public int GetExperience() => Experience;
        /// <summary>
        /// Retourne le niveau de compétence
        /// </summary>
        public int GetSkillLevel() => SkillLevel;
    }

    /// <summary>
    /// Classe de démonstration pour tester le système de compétences
    /// </summary>
    public static class Example4Demo
    {
        public static void Demo()
        {
            Console.WriteLine("=== Démonstration Many-to-Many avec classe d'association: Character & Skill ===\n");

            // Création des personnages
            Character hero = new Character("Hero", 10);
            Character mage = new Character("Mage", 8);

            // Création des compétences
            Skill fireball = new Skill("Fireball", 20, "Lance une boule de feu");
            Skill heal = new Skill("Heal", 10, "Soigne le personnage");
            Skill ice = new Skill("Ice", 15, "Gèle l'ennemi");

            // Apprentissage de compétences
            hero.LearnSkill(fireball);
            hero.LearnSkill(heal);
            mage.LearnSkill(fireball);
            mage.LearnSkill(ice);

            // Utilisation de compétences
            hero.UseSkill(fireball);
            hero.UseSkill(heal);
            mage.UseSkill(fireball);
            mage.UseSkill(ice);

            // Affichage des compétences de chaque personnage
            hero.ShowSkills();
            mage.ShowSkills();

            // Affichage des personnages ayant appris chaque compétence
            fireball.ShowCharacters();
            heal.ShowCharacters();
            ice.ShowCharacters();
        }
    }
} 