using System;
using System.Collections.Generic;

namespace UMLGames.Examples.Chapitre5.Exemple1
{
    /// <summary>
    /// Interface définissant le comportement d'un ennemi
    /// </summary>
    public interface IEnnemi
    {
        /// <summary>
        /// Attaque une cible
        /// </summary>
        void Attaquer();
        
        /// <summary>
        /// Reçoit des dégâts
        /// </summary>
        /// <param name="degats">Quantité de dégâts reçus</param>
        void RecevoirDegats(int degats);
        
        /// <summary>
        /// Indique si l'entité est hostile
        /// </summary>
        /// <returns>True si hostile</returns>
        bool EstHostile();
    }

    /// <summary>
    /// Interface définissant le comportement d'un allié
    /// </summary>
    public interface IAllie
    {
        /// <summary>
        /// Aide une cible
        /// </summary>
        void Aider();
        
        /// <summary>
        /// Soigne une cible
        /// </summary>
        void Soigner();
        
        /// <summary>
        /// Indique si l'entité est amicale
        /// </summary>
        /// <returns>True si amicale</returns>
        bool EstAmical();
    }

    /// <summary>
    /// Interface définissant le comportement d'un marchand
    /// </summary>
    public interface IMarchand
    {
        /// <summary>
        /// Vend un objet
        /// </summary>
        /// <param name="item">Objet à vendre</param>
        void Vendre(Item item);
        
        /// <summary>
        /// Achète un objet
        /// </summary>
        /// <param name="item">Objet à acheter</param>
        void Acheter(Item item);
        
        /// <summary>
        /// Retourne l'inventaire du marchand
        /// </summary>
        /// <returns>Liste des objets</returns>
        List<Item> GetInventaire();
    }

    /// <summary>
    /// Classe représentant un Gobelin qui peut avoir plusieurs rôles
    /// Implémente les interfaces IEnnemi, IAllie et IMarchand
    /// </summary>
    public class Gobelin : IEnnemi, IAllie, IMarchand
    {
        // Champs privés avec préfixe _
        private string _nom;
        private int _pointsDeVie;
        private int _or;
        private int _experience;
        // ===== IMPLÉMENTATION DES RELATIONS D'INTERFACES =====
        // Le Gobelin implémente plusieurs interfaces (IEnnemi, IAllie, IMarchand)
        // Cela lui permet d'avoir des rôles multiples sans duplication de code
        // La relation d'implémentation est représentée par <|.. en UML
        private bool _estAmical; // Détermine le rôle actuel
        private List<Item> _inventaire;

        /// <summary>
        /// Constructeur de la classe Gobelin
        /// </summary>
        /// <param name="nom">Nom du gobelin</param>
        /// <param name="pointsDeVie">Points de vie initiaux</param>
        /// <param name="or">Or initial</param>
        public Gobelin(string nom, int pointsDeVie, int or)
        {
            _nom = nom;
            _pointsDeVie = pointsDeVie;
            _or = or;
            _experience = 0;
            _estAmical = false; // Par défaut hostile
            // ===== INITIALISATION DES RELATIONS D'INTERFACES =====
            // Initialisation de l'inventaire pour l'interface IMarchand
            _inventaire = new List<Item>();
        }

        // Propriétés publiques
        public string Nom => _nom;
        public int PointsDeVie => _pointsDeVie;
        public int Or => _or;
        public int Experience => _experience;

        // ===== IMPLÉMENTATION DE L'INTERFACE IENNEMI =====
        /// <summary>
        /// Attaque une cible (comportement ennemi)
        /// </summary>
        public void Attaquer()
        {
            if (!_estAmical)
            {
                Console.WriteLine($"{_nom} attaque férocement !");
                _experience += 10;
            }
            else
            {
                Console.WriteLine($"{_nom} refuse d'attaquer car il est amical.");
            }
        }

        /// <summary>
        /// Reçoit des dégâts (comportement ennemi)
        /// </summary>
        /// <param name="degats">Quantité de dégâts reçus</param>
        public void RecevoirDegats(int degats)
        {
            _pointsDeVie -= degats;
            Console.WriteLine($"{_nom} reçoit {degats} dégâts. PV restants : {_pointsDeVie}");
            if (_pointsDeVie <= 0)
            {
                Console.WriteLine($"{_nom} est vaincu !");
            }
        }

