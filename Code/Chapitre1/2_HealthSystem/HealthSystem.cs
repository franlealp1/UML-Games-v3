using System;

namespace GameDev.Chapitre1.Health
{
    public class HealthSystem
    {
        private int currentHealth;
        private int maxHealth;
        private bool isInvulnerable;

        public HealthSystem(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;
            this.isInvulnerable = false;
        }

        public void TakeDamage(int amount)
        {
            if (!isInvulnerable)
            {
                currentHealth -= amount;
                ClampHealth();
            }
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
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
