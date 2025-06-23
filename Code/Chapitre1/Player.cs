using System;

namespace Chapitre1
{
    public class Player
    {
        private string name;
        private int health;
        private int maxHealth;

        public Player(string name, int maxHealth)
        {
            this.name = name;
            this.maxHealth = maxHealth;
            this.health = maxHealth;
        }

        public void UsePotion(HealthPotion potion)
        {
            int healing = potion.Use();
            health = Math.Min(health + healing, maxHealth);
            Console.WriteLine($"{name} se soigne de {healing} points. Santé : {health}/{maxHealth}");
        }

        public void TakeDamage(int damage)
        {
            health = Math.Max(health - damage, 0);
            Console.WriteLine($"{name} prend {damage} dégâts. Santé : {health}/{maxHealth}");
        }

        public bool IsAlive() => health > 0;
        
        public int GetHealth() => health;
        public int GetMaxHealth() => maxHealth;
        public string GetName() => name;
    }
} 