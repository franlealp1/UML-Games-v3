using System;

namespace GameDev.Chapitre1.Combat
{
    public class GameCharacter
    {
        private string name;
        private HealthSystem health;
        private WeaponSystem weaponSystem;

        public GameCharacter(string name, int maxHealth)
        {
            this.name = name;
            this.health = new HealthSystem(maxHealth);
            this.weaponSystem = new WeaponSystem();
        }

        public void Attack(GameCharacter target)
        {
            int damage = weaponSystem.CalculateDamage();
            Console.WriteLine($"{name} attaque {target.name} avec {weaponSystem.GetWeaponName()} pour {damage} dégâts!");
            target.TakeDamage(damage);
        }

        public void EquipWeapon(Weapon weapon)
        {
            weaponSystem.ChangeWeapon(weapon);
        }

        public void TakeDamage(int amount)
        {
            health.TakeDamage(amount);
        }

        public string GetStatus()
        {
            return $"{name}: {health.GetCurrentHealth()}/{health.GetMaxHealth()} HP - Arme: {weaponSystem.GetWeaponName()}";
        }
    }
}
