using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML
{
    // ===== IMPLÉMENTATION DU DIAGRAMME UML =====
    // Ce fichier implémente une relation many-to-many entre Player et Weapon
    // Cette relation permet à :
    // 1. Un joueur de posséder plusieurs armes
    // 2. Une arme d'être utilisée par plusieurs joueurs
    // La relation est implémentée par des listes croisées dans les deux classes
    /// <summary>
    /// Classe représentant un joueur dans un jeu multijoueur (ex: Counter-Strike)
    /// </summary>
    // ===== CLASSE PARTICIPANT À LA RELATION MANY-TO-MANY =====
    // Cette classe représente un côté de la relation many-to-many
    // Un joueur peut posséder plusieurs armes
    class Player
    {
        // Champs privés avec préfixe _
        private string _name;
        private int _health;
        
        // ===== IMPLÉMENTATION DE LA RELATION MANY-TO-MANY =====
        // Un joueur peut posséder plusieurs armes
        // Une arme peut être utilisée par plusieurs joueurs
        // Les deux classes contiennent une liste de l'autre type
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
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION MANY-TO-MANY =====
        // Cette propriété permet d'accéder à toutes les armes du joueur
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
            // ===== INITIALISATION DE LA RELATION MANY-TO-MANY =====
            // Initialisation de la liste des armes (relation many-to-many)
            Weapons = new List<Weapon>();
        }

        /// <summary>
        /// Permet au joueur de ramasser une arme
        /// </summary>
        /// <param name="weapon">Arme à ramasser</param>
        // ===== GESTION DE LA RELATION MANY-TO-MANY =====
        // Cette méthode établit la relation bidirectionnelle entre Player et Weapon
        // Elle maintient la cohérence des deux côtés de la relation
        public void PickUpWeapon(Weapon weapon)
        {
            if (weapon != null && !Weapons.Contains(weapon))
            {
                // ===== MAINTIEN DE LA COHÉRENCE BIDIRECTIONNELLE =====
                // Ajout de l'arme dans la liste du joueur
                Weapons.Add(weapon);
                // Ajout du joueur dans la liste de l'arme
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
        // ===== SUPPRESSION DE LA RELATION MANY-TO-MANY =====
        // Cette méthode supprime la relation bidirectionnelle entre Player et Weapon
        // Elle maintient la cohérence des deux côtés de la relation
        public void DropWeapon(Weapon weapon)
        {
            if (weapon != null && Weapons.Contains(weapon))
            {
                // ===== MAINTIEN DE LA COHÉRENCE BIDIRECTIONNELLE =====
                // Suppression de l'arme de la liste du joueur
                Weapons.Remove(weapon);
                // Suppression du joueur de la liste de l'arme
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
        // ===== PARCOURS DE LA RELATION MANY-TO-MANY =====
        // Cette méthode parcourt un côté de la relation many-to-many
        // Elle affiche toutes les armes associées au joueur
        public void ShowWeapons()
        {
            Console.WriteLine($"\nArmes de {Name} :");
            if (Weapons.Count == 0)
            {
                Console.WriteLine("Aucune arme.");
            }
            else
            {
                // ===== PARCOURS DES OBJETS ASSOCIÉS =====
                // Parcours de toutes les armes du joueur
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
    // ===== CLASSE PARTICIPANT À LA RELATION MANY-TO-MANY =====
    // Cette classe représente l'autre côté de la relation many-to-many
    // Une arme peut être utilisée par plusieurs joueurs
    class Weapon
    {
        // Champs privés avec préfixe _
        private string _name;
        private int _damage;
        private float _range;
        
        // ===== IMPLÉMENTATION DE LA RELATION MANY-TO-MANY =====
        // Cette liste stocke tous les joueurs qui possèdent cette arme
        // C'est l'autre côté de la relation many-to-many
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
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION MANY-TO-MANY =====
        // Cette propriété permet d'accéder à tous les joueurs possédant cette arme
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
            // ===== INITIALISATION DE LA RELATION MANY-TO-MANY =====
            // Initialisation de la liste des joueurs (relation many-to-many)
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
        // ===== PARCOURS DE LA RELATION MANY-TO-MANY =====
        // Cette méthode parcourt l'autre côté de la relation many-to-many
        // Elle affiche tous les joueurs associés à cette arme
        public void ShowPlayers()
        {
            Console.WriteLine($"\nJoueurs utilisant {Name} :");
            if (Players.Count == 0)
            {
                Console.WriteLine("Aucun joueur.");
            }
            else
            {
                // ===== PARCOURS DES OBJETS ASSOCIÉS =====
                // Parcours de tous les joueurs possédant cette arme
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

            // ===== CRÉATION DES INSTANCES =====
            // Création des instances de Player
            Player player1 = new Player("Alice", 100);
            Player player2 = new Player("Bob", 90);
            Player player3 = new Player("Charlie", 80);

            // ===== CRÉATION DES INSTANCES =====
            // Création des instances de Weapon
            Weapon ak47 = new Weapon("AK-47", 35, 300f);
            Weapon pistol = new Weapon("Pistol", 15, 100f);
            Weapon sniper = new Weapon("Sniper", 80, 800f);

            // ===== ÉTABLISSEMENT DE LA RELATION MANY-TO-MANY =====
            // Création des relations bidirectionnelles entre joueurs et armes
            player1.PickUpWeapon(ak47);   // Alice ramasse AK-47
            player1.PickUpWeapon(pistol); // Alice ramasse Pistol
            player2.PickUpWeapon(ak47);   // Bob ramasse AK-47 (même arme qu'Alice)
            player2.PickUpWeapon(sniper); // Bob ramasse Sniper
            player3.PickUpWeapon(pistol); // Charlie ramasse Pistol (même arme qu'Alice)

            // Attaques
            player1.AttackWithWeapon(ak47);
            player2.AttackWithWeapon(sniper);
            player3.AttackWithWeapon(pistol);

            // ===== PARCOURS DE LA RELATION MANY-TO-MANY (CÔTÉ PLAYER) =====
            // Affichage des armes possédées par chaque joueur
            player1.ShowWeapons(); // Alice possède AK-47 et Pistol
            player2.ShowWeapons(); // Bob possède AK-47 et Sniper
            player3.ShowWeapons(); // Charlie possède Pistol

            // ===== PARCOURS DE LA RELATION MANY-TO-MANY (CÔTÉ WEAPON) =====
            // Affichage des joueurs possédant chaque arme
            ak47.ShowPlayers();   // AK-47 est possédée par Alice et Bob
            pistol.ShowPlayers(); // Pistol est possédée par Alice et Charlie
            sniper.ShowPlayers(); // Sniper est possédée par Bob

            // ===== SUPPRESSION DE LA RELATION MANY-TO-MANY =====
            // Suppression des relations bidirectionnelles
            player1.DropWeapon(ak47); // Alice dépose AK-47
            player2.DropWeapon(ak47); // Bob dépose AK-47
            
            // ===== VÉRIFICATION DE LA COHÉRENCE DE LA RELATION =====
            // Vérification qu'aucun joueur ne possède plus l'AK-47
            ak47.ShowPlayers(); // Devrait afficher "Aucun joueur"
        }
    }
} 