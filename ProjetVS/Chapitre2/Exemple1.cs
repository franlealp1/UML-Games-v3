using System;
using System.Collections.Generic;

namespace UMLGames.Examples.Chapitre2
{
    /// <summary>
    /// Classe représentant un personnage dans le jeu
    /// </summary>
    public class Character
    {
        // Propriétés privées avec préfixe _ selon la convention du projet
        private string _name;
        private int _health;
        
        // ===== IMPLÉMENTATION DE LA RELATION 1 À PLUSIEURS =====
        // Un personnage peut posséder plusieurs véhicules (one-to-many)
        // Cette liste contient tous les véhicules possédés par le personnage
        private List<Vehicle> _vehicles;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'UTILISATION =====
        // Un personnage peut utiliser un seul véhicule à la fois (association simple)
        // Cette référence pointe vers le véhicule actuellement utilisé
        private Vehicle? _currentVehicle;

        /// <summary>
        /// Constructeur de la classe Character
        /// </summary>
        /// <param name="name">Nom du personnage</param>
        /// <param name="health">Points de vie du personnage</param>
        public Character(string name, int health)
        {
            _name = name;
            _health = health;
            // ===== INITIALISATION DE LA RELATION 1 À PLUSIEURS =====
            // Initialisation de la liste des véhicules (relation one-to-many)
            _vehicles = new List<Vehicle>();
            _currentVehicle = null;
        }

        // Propriétés publiques
        public string Name => _name;
        public int Health => _health;
        
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION 1 À PLUSIEURS =====
        // Cette propriété permet d'accéder à tous les véhicules du personnage
        // Notez l'utilisation de AsReadOnly() pour protéger la collection interne
        public IReadOnlyList<Vehicle> Vehicles => _vehicles.AsReadOnly();
        
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION D'UTILISATION =====
        // Cette propriété permet d'accéder au véhicule actuellement utilisé
        public Vehicle? CurrentVehicle => _currentVehicle;

        /// <summary>
        /// Ajoute un véhicule à la collection du personnage
        /// </summary>
        /// <param name="vehicle">Véhicule à ajouter</param>
        public void AddVehicle(Vehicle vehicle)
        {
            // ===== GESTION DE LA RELATION 1 À PLUSIEURS =====
            // Vérification que le véhicule n'est pas null et qu'il n'est pas déjà possédé
            if (vehicle != null && !_vehicles.Contains(vehicle))
            {
                // Ajout du véhicule dans la liste des véhicules possédés
                _vehicles.Add(vehicle);
                Console.WriteLine($"{_name} possède maintenant le véhicule {vehicle.Name}");
            }
        }

        /// <summary>
        /// Permet au personnage de monter sur un véhicule
        /// </summary>
        /// <param name="vehicle">Véhicule à utiliser</param>
        public void MountVehicle(Vehicle vehicle)
        {
            // ===== GESTION DE LA RELATION D'UTILISATION =====
            // Vérification que le véhicule n'est pas null et qu'il est possédé par le personnage
            if (vehicle != null && _vehicles.Contains(vehicle))
            {
                // Établissement de la relation d'utilisation
                _currentVehicle = vehicle;
                Console.WriteLine($"{_name} monte sur {vehicle.Name}");
            }
            else
            {
                Console.WriteLine($"{_name} ne possède pas ce véhicule");
            }
        }

        /// <summary>
        /// Permet au personnage de descendre du véhicule actuel
        /// </summary>
        public void DismountVehicle()
        {
            // ===== SUPPRESSION DE LA RELATION D'UTILISATION =====
            // Vérification qu'un véhicule est actuellement utilisé
            if (_currentVehicle != null)
            {
                Console.WriteLine($"{_name} descend de {_currentVehicle.Name}");
                // Suppression de la relation d'utilisation
                _currentVehicle = null;
            }
        }

        /// <summary>
        /// Retourne le véhicule actuellement utilisé par le personnage
        /// </summary>
        /// <returns>Le véhicule actuel ou null si aucun</returns>
        public Vehicle? GetCurrentVehicle()
        {
            return _currentVehicle;
        }
    }

    /// <summary>
    /// Classe représentant un véhicule dans le jeu
    /// </summary>
    public class Vehicle
    {
        // Propriétés privées avec préfixe _ selon la convention du projet
        private string _name;
        private float _speed;
        private string _type;

        /// <summary>
        /// Constructeur de la classe Vehicle
        /// </summary>
        /// <param name="name">Nom du véhicule</param>
        /// <param name="speed">Vitesse du véhicule</param>
        /// <param name="type">Type de véhicule</param>
        public Vehicle(string name, float speed, string type)
        {
            _name = name;
            _speed = speed;
            _type = type;
        }

        // Propriétés publiques
        public string Name => _name;
        public float Speed => _speed;
        public string Type => _type;

        /// <summary>
        /// Déplace le véhicule à sa vitesse actuelle
        /// </summary>
        public void Move()
        {
            Console.WriteLine($"{_name} se déplace à {_speed} km/h");
        }

        /// <summary>
        /// Retourne la vitesse actuelle du véhicule
        /// </summary>
        /// <returns>La vitesse en km/h</returns>
        public float GetSpeed()
        {
            return _speed;
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester les relations entre Character et Vehicle
    /// </summary>
    public static class CharacterExemple1
    {
        public static void Demo()
        {
            Console.WriteLine("--- Démonstration Exemple 1 : Personnage et Véhicule (1 à plusieurs) ---");
            
            // Création d'un personnage
            Character link = new Character("Link", 100);
            
            // Création de véhicules
            Vehicle cheval = new Vehicle("Epona", 30, "Cheval");
            Vehicle bateau = new Vehicle("Bateau", 20, "Navire");
            
            // ===== DÉMONSTRATION DE LA RELATION 1 À PLUSIEURS =====
            // Ajout de véhicules à la collection du personnage
            link.AddVehicle(cheval);
            link.AddVehicle(bateau);
            
            // ===== DÉMONSTRATION DE LA RELATION D'UTILISATION =====
            // Utilisation d'un véhicule par le personnage
            link.MountVehicle(cheval);
            Console.WriteLine($"Véhicule actuel : {link.CurrentVehicle?.Name}");
            link.DismountVehicle();
            
            // Test de validation: tentative d'utiliser un véhicule non possédé
            Vehicle avion = new Vehicle("Avion", 100, "Aérien");
            link.MountVehicle(avion); // Message d'erreur attendu
        }
    }
} 