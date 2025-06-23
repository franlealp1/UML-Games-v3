using System;

namespace CoursUML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Personnage perso1 = new Personnage(50, "Lola");
            // perso1.Attaquer();
            // perso1.SeDeplacer(100, 200);
            Personnage perso1 = new Personnage(50, "Sheppard");
            Arme uzi = new Arme("Uzi", 15);
            Arme arbalete = new Arme("Arbalète", 25);

            perso1.ListeArmes.Add(uzi);
            perso1.ListeArmes.Add(arbalete);




        }
    }
}
