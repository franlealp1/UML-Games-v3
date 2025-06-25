using System;
using UMLGames.Examples.Chapitre2; // Namespace trouvé dans Exemple1.cs

namespace CoursUML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Menu de démonstration des exemples UML ===");
            Console.WriteLine("1. Chapitre 2 - Exemple 1 : Personnage et Véhicule");
            Console.WriteLine("2. Chapitre 2 - Exemple 2 : Joueur et Scores");
            // Console.WriteLine("3. Chapitre 3 - Exemple 1 : ...");
            // Ajoute ici les autres chapitres et exemples
            Console.WriteLine("0. Quitter");
            Console.Write("Choisissez un exemple à lancer : ");
            var choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    CharacterExemple1.Demo();
                    break;
                case "2":
                    Exemple2.Demo();
                    break;
                // case "3":
                //     Chapitre3Exemple1.Demo();
                //     break;
                case "0":
                    Console.WriteLine("Au revoir !");
                    break;
                default:
                    Console.WriteLine("Choix non reconnu.");
                    break;
            }
        }
    }
}
