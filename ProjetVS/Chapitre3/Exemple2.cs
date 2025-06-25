using System;
using System.Collections.Generic;
using System.Linq;

namespace UMLGames.Examples.Chapitre3.Exemple2
{
    /// <summary>
    /// Classe représentant un niveau de jeu qui contient des plateformes (relation de composition)
    /// </summary>
    public class GameLevel
    {
        // Exemple illustrant la composition (◆) :
        // En UML, la composition implique que la destruction du container entraîne la destruction automatique du contenu.
        // En C#, la composition est conceptuelle : seuls les liens (références) sont supprimés, les objets créés en dehors continuent d'exister tant qu'ils sont référencés ailleurs.
        // Une implémentation stricte de la composition (destruction automatique) n'est pas naturelle en C# à cause du garbage collector et du modèle de gestion mémoire.
        // On privilégie donc la cohérence logique et la documentation pour exprimer l'intention de composition.
        // Voir la démo pour une explication détaillée.

        // Champs privés avec préfixe _
        private string _name;
        private int _difficulty;
        // ===== IMPLÉMENTATION DE LA RELATION DE COMPOSITION =====
        // Un niveau de jeu contient plusieurs plateformes (composition)
        // Les plateformes n'existent que dans le contexte du niveau
        // Si le niveau est supprimé, toutes les plateformes sont également supprimées
        private List<Platform> _platforms;

        /// <summary>
        /// Constructeur de la classe GameLevel
        /// </summary>
        /// <param name="name">Nom du niveau</param>
        /// <param name="difficulty">Difficulté du niveau</param>
        public GameLevel(string name, int difficulty)
        {
            _name = name;
            _difficulty = difficulty;
            // ===== INITIALISATION DE LA RELATION DE COMPOSITION =====
            // Initialisation de la liste des plateformes (relation de composition)
            _platforms = new List<Platform>();
        }

        // Propriétés publiques
        public string Name => _name;
        public int Difficulty => _difficulty;
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION DE COMPOSITION =====
        // Cette propriété permet d'accéder à toutes les plateformes du niveau
        // Les plateformes n'existent que dans le contexte de ce niveau
        public IReadOnlyList<Platform> Platforms => _platforms.AsReadOnly();

        /// <summary>
        /// Ajoute une plateforme au niveau
        /// </summary>
        /// <param name="platform">Plateforme à ajouter</param>
        public void AddPlatform(Platform platform)
        {
            // ===== GESTION DE LA RELATION DE COMPOSITION =====
            // Vérification que la plateforme n'est pas null
            // La plateforme devient partie intégrante du niveau
            if (platform != null && !_platforms.Contains(platform))
            {
                _platforms.Add(platform);
                Console.WriteLine($"Plateforme ajoutée au niveau {_name} à la position ({platform.X}, {platform.Y}).");
            }
            else
            {
                Console.WriteLine($"Impossible d'ajouter la plateforme au niveau {_name} (plateforme invalide ou déjà présente).");
            }
        }

        /// <summary>
        /// Retire une plateforme du niveau
        /// </summary>
        /// <param name="platform">Plateforme à retirer</param>
        public void RemovePlatform(Platform platform)
        {
            // ===== SUPPRESSION DE LA RELATION DE COMPOSITION =====
            // La plateforme est retirée du niveau mais peut être réutilisée ailleurs
            if (platform != null && _platforms.Contains(platform))
            {
                _platforms.Remove(platform);
                Console.WriteLine($"Plateforme retirée du niveau {_name}.");
            }
            else
            {
                Console.WriteLine($"La plateforme n'est pas dans le niveau {_name}.");
            }
        }

        /// <summary>
        /// Retourne toutes les plateformes du niveau
        /// </summary>
        /// <returns>Liste des plateformes</returns>
        public List<Platform> GetPlatforms()
        {
            // ===== ACCÈS À LA RELATION DE COMPOSITION =====
            // Retourne une copie de la liste pour protéger la composition
            return new List<Platform>(_platforms);
        }

        /// <summary>
        /// Affiche les informations du niveau et de ses plateformes
        /// </summary>
        public void DisplayLevelInfo()
        {
            Console.WriteLine($"\nNiveau : {_name} (Difficulté : {_difficulty})");
            Console.WriteLine($"Nombre de plateformes : {_platforms.Count}");
            
            if (_platforms.Count == 0)
            {
                Console.WriteLine("Aucune plateforme dans ce niveau.");
            }
            else
            {
                // ===== PARCOURS DE LA RELATION DE COMPOSITION =====
                // Parcours de toutes les plateformes composant ce niveau
                Console.WriteLine("Plateformes :");
                foreach (var platform in _platforms)
                {
                    Console.WriteLine($"- Position: ({platform.X}, {platform.Y}), Taille: {platform.Width}x1");
                }
            }
        }

