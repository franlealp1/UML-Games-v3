namespace GameDev.Chapitre1.Combat
{
    public class Weapon
    {
        private string name;
        private int baseDamage;
        private float range;

        public Weapon(string name, int damage, float range)
        {
            this.name = name;
            this.baseDamage = damage;
            this.range = range;
        }

        public string GetName() => name;
        public int GetDamage() => baseDamage;
    }
}
