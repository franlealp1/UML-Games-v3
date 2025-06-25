// === Exemple 1: Personnage et Véhicule (Association 1 à Plusieurs) ===
// Dans de nombreux jeux, un personnage peut utiliser plusieurs véhicules différents.
// Inspiré de The Legend of Zelda où Link peut monter un cheval, utiliser un bateau, ou voler avec un oiseau.

using System;
using System.Collections.Generic;

namespace UMLGames.Examples.Chapitre2
{
    /// <summary>
    /// Représente un personnage pouvant utiliser différents véhicules.
    /// 
    /// L'implémentation de la relation d'association 1 à plusieurs (1..*):
    /// - La liste 'vehicles' dans Character représente la collection de véhicules associés à ce personnage.
    /// Rien à voir avec la relation, on rajoute un champ 'currentVehicle' qui indique lequel de ces véhicules est actuellement utilisé (optionnel mais très courant en jeu vidéo).
    /// </summary>
    public class Character
    {
        private string name;
        private int health;
        // --- Début de l'implémentation de la relation 1 à plusieurs ---
        
        /// <summary>
        /// Liste des véhicules que possède ce personnage (relation 1 à plusieurs)
        /// </summary>
        private List<Vehicle> vehicles;
        /// <summary>
        /// Véhicule actuellement utilisé (optionnel, pour illustrer l'état courant)
        /// </summary>
        private Vehicle currentVehicle;
        // --- Fin de l'implémentation de la relation 1 à plusieurs ---

        public Character(string name, int health)
        {
            this.name = name;
            this.health = health;
            this.vehicles = new List<Vehicle>();
            this.currentVehicle = null;
        }

        public string Name => name;
        public int Health => health;
        // Lecture seule : ainsi, la liste ne peut être modifiée que par les méthodes de la classe (bonne pratique POO)
        public IReadOnlyList<Vehicle> Vehicles => vehicles.AsReadOnly();
        public Vehicle CurrentVehicle => currentVehicle;

        /// <summary>
        /// Ajoute un véhicule à la liste de véhicules du personnage.
        /// </summary>
        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle != null && !vehicles.Contains(vehicle))
            {
                vehicles.Add(vehicle);
                Console.WriteLine($"{name} possède maintenant le véhicule {vehicle.Name}");
            }
        }

        /// <summary>
        /// Monte un véhicule (doit être dans la liste de véhicules du personnage).
        /// </summary>
        public void MountVehicle(Vehicle vehicle)
        {
            if (vehicle != null && vehicles.Contains(vehicle))
            {
                currentVehicle = vehicle;
                Console.WriteLine($"{name} monte sur {vehicle.Name}");
            }
            else
            {
                Console.WriteLine($"{name} ne possède pas ce véhicule");
            }
        }

        /// <summary>
        /// Descend du véhicule actuel.
        /// </summary>
        public void DismountVehicle()
        {
            if (currentVehicle != null)
            {
                Console.WriteLine($"{name} descend de {currentVehicle.Name}");
                currentVehicle = null;
            }
        }

        /// <summary>
        /// Obtient le véhicule actuellement monté.
        /// </summary>
        public Vehicle GetCurrentVehicle()
        {
            return currentVehicle;
        }
    }

    /// <summary>
    /// Représente un véhicule utilisable par un personnage.
    /// </summary>
    public class Vehicle
    {
        private string name;
        private float speed;
        private string type;

        public Vehicle(string name, float speed, string type)
        {
            this.name = name;
            this.speed = speed;
            this.type = type;
        }

        public string Name => name;
        public float Speed => speed;
        public string Type => type;

        /// <summary>
        /// Déplace le véhicule.
        /// </summary>
        public void Move()
        {
            Console.WriteLine($"{name} se déplace à {speed} km/h");
        }

        /// <summary>
        /// Obtient la vitesse du véhicule.
        /// </summary>
        /// <returns>La vitesse en km/h</returns>
        public float GetSpeed()
        {
            return speed;
        }
    }

    // === Classe de démonstration pour l'Exemple 1 ===
    public static class CharacterExemple1
    {
        /// <summary>
        /// Méthode de démonstration pour l'exemple 1 (Personnage et Véhicule)
        /// </summary>
        public static void Demo()
        {
            Console.WriteLine("--- Démonstration Exemple 1 : Personnage et Véhicule (1 à plusieurs) ---");
            Character link = new Character("Link", 100);
            Vehicle cheval = new Vehicle("Epona", 30, "Cheval");
            Vehicle bateau = new Vehicle("Bateau", 20, "Navire");

            link.AddVehicle(cheval);
            link.AddVehicle(bateau);

            link.MountVehicle(cheval);
            Console.WriteLine($"Véhicule actuel : {link.CurrentVehicle?.Name}");

            link.DismountVehicle();

            Vehicle avion = new Vehicle("Avion", 100, "Aérien");
            link.MountVehicle(avion); // Message d'erreur attendu, il ne possède pas le véhicule car on ne l'a pas ajouté
        }
    }
}
