using System;
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
                Console.WriteLine("8. Chapitre 3 - Exemple 1 : Inventaire et Objets (Agrégation)");
                Console.WriteLine("9. Chapitre 3 - Exemple 2 : Niveau de Jeu et Plateformes (Composition)");
                Console.WriteLine("10. Chapitre 5 - Exemple 1 : Interfaces - Gobelin Multi-Rôles");
                Console.WriteLine("11. Chapitre 5 - Exemple 2 : Héritage + Interfaces - NPCs Avancés");
                // Puis exercices
                Console.WriteLine("12. Chapitre 2 - Exercice 2 : Système d'Athlétisme");
                Console.WriteLine("13. Chapitre 2 - Exercice 3 : Système de Guildes et Membres");
                Console.WriteLine("14. Chapitre 2 - Exercice 4 : Système de Potions dans The Witcher");
                Console.WriteLine("15. Chapitre 3 - Exercice 1 : Système de Gestion d'Aéroline");
                // Console.WriteLine("7. Chapitre 3 - Exemple 1 : ...");
                // Ajoute ici les autres chapitres et exemples
                Console.WriteLine("0. Quitter");
                Console.Write("Choisissez un exemple à lancer : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    // Exemples d'abord
                    case "1":
                        UMLGames.Examples.Chapitre2.Exemple1.CharacterExemple1.Demo();
                        break;
                    case "2":
                        UMLGames.Examples.Chapitre2.Exemple2.Exemple2.Demo();
                        break;
                    case "3":
                        UMLGames.Examples.Chapitre2.Exemple3.Example3Demo.Demo();
                        break;
                    case "4":
                        UMLGames.Examples.Chapitre2.Exemple5.Example5Demo.Demo();
                        break;
                    case "5":
                        UMLGames.Examples.Chapitre2.Exemple6.Example6Demo.Demo();
                        break;
                    case "6":
                        UMLGames.Examples.Chapitre2.Exemple7.Example7Demo.Demo();
                        break;
                    case "7":
                        UMLGames.Examples.Chapitre2.Exemple4.Example4Demo.Demo();
                        break;
                    case "8":
                        UMLGames.Examples.Chapitre3.Exemple1.Example1Demo.Demo();
                        break;
                    case "9":
                        UMLGames.Examples.Chapitre3.Exemple2.Example2Demo.Demo();
                        break;
                    case "10":
                        UMLGames.Examples.Chapitre5.Exemple1.Example1Demo.Demo();
                        break;
                    case "11":
                        UMLGames.Examples.Chapitre5.Exemple2.Example2Demo.Demo();
                        break;
                    // Puis exercices
                    case "12":
                        CoursUML.AthlétismeExercice2.Demo();
                        break;
                    case "13":
                        CoursUML.GuildesExercice3.Demo();
                        break;
                    case "14":
                        CoursUML.PotionsExercice4.Demo();
                        break;
                    case "15":
                        CoursUML.Chapitre3.Exercice1.AerolineDemo.Demo();
                        break;
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
