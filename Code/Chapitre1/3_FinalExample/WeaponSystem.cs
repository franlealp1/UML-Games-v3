namespace GameDev.Chapitre1.Combat
{
    public class WeaponSystem
    {
        private Weapon currentWeapon;
        private float damageMultiplier = 1.0f;

        public int CalculateDamage()
        {
            if (currentWeapon == null)
                return 1;  // Dégâts à mains nues
            
            return (int)(currentWeapon.GetDamage() * damageMultiplier);
        }

        public void ChangeWeapon(Weapon newWeapon)
        {
            currentWeapon = newWeapon;
        }

        public string GetWeaponName()
        {
            return currentWeapon?.GetName() ?? "Mains nues";
        }
    }
}