        /// <summary>
        /// Indique si le gobelin est hostile (comportement ennemi)
        /// </summary>
        /// <returns>True si hostile</returns>
        public bool EstHostile()
        {
            return !_estAmical;
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IALLIE =====
        /// <summary>
        /// Aide une cible (comportement allié)
        /// </summary>
        public void Aider()
        {
            if (_estAmical)
            {
                Console.WriteLine($"{_nom} aide activement !");
                _experience += 5;
            }
            else
            {
                Console.WriteLine($"{_nom} refuse d'aider car il est hostile.");
            }
        }

        /// <summary>
        /// Soigne une cible (comportement allié)
        /// </summary>
        public void Soigner()
        {
            if (_estAmical)
            {
                Console.WriteLine($"{_nom} soigne avec ses connaissances !");
                _experience += 8;
            }
            else
            {
                Console.WriteLine($"{_nom} refuse de soigner car il est hostile.");
            }
        }

        /// <summary>
        /// Indique si le gobelin est amical (comportement allié)
        /// </summary>
        /// <returns>True si amical</returns>
        public bool EstAmical()
        {
            return _estAmical;
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IMARCHAND =====
        /// <summary>
        /// Vend un objet (comportement marchand)
        /// </summary>
        /// <param name="item">Objet à vendre</param>
        public void Vendre(Item item)
        {
            if (_inventaire.Contains(item))
            {
                _inventaire.Remove(item);
                _or += item.Prix;
                Console.WriteLine($"{_nom} vend {item.Nom} pour {item.Prix} or.");
            }
            else
            {
                Console.WriteLine($"{_nom} n'a pas {item.Nom} à vendre.");
            }
        }

        /// <summary>
        /// Achète un objet (comportement marchand)
        /// </summary>
        /// <param name="item">Objet à acheter</param>
        public void Acheter(Item item)
        {
            if (_or >= item.Prix)
            {
                _or -= item.Prix;
                _inventaire.Add(item);
                Console.WriteLine($"{_nom} achète {item.Nom} pour {item.Prix} or.");
            }
            else
            {
                Console.WriteLine($"{_nom} n'a pas assez d'or pour acheter {item.Nom}.");
            }
        }

        /// <summary>
        /// Retourne l'inventaire du marchand (comportement marchand)
        /// </summary>
        /// <returns>Liste des objets</returns>
        public List<Item> GetInventaire()
        {
            return new List<Item>(_inventaire);
        }

        // ===== MÉTHODES SPÉCIFIQUES AU GOBELIN =====
        /// <summary>
        /// Permet au gobelin de changer de rôle (hostile/amical)
        /// </summary>
        /// <param name="devenirAmical">True pour devenir amical, false pour devenir hostile</param>
        public void ChangerRole(bool devenirAmical)
        {
            _estAmical = devenirAmical;
            string nouveauRole = devenirAmical ? "amical" : "hostile";
            Console.WriteLine($"{_nom} change de rôle et devient {nouveauRole} !");
        }

        /// <summary>
        /// Affiche l'état actuel du gobelin
        /// </summary>
        public void AfficherEtat()
        {
            string role = _estAmical ? "Allié" : "Ennemi";
            Console.WriteLine($"\n=== État de {_nom} ===");
            Console.WriteLine($"Rôle : {role}");
            Console.WriteLine($"Points de vie : {_pointsDeVie}");
            Console.WriteLine($"Or : {_or}");
            Console.WriteLine($"Expérience : {_experience}");
            Console.WriteLine($"Objets dans l'inventaire : {_inventaire.Count}");
        }
    }

    /// <summary>
    /// Classe représentant un objet simple pour les transactions
    /// </summary>
    public class Item
    {
        private string _nom;
        private int _prix;

        public string Nom => _nom;
        public int Prix => _prix;

        public Item(string nom, int prix)
        {
            _nom = nom;
            _prix = prix;
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester les interfaces multiples du Gobelin
    /// </summary>
    public static class Example1Demo
    {
        public static void Demo()
        {
            Console.WriteLine("=== Démonstration Chapitre 5 - Exemple 1 : Gobelin avec Interfaces Multiples ===\n");

            // Création d'un gobelin
            Gobelin gobelin = new Gobelin("Grik", 100, 50);

            // Création d'objets pour les transactions
            Item epee = new Item("Épée rouillée", 20);
            Item potion = new Item("Potion de soin", 15);

            // ===== DÉMONSTRATION DU RÔLE ENNEMI =====
            Console.WriteLine("--- Rôle Ennemi ---");
            gobelin.AfficherEtat();
            gobelin.Attaquer();
            gobelin.RecevoirDegats(30);
            Console.WriteLine($"Est hostile : {gobelin.EstHostile()}");

            // ===== DÉMONSTRATION DU RÔLE MARCHAND =====
            Console.WriteLine("\n--- Rôle Marchand ---");
            gobelin.Acheter(epee);
            gobelin.Acheter(potion);
            var inventaire = gobelin.GetInventaire();
            Console.WriteLine($"Inventaire : {inventaire.Count} objets");
            gobelin.Vendre(epee);

            // ===== CHANGEMENT DE RÔLE =====
            Console.WriteLine("\n--- Changement de Rôle ---");
            gobelin.ChangerRole(true);

            // ===== DÉMONSTRATION DU RÔLE ALLIÉ =====
            Console.WriteLine("\n--- Rôle Allié ---");
            gobelin.Aider();
            gobelin.Soigner();
            Console.WriteLine($"Est amical : {gobelin.EstAmical()}");

            // ===== DÉMONSTRATION DE LA FLEXIBILITÉ =====
            Console.WriteLine("\n--- Flexibilité des Rôles ---");
            gobelin.Attaquer(); // Refuse car amical
            gobelin.ChangerRole(false);
            gobelin.Attaquer(); // Accepte car hostile
            gobelin.Aider(); // Refuse car hostile

            gobelin.AfficherEtat();
        }
    }
} 