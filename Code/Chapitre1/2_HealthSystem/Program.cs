using System;

namespace GameDev.Chapitre1.Health
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'un personnage avec système de santé
            var player = new Character("Héros", 100);
            
            Console.WriteLine($"État initial: {player.GetStatus()}");
            
            // Test du système de santé
            player.TakeDamage(30);
            Console.WriteLine($"Après dégâts: {player.GetStatus()}");
            
            player.Heal(20);
            Console.WriteLine($"Après soin: {player.GetStatus()}");
            
            player.TakeDamage(150);  // Dégâts mortels
            Console.WriteLine($"État final: {player.GetStatus()}");
        }
    }
}
