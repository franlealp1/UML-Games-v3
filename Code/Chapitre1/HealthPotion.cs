using System;

namespace Chapitre1
{
    public class HealthPotion
    {
        private int healingAmount;

        public HealthPotion(int healingAmount)
        {
            if (!ValidateAmount(healingAmount))
                throw new ArgumentException("La quantité de guérison doit être entre 0 et 100");
            
            this.healingAmount = healingAmount;
        }

        public int Use()
        {
            Console.WriteLine($"Potion utilisée ! Guérison : {healingAmount}");
            return healingAmount;
        }

        public int GetHealingAmount() => healingAmount;

        private bool ValidateAmount(int value)
        {
            return value >= 0 && value <= 100;
        }
    }
} 