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

            Territoire territoire = new TerritoireCompo("Belgique");
            territoire.AddUnit("Soldat", "Ryan", 50, "marine");
            territoire.AddUnit("Tank", "Tank 1", 500, "Panzer");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();




        }
    }
}
