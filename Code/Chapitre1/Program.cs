using System;

namespace Chapitre1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Chapitre 1 : Classes de Base ===");
            
            // Test de la classe Weapon
            Console.WriteLine("\n--- Test Weapon ---");
            Weapon sword = new Weapon("Épée en fer", 25);
            Weapon axe = new Weapon("Hache de guerre", 35);
            
            sword.DisplayInfo();
            axe.DisplayInfo();
            
            // Test de la classe HealthPotion et Player
            Console.WriteLine("\n--- Test HealthPotion et Player ---");
            Player hero = new Player("Hero", 100);
            HealthPotion potion = new HealthPotion(30);
            
            Console.WriteLine($"État initial : {hero.GetName()} - Santé : {hero.GetHealth()}/{hero.GetMaxHealth()}");
            
            hero.TakeDamage(50);  // Le héros prend des dégâts
            hero.UsePotion(potion); // Le héros utilise la potion
            
            Console.WriteLine($"État final : {hero.GetName()} - Santé : {hero.GetHealth()}/{hero.GetMaxHealth()}");
            Console.WriteLine($"Le héros est-il vivant ? {hero.IsAlive()}");
        }
    }
} 