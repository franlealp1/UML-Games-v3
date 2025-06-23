using System;
using TotoWeapon = Toto.Weapon;
using Toto;


namespace GameDev.Chapitre1.Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'objets à partir de classes
            Weapon sword = new Weapon("Épée", 10, 1.5f);
            Weapon bow = new Weapon("Arc", 8, 10.0f);

            Console.WriteLine($"Arme 1: {sword.GetName()} - Dégâts: {sword.GetDamage()}");
            Console.WriteLine($"Arme 2: {bow.GetName()} - Dégâts: {bow.GetDamage()}");

            // Test des méthodes
            sword.Use();
            bow.Use();

            HealthPotion wand = new HealthPotion(50);
            wand.Use();

            Perso p1 = new Perso("lola");
            p1.Equiper (new TotoWeapon("hola",99));
            p1.Attack();

        }
    }
}
