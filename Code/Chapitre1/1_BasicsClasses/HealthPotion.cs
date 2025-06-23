using System;

namespace GameDev.Chapitre1.Basics
{
    public class HealthPotion
    {
        private int healingPower;
        private int doses;
        private const int MAX_DOSES = 10;

        public HealthPotion(int power)
        {
            if (!ValidatePower(power))
                throw new ArgumentException("La puissance curative doit être entre 0 et 100");
            
            this.healingPower = power;
            this.doses = MAX_DOSES;
        }

        public void Refill(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("La quantité doit être positive");
                
            doses = Math.Min(doses + amount, MAX_DOSES);
            Console.WriteLine($"Flacon rempli. Doses actuelles : {doses}/{MAX_DOSES}");
        }

        public bool Use()
        {
            if (doses <= 0)
            {
                Console.WriteLine("Flacon vide ! Impossible d'utiliser la potion.");
                return false;
            }

            doses--;
            Console.WriteLine($"Utilisation de {healingPower} - Doses: {doses}/{MAX_DOSES}");
            return true;
        }

        public int GetDoses() => doses;
        public int GetHealingPower() => healingPower;

        private bool ValidatePower(int value)
        {
            return value >= 0 && value <= 100;
        }
    }
}
