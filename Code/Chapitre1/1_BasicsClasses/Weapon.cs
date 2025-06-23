using System;

namespace GameDev.Chapitre1.Basics
{
    public class Weapon
    {
        private string name;
        private int damage;
        private float range;

        public Weapon(string name, int damage, float range)
        {
            this.name = name;
            this.damage = damage;
            this.range = range;
        }

        public void Use()
        {
            Console.WriteLine($"Utilisation de {name} - Dégâts: {damage} - Portée: {range}");
        }

        public string GetName() => name;
        public int GetDamage() => damage;
        public void SetDamage(int value) => damage = value;
    }
}
