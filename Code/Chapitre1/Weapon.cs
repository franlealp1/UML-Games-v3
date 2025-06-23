using System;

namespace Chapitre1
{
    public class Weapon
    {
        private string name;
        private int damage;

        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }

        public string GetName() => name;
        public int GetDamage() => damage;

        public void DisplayInfo()
        {
            Console.WriteLine($"Arme : {name} - Dégâts : {damage}");
        }
    }
} 