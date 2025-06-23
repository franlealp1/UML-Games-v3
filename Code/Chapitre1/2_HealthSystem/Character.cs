namespace GameDev.Chapitre1.Health
{
    public class Character
    {
        private string name;
        private HealthSystem health;

        public Character(string name, int maxHealth)
        {
            this.name = name;
            this.health = new HealthSystem(maxHealth);
        }

        public void TakeDamage(int amount) => health.TakeDamage(amount);
        public void Heal(int amount) => health.Heal(amount);
        public string GetStatus() => $"{name}: {health.GetCurrentHealth()}/{health.GetMaxHealth()} HP - {(health.IsAlive() ? "Vivant" : "Mort")}";
    }
}
