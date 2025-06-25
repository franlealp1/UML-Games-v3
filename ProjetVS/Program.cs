using System;
using UMLGames.Examples.Chapitre2; // Namespace trouvé dans Exemple1.cs
using CoursUML; // Namespace pour les solutions des exercices

namespace CoursUML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Menu de démonstration des exemples UML ===");
            Console.WriteLine("1. Chapitre 2 - Exemple 1 : Personnage et Véhicule");
            Console.WriteLine("2. Chapitre 2 - Exemple 2 : Joueur et Scores");
            Console.WriteLine("3. Chapitre 2 - Exercice 2 : Système d'Athlétisme");
            Console.WriteLine("4. Chapitre 2 - Exercice 3 : Système de Guildes et Membres");
            Console.WriteLine("5. Chapitre 2 - Exercice 4 : Système de Potions dans The Witcher");
            // Console.WriteLine("6. Chapitre 3 - Exemple 1 : ...");
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
                case "3":
                    AthlétismeExercice2.Demo();
                    break;
                case "4":
                    GuildesExercice3.Demo();
                    break;
                case "5":
                    PotionsExercice4.Demo();
                    break;
                // case "6":
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
