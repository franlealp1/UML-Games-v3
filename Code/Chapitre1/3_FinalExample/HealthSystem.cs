using System;

namespace GameDev.Chapitre1.Combat
{
    public class HealthSystem
    {
        private int currentHealth;
        private int maxHealth;

        public HealthSystem(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            ClampHealth();
        }

        public bool IsAlive() => currentHealth > 0;
        public int GetCurrentHealth() => currentHealth;
        public int GetMaxHealth() => maxHealth;

        private void ClampHealth()
        {
            currentHealth = Math.Max(0, Math.Min(currentHealth, maxHealth));
        }
    }
}
