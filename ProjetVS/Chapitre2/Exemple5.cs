using System;
using System.Collections.Generic;

namespace UMLGames.Examples.Chapitre2
{
    /// <summary>
    /// Classe représentant un joueur avec un système de santé unique
    /// </summary>
    public class Player
    {
        // Champs privés avec préfixe _
        private string _name;
        private Weapon? _currentWeapon;
        private List<Item> _inventory;
        private HealthSystem _healthSystem;

        /// <summary>
        /// Constructeur de la classe Player
        /// </summary>
        /// <param name="name">Nom du joueur</param>
        /// <param name="maxHealth">Points de vie maximum du joueur</param>
        public Player(string name, int maxHealth)
        {
            _name = name;
            _inventory = new List<Item>();
            _currentWeapon = null;
            // Création du système de santé associé (relation 1-1)
            _healthSystem = new HealthSystem(maxHealth, this);
        }

        // Propriétés publiques
        public string Name => _name;
        public Weapon? CurrentWeapon => _currentWeapon;
        public IReadOnlyList<Item> Inventory => _inventory.AsReadOnly();
        public HealthSystem HealthSystem => _healthSystem;

        /// <summary>
        /// Permet au joueur d'attaquer (exemple simplifié)
        /// </summary>
        public void Attack()
        {
            if (_currentWeapon != null)
                Console.WriteLine($"{_name} attaque avec {_currentWeapon.Name} !");
            else
                Console.WriteLine($"{_name} attaque à mains nues !");
        }

        /// <summary>
        /// Permet d'équiper une arme
        /// </summary>
        /// <param name="weapon">Arme à équiper</param>
        public void EquipWeapon(Weapon weapon)
        {
            if (weapon != null)
            {
                _currentWeapon = weapon;
                Console.WriteLine($"{_name} a équipé l'arme {weapon.Name}");
            }
        }

        /// <summary>
        /// Ajoute un objet à l'inventaire
        /// </summary>
        /// <param name="item">Objet à ajouter</param>
        public void AddItem(Item item)
        {
            if (item != null && !_inventory.Contains(item))
            {
                _inventory.Add(item);
                Console.WriteLine($"{_name} a ajouté {item.Name} à son inventaire");
            }
        }
    }

    /// <summary>
    /// Classe représentant le système de santé d'un joueur (relation 1-1)
    /// </summary>
    public class HealthSystem
    {
        // ===== IMPLÉMENTATION DE LA RELATION 1 À 1 =====
        // Chaque joueur possède exactement un système de santé (HealthSystem)
        // La relation est stricte : un seul HealthSystem par Player, et réciproquement
        // Le HealthSystem est créé dans le constructeur du Player et n'est jamais partagé
        private int _currentHealth;
        private int _maxHealth;
        private bool _isInvulnerable;
        private Player _player;

        /// <summary>
        /// Constructeur de la classe HealthSystem
        /// </summary>
        /// <param name="maxHealth">Points de vie maximum</param>
        /// <param name="player">Joueur associé</param>
        public HealthSystem(int maxHealth, Player player)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            _isInvulnerable = false;
            _player = player;
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION 1 À 1 =====
        // Cette propriété permet d'accéder au joueur associé à ce système de santé
        // La relation est unidirectionnelle dans l'usage courant (HealthSystem -> Player)
        public Player Player => _player;

        // Propriétés publiques
        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;
        public bool IsInvulnerable => _isInvulnerable;

        /// <summary>
        /// Inflige des dégâts au joueur via le système de santé
        /// </summary>
        /// <param name="amount">Quantité de dégâts</param>
        // ===== UTILISATION DE LA RELATION 1 À 1 =====
        // Cette méthode modifie l'état du HealthSystem du Player associé
        public void TakeDamage(int amount)
        {
            if (_isInvulnerable)
            {
                Console.WriteLine($"{_player.Name} est invulnérable et ne subit aucun dégât !");
                return;
            }
            if (amount > 0)
            {
                _currentHealth -= amount;
                ClampHealth();
                Console.WriteLine($"{_player.Name} subit {amount} dégâts. PV restants : {_currentHealth}/{_maxHealth}");
            }
        }

        /// <summary>
        /// Soigne le joueur via le système de santé
        /// </summary>
        /// <param name="amount">Quantité de soins</param>
        // ===== UTILISATION DE LA RELATION 1 À 1 =====
        // Cette méthode modifie l'état du HealthSystem du Player associé
        public void Heal(int amount)
        {
            if (amount > 0)
            {
                _currentHealth += amount;
                ClampHealth();
                Console.WriteLine($"{_player.Name} récupère {amount} PV. PV actuels : {_currentHealth}/{_maxHealth}");
            }
        }

        /// <summary>
        /// Indique si le joueur est vivant
        /// </summary>
        /// <returns>True si vivant, sinon false</returns>
        public bool IsAlive()
        {
            return _currentHealth > 0;
        }

        /// <summary>
        /// Force les points de vie à rester dans les bornes valides
        /// </summary>
        private void ClampHealth()
        {
            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
            if (_currentHealth < 0)
                _currentHealth = 0;
        }
    }

    /// <summary>
    /// Classe représentant un objet d'inventaire (exemple simplifié)
    /// </summary>
    public class Item
    {
        private string _name;
        public string Name => _name;
        public Item(string name) { _name = name; }
    }

    /// <summary>
    /// Classe représentant une arme (exemple simplifié)
    /// </summary>
    public class Weapon : Item
    {
        public Weapon(string name) : base(name) { }
    }

    /// <summary>
    /// Classe de démonstration pour tester la relation 1-1 entre Player et HealthSystem
    /// </summary>
    public static class Example5Demo
    {
        public static void Demo()
        {
            Console.WriteLine("--- Démonstration Exemple 5 : Joueur et Système de Santé (1 à 1) ---");

            // Création d'un joueur avec 100 PV max
            Player ryu = new Player("Ryu", 100);
            Weapon katana = new Weapon("Katana");
            Item potion = new Item("Potion de soin");

            // Ajout d'objets et d'une arme
            ryu.AddItem(potion);
            ryu.EquipWeapon(katana);

            // Attaque
            ryu.Attack();

            // Dégâts et soins
            ryu.HealthSystem.TakeDamage(30);
            ryu.HealthSystem.Heal(20);
            ryu.HealthSystem.TakeDamage(200); // Test KO

            // Test invulnérabilité
            Console.WriteLine("Ryu devient invulnérable !");
            // (Accès direct pour la démo, sinon prévoir une méthode)
            typeof(HealthSystem).GetField("_isInvulnerable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(ryu.HealthSystem, true);
            ryu.HealthSystem.TakeDamage(50);
        }
    }
} 