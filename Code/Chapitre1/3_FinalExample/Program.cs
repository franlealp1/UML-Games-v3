using System;

namespace GameDev.Chapitre1.Combat
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création des armes
            var sword = new Weapon("Épée", 20, 1.5f);
            var bow = new Weapon("Arc", 15, 10.0f);

            // Création des personnages
            var hero = new GameCharacter("Héros", 100);
            var enemy = new GameCharacter("Gobelin", 50);

            // Équipement des armes
            hero.EquipWeapon(sword);
            enemy.EquipWeapon(bow);

            // Simulation d'un combat
            Console.WriteLine("=== Début du Combat ===\n");
            
            Console.WriteLine(hero.GetStatus());
            Console.WriteLine(enemy.GetStatus() + "\n");

            // Premier tour
            hero.Attack(enemy);
            Console.WriteLine("=== Tour 1 ===");
            Console.WriteLine(hero.GetStatus());
            Console.WriteLine(enemy.GetStatus() + "\n");

            // Deuxième tour
            enemy.Attack(hero);
            Console.WriteLine("=== Tour 2 ===");
            Console.WriteLine(hero.GetStatus());
            Console.WriteLine(enemy.GetStatus() + "\n");

            Console.WriteLine("=== Fin du Combat ===");
        }
    }
}
