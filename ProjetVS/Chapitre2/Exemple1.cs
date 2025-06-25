using System;
using System.Collections.Generic;

namespace UMLGames.Examples.Chapitre2
{
    public class Character
    {
        private string _name;
        private int _health;
        private List<Vehicle> _vehicles;
        private Vehicle? _currentVehicle;

        public Character(string name, int health)
        {
            _name = name;
            _health = health;
            _vehicles = new List<Vehicle>();
            _currentVehicle = null;
        }

        public string Name => _name;
        public int Health => _health;
        public IReadOnlyList<Vehicle> Vehicles => _vehicles.AsReadOnly();
        public Vehicle? CurrentVehicle => _currentVehicle;

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle != null && !_vehicles.Contains(vehicle))
            {
                _vehicles.Add(vehicle);
                Console.WriteLine($"{_name} possède maintenant le véhicule {vehicle.Name}");
            }
        }

        public void MountVehicle(Vehicle vehicle)
        {
            if (vehicle != null && _vehicles.Contains(vehicle))
            {
                _currentVehicle = vehicle;
                Console.WriteLine($"{_name} monte sur {vehicle.Name}");
            }
            else
            {
                Console.WriteLine($"{_name} ne possède pas ce véhicule");
            }
        }

        public void DismountVehicle()
        {
            if (_currentVehicle != null)
            {
                Console.WriteLine($"{_name} descend de {_currentVehicle.Name}");
                _currentVehicle = null;
            }
        }

        public Vehicle? GetCurrentVehicle()
        {
            return _currentVehicle;
        }
    }

    public class Vehicle
    {
        private string _name;
        private float _speed;
        private string _type;

        public Vehicle(string name, float speed, string type)
        {
            _name = name;
            _speed = speed;
            _type = type;
        }

        public string Name => _name;
        public float Speed => _speed;
        public string Type => _type;

        public void Move()
        {
            Console.WriteLine($"{_name} se déplace à {_speed} km/h");
        }

        public float GetSpeed()
        {
            return _speed;
        }
    }

    public static class CharacterExemple1
    {
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
            link.MountVehicle(avion); // Message d'erreur attendu
        }
    }
} 