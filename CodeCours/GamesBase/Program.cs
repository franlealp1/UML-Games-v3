using System;

namespace CoursUML
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Soldat s = new Soldat("Pepe", 5 , "infantry");
            // Tank t = new Tank("T1", 100, "Panzer");

            // Territoire territoire = new Territoire("Belgique");
            // territoire.AddUnit(s);
            // territoire.AddUnit(s);
            // territoire.AddUnit(t);

            // territoire.Afficher();
            // // s.Attaquer();
            // // t.Attaquer();

            // Territoire territoire = new TerritoireCompo("Belgique");
            // territoire.AddUnit("Soldat", "Ryan", 50, "marine");
            // territoire.AddUnit("Tank", "Tank 1", 500, "Panzer");

            Character c1 = new Character("Bilbo");
            Character c2 = new Character("Tom");

            Skill s1 = new Skill("invisibilite", "magie");
            Skill s2 = new Skill("chant", "musique");
            Skill s3 = new Skill("épée", "combat");

            SkillLevel sk1 = new SkillLevel(c1, s1, 40, 2);
            SkillLevel sk2 = new SkillLevel(c1, s2, 80, 3);
            c1.AddSkillLevel(sk1);
            c1.AddSkillLevel(sk2);

            c1.Display();









            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();




        }
    }
}