        /// <summary>
        /// Supprime le niveau et toutes ses plateformes
        /// </summary>
        public void DestroyLevel()
        {
            // ===== DESTRUCTION DE LA RELATION DE COMPOSITION =====
            // Quand le niveau est détruit, toutes ses plateformes sont également détruites
            Console.WriteLine($"Destruction du niveau {_name} et de ses {_platforms.Count} plateformes...");
            _platforms.Clear();
            Console.WriteLine("Niveau et toutes ses plateformes ont été supprimés.");
        }
    }

    /// <summary>
    /// Classe représentant une plateforme dans un niveau de jeu
    /// </summary>
    public class Platform
    {
        // Champs privés avec préfixe _
        private int _x;
        private int _y;
        private int _width;

        /// <summary>
        /// Constructeur de la classe Platform
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        /// <param name="width">Largeur de la plateforme</param>
        public Platform(int x, int y, int width)
        {
            _x = x;
            _y = y;
            _width = width;
        }

        // Propriétés publiques
        public int X => _x;
        public int Y => _y;
        public int Width => _width;

        /// <summary>
        /// Retourne la position de la plateforme
        /// </summary>
        /// <returns>Position sous forme de tuple (X, Y)</returns>
        public (int x, int y) GetPosition()
        {
            return (_x, _y);
        }

        /// <summary>
        /// Retourne la taille de la plateforme
        /// </summary>
        /// <returns>Taille sous forme de tuple (largeur, hauteur)</returns>
        public (int width, int height) GetSize()
        {
            return (_width, 1); // Hauteur fixe de 1 pour les plateformes
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester la relation de composition entre GameLevel et Platform
    /// </summary>
    public static class Example2Demo
    {
        public static void Demo()
        {
            Console.WriteLine("=== Démonstration Chapitre 3 - Exemple 2 : Niveau de Jeu et Plateformes (Composition) ===\n");

            // Création d'un niveau de jeu
            GameLevel level1 = new GameLevel("Niveau 1-1", 1);

            // Création de plateformes pour ce niveau
            Platform ground = new Platform(0, 10, 20);
            Platform platform1 = new Platform(5, 7, 3);
            Platform platform2 = new Platform(12, 5, 2);

            // Ajout des plateformes au niveau
            level1.AddPlatform(ground);
            level1.AddPlatform(platform1);
            level1.AddPlatform(platform2);

            // Affichage des informations du niveau
            level1.DisplayLevelInfo();

            // Test de récupération des plateformes
            var platforms = level1.GetPlatforms();
            Console.WriteLine($"\nRécupération de {platforms.Count} plateformes du niveau.");

            // ===== LIMITATION PRATIQUE DE LA COMPOSITION EN C# =====
            Console.WriteLine("\n=== IMPORTANT : Limitation pratique de la composition ===");
            Console.WriteLine("En C#, la composition est principalement conceptuelle :");
            Console.WriteLine("- Les objets Platform créés en dehors du GameLevel continuent d'exister");
            Console.WriteLine("- Seules les références dans la liste sont supprimées");
            Console.WriteLine("- Une implémentation plus stricte nécessiterait :");
            Console.WriteLine("  * Des destructeurs personnalisés");
            Console.WriteLine("  * Une gestion manuelle de la mémoire");
            Console.WriteLine("  * Un couplage très fort entre les classes");
            Console.WriteLine("  * Des interfaces IDisposable complexes");
            Console.WriteLine("- Cela rendrait le code moins flexible et plus difficile à maintenir");
            Console.WriteLine("- En pratique, on se contente de la composition logique/conceptuelle");

            // Test de destruction du niveau (composition)
            level1.DestroyLevel();

            // Vérification que les plateformes ont été supprimées avec le niveau
            Console.WriteLine($"\nAprès destruction, le niveau contient {level1.Platforms.Count} plateformes.");

            // ===== DÉMONSTRATION DE LA LIMITATION =====
            Console.WriteLine("\n=== Démonstration de la limitation ===");
            Console.WriteLine($"Les objets Platform existent toujours :");
            Console.WriteLine($"- ground: position ({ground.X}, {ground.Y})");
            Console.WriteLine($"- platform1: position ({platform1.X}, {platform1.Y})");
            Console.WriteLine($"- platform2: position ({platform2.X}, {platform2.Y})");
            Console.WriteLine("En composition stricte, ces objets seraient détruits automatiquement.");
            Console.WriteLine("En C#, on se contente de la composition logique (suppression des références).");
        }
    }
} 