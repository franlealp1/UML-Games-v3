using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML
{
    /// <summary>
    /// Classe représentant un joueur dans un jeu multijoueur (ex: Counter-Strike)
    /// </summary>
    class Player
    {
        // Champs privés avec préfixe _
        private string _name;
        private int _health;
        private List<Weapon> _weapons;

        // Propriétés publiques
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        /// <summary>
        /// Liste des armes actuellement possédées par le joueur
        /// </summary>
        public List<Weapon> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        /// <summary>
        /// Constructeur de la classe Player
        /// </summary>
        /// <param name="name">Nom du joueur</param>
        /// <param name="health">Points de vie du joueur</param>
        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            Weapons = new List<Weapon>();
        }

        /// <summary>
        /// Permet au joueur de ramasser une arme
        /// </summary>
        /// <param name="weapon">Arme à ramasser</param>
        public void PickUpWeapon(Weapon weapon)
        {
            if (weapon != null && !Weapons.Contains(weapon))
            {
                Weapons.Add(weapon);
                weapon.Players.Add(this);
                Console.WriteLine($"{Name} a ramassé l'arme {weapon.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} possède déjà l'arme {weapon?.Name}");
            }
        }

        /// <summary>
        /// Permet au joueur de déposer une arme
        /// </summary>
        /// <param name="weapon">Arme à déposer</param>
        public void DropWeapon(Weapon weapon)
        {
            if (weapon != null && Weapons.Contains(weapon))
            {
                Weapons.Remove(weapon);
                weapon.Players.Remove(this);
                Console.WriteLine($"{Name} a déposé l'arme {weapon.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} ne possède pas l'arme {weapon?.Name}");
            }
        }

        /// <summary>
        /// Permet au joueur d'attaquer avec une arme
        /// </summary>
        /// <param name="weapon">Arme utilisée pour attaquer</param>
        public void AttackWithWeapon(Weapon weapon)
        {
            if (weapon != null && Weapons.Contains(weapon))
            {
                weapon.Use();
                Console.WriteLine($"{Name} attaque avec {weapon.Name} (Dégâts: {weapon.Damage})");
            }
            else
            {
                Console.WriteLine($"{Name} ne peut pas attaquer avec {weapon?.Name}");
            }
        }

        /// <summary>
        /// Affiche la liste des armes possédées par le joueur
        /// </summary>
        public void ShowWeapons()
        {
            Console.WriteLine($"\nArmes de {Name} :");
            if (Weapons.Count == 0)
            {
                Console.WriteLine("Aucune arme.");
            }
            else
            {
                foreach (var weapon in Weapons)
                {
                    Console.WriteLine($"- {weapon.Name} (Dégâts: {weapon.Damage}, Portée: {weapon.Range})");
                }
            }
        }
    }

    /// <summary>
    /// Classe représentant une arme dans le jeu
    /// </summary>
    class Weapon
    {
        // Champs privés avec préfixe _
        private string _name;
        private int _damage;
        private float _range;
        private List<Player> _players;

        // Propriétés publiques
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public float Range
        {
            get { return _range; }
            set { _range = value; }
        }

        /// <summary>
        /// Liste des joueurs utilisant actuellement cette arme
        /// </summary>
        public List<Player> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        /// <summary>
        /// Constructeur de la classe Weapon
        /// </summary>
        /// <param name="name">Nom de l'arme</param>
        /// <param name="damage">Dégâts de l'arme</param>
        /// <param name="range">Portée de l'arme</param>
        public Weapon(string name, int damage, float range)
        {
            Name = name;
            Damage = damage;
            Range = range;
            Players = new List<Player>();
        }

        /// <summary>
        /// Utilise l'arme (affiche un message)
        /// </summary>
        public void Use()
        {
            Console.WriteLine($"L'arme {Name} est utilisée !");
        }

        /// <summary>
        /// Retourne les dégâts de l'arme
        /// </summary>
        /// <returns>Dégâts</returns>
        public int GetDamage()
        {
            return Damage;
        }

        /// <summary>
        /// Affiche la liste des joueurs utilisant cette arme
        /// </summary>
        public void ShowPlayers()
        {
            Console.WriteLine($"\nJoueurs utilisant {Name} :");
            if (Players.Count == 0)
            {
                Console.WriteLine("Aucun joueur.");
            }
            else
            {
                foreach (var player in Players)
                {
                    Console.WriteLine($"- {player.Name} (PV: {player.Health})");
                }
            }
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester la relation many-to-many entre Player et Weapon
    /// </summary>
    public static class Example3Demo
    {
        public static void Demo()
        {
            Console.WriteLine("=== Démonstration Many-to-Many: Players & Weapons ===\n");

            // Création des joueurs
            Player player1 = new Player("Alice", 100);
            Player player2 = new Player("Bob", 90);
            Player player3 = new Player("Charlie", 80);

            // Création des armes
            Weapon ak47 = new Weapon("AK-47", 35, 300f);
            Weapon pistol = new Weapon("Pistol", 15, 100f);
            Weapon sniper = new Weapon("Sniper", 80, 800f);

            // Ramassage d'armes
            player1.PickUpWeapon(ak47);
            player1.PickUpWeapon(pistol);
            player2.PickUpWeapon(ak47);
            player2.PickUpWeapon(sniper);
            player3.PickUpWeapon(pistol);

            // Attaques
            player1.AttackWithWeapon(ak47);
            player2.AttackWithWeapon(sniper);
            player3.AttackWithWeapon(pistol);

            // Affichage des armes de chaque joueur
            player1.ShowWeapons();
            player2.ShowWeapons();
            player3.ShowWeapons();

            // Affichage des joueurs utilisant chaque arme
            ak47.ShowPlayers();
            pistol.ShowPlayers();
            sniper.ShowPlayers();

            // Dépôt d'armes
            player1.DropWeapon(ak47);
            player2.DropWeapon(ak47);
            ak47.ShowPlayers();
        }
    }
} 