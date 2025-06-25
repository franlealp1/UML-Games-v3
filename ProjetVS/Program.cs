using System;
using UMLGames.Examples.Chapitre2; // Namespace trouvé dans Exemple1.cs
using CoursUML; // Namespace pour les solutions des exercices

namespace CoursUML
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuer = true;
            
            while (continuer)
            {
                Console.WriteLine("\n=== Menu de démonstration des exemples UML ===");
                // Exemples d'abord
                Console.WriteLine("1. Chapitre 2 - Exemple 1 : Personnage et Véhicule");
                Console.WriteLine("2. Chapitre 2 - Exemple 2 : Joueur et Scores");
                Console.WriteLine("3. Chapitre 2 - Exemple 3 : Joueur et Armes (many-to-many)");
                Console.WriteLine("4. Chapitre 2 - Exemple 5 : Joueur et Système de Santé (1 à 1)");
                Console.WriteLine("5. Chapitre 2 - Exemple 6 : Conteneurs imbriqués (relation réflexive)");
                Console.WriteLine("6. Chapitre 2 - Exemple 7 : Hiérarchie militaire (relation réflexive)");
                Console.WriteLine("7. Chapitre 2 - Exemple 4 : Système de Compétences et Personnages");
                // Puis exercices
                Console.WriteLine("8. Chapitre 2 - Exercice 2 : Système d'Athlétisme");
                Console.WriteLine("9. Chapitre 2 - Exercice 3 : Système de Guildes et Membres");
                Console.WriteLine("10. Chapitre 2 - Exercice 4 : Système de Potions dans The Witcher");
                // Console.WriteLine("7. Chapitre 3 - Exemple 1 : ...");
                // Ajoute ici les autres chapitres et exemples
                Console.WriteLine("0. Quitter");
                Console.Write("Choisissez un exemple à lancer : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    // Exemples d'abord
                    case "1":
                        CharacterExemple1.Demo();
                        break;
                    case "2":
                        Exemple2.Demo();
                        break;
                    case "3":
                        Example3Demo.Demo();
                        break;
                    case "4":
                        Example5Demo.Demo();
                        break;
                    case "5":
                        Example6Demo.Demo();
                        break;
                    case "6":
                        Example7Demo.Demo();
                        break;
                    case "7":
                        Example4Demo.Demo();
                        break;
                    // Puis exercices
                    case "8":
                        AthlétismeExercice2.Demo();
                        break;
                    case "9":
                        GuildesExercice3.Demo();
                        break;
                    case "10":
                        PotionsExercice4.Demo();
                        break;
                    // case "7":
                    //     Chapitre3Exemple1.Demo();
                    //     break;
                    case "0":
                        Console.WriteLine("Au revoir !");
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix non reconnu.");
                        break;
                }
                
                if (continuer)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    Console.Clear(); // Efface la console pour une meilleure lisibilité
                }
            }
        }
    }
}
