using System;

namespace CoursUML
{
    class Program
    {
        static void Main(string[] args)
        {
            Personnage perso1 = new Personnage(50, "Lola");
            perso1.Attaquer();
            perso1.SeDeplacer(100, 200);
        }
    }
}
