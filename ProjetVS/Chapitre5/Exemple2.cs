using System;
using System.Collections.Generic;

namespace UMLGames.Examples.Chapitre5.Exemple2
{
    /// <summary>
    /// Interface définissant le comportement d'un ennemi
    /// </summary>
    public interface IEnnemi
    {
        void Attaquer();
        void RecevoirDegats(int degats);
        bool EstHostile();
    }

    /// <summary>
    /// Interface définissant le comportement d'un allié
    /// </summary>
    public interface IAllie
    {
        void Aider();
        void Soigner();
        bool EstAmical();
    }

    /// <summary>
    /// Interface définissant le comportement d'un marchand
    /// </summary>
    public interface IMarchand
    {
        void Vendre(Item item);
        void Acheter(Item item);
        List<Item> GetInventaire();
    }

    /// <summary>
    /// Interface définissant le comportement d'un donneur de quêtes
    /// </summary>
    public interface IQueteur
    {
        void DonnerQuete(Quete quete);
        void ValiderQuete(Quete quete);
        List<Quete> GetQuetesDisponibles();
    }

    /// <summary>
    /// Interface définissant le comportement d'un artisan
    /// </summary>
    public interface IArtisan
    {
        void CreerObjet(Recette recette);
        List<Recette> GetRecettes();
    }

    /// <summary>
    /// Classe abstraite de base pour tous les NPCs
    /// </summary>
    public abstract class NPCBase
    {
        // Champs privés avec préfixe _
        private string _nom;
        private int _niveau;
        // ===== IMPLÉMENTATION DE LA RELATION D'HÉRITAGE =====
        // Cette classe abstraite définit les propriétés communes à tous les NPCs
        // Les classes dérivées (Gobelin, Orc, Humain) héritent de ces propriétés
        // La relation d'héritage est représentée par <|-- en UML

        /// <summary>
        /// Constructeur de la classe abstraite NPCBase
        /// </summary>
        /// <param name="nom">Nom du NPC</param>
        /// <param name="niveau">Niveau du NPC</param>
        protected NPCBase(string nom, int niveau)
        {
            _nom = nom;
            _niveau = niveau;
        }

        // Propriétés publiques
        public string Nom => _nom;
        public int Niveau => _niveau;

        /// <summary>
        /// Méthode concrète commune à tous les NPCs
        /// </summary>
        public void Parler()
        {
            Console.WriteLine($"{_nom} parle...");
        }

        /// <summary>
        /// Méthode abstraite que toutes les classes dérivées doivent implémenter
        /// </summary>
        public abstract void Agir();
    }

    /// <summary>
    /// Classe représentant un Gobelin avec multiples rôles
    /// Hérite de NPCBase et implémente plusieurs interfaces
    /// </summary>
    public class Gobelin : NPCBase, IEnnemi, IAllie, IMarchand, IQueteur
    {
        // Champs privés spécifiques au Gobelin
        private int _or;
        private int _experience;
        // ===== IMPLÉMENTATION DES RELATIONS D'HÉRITAGE ET D'INTERFACES =====
        // Le Gobelin hérite de NPCBase (relation d'héritage <|--)
        // ET implémente 4 interfaces différentes (relation d'implémentation <|..)
        // Cela permet la réutilisation du code et la flexibilité des rôles
        private bool _estAmical;
        private List<Item> _inventaire;
        private List<Quete> _quetesDisponibles;

        /// <summary>
        /// Constructeur de la classe Gobelin
        /// </summary>
        /// <param name="nom">Nom du gobelin</param>
        /// <param name="niveau">Niveau du gobelin</param>
        /// <param name="or">Or initial</param>
        public Gobelin(string nom, int niveau, int or) : base(nom, niveau)
        {
            _or = or;
            _experience = 0;
            _estAmical = false;
            _inventaire = new List<Item>();
            _quetesDisponibles = new List<Quete>();
        }

        // ===== IMPLÉMENTATION DE LA MÉTHODE ABSTRAITE =====
        /// <summary>
        /// Implémentation de la méthode abstraite Agir()
        /// </summary>
        public override void Agir()
        {
            if (_estAmical)
            {
                Console.WriteLine($"{Nom} agit de manière amicale.");
            }
            else
            {
                Console.WriteLine($"{Nom} agit de manière hostile.");
            }
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IENNEMI =====
        public void Attaquer()
        {
            if (!_estAmical)
            {
                Console.WriteLine($"{Nom} attaque férocement !");
                _experience += 10;
            }
        }

        public void RecevoirDegats(int degats)
        {
            Console.WriteLine($"{Nom} reçoit {degats} dégâts.");
        }

        public bool EstHostile()
        {
            return !_estAmical;
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IALLIE =====
        public void Aider()
        {
            if (_estAmical)
            {
                Console.WriteLine($"{Nom} aide activement !");
                _experience += 5;
            }
        }

        public void Soigner()
        {
            if (_estAmical)
            {
                Console.WriteLine($"{Nom} soigne avec ses connaissances !");
                _experience += 8;
            }
        }

        public bool EstAmical()
        {
            return _estAmical;
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IMARCHAND =====
        public void Vendre(Item item)
        {
            if (_inventaire.Contains(item))
            {
                _inventaire.Remove(item);
                _or += item.Prix;
                Console.WriteLine($"{Nom} vend {item.Nom} pour {item.Prix} or.");
            }
        }

        public void Acheter(Item item)
        {
            if (_or >= item.Prix)
            {
                _or -= item.Prix;
                _inventaire.Add(item);
                Console.WriteLine($"{Nom} achète {item.Nom} pour {item.Prix} or.");
            }
        }

        public List<Item> GetInventaire()
        {
            return new List<Item>(_inventaire);
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IQUETEUR =====
        public void DonnerQuete(Quete quete)
        {
            if (_quetesDisponibles.Contains(quete))
            {
                Console.WriteLine($"{Nom} donne la quête : {quete.Nom}");
            }
        }

        public void ValiderQuete(Quete quete)
        {
            Console.WriteLine($"{Nom} valide la quête : {quete.Nom}");
            _experience += quete.Experience;
        }

        public List<Quete> GetQuetesDisponibles()
        {
            return new List<Quete>(_quetesDisponibles);
        }

        // ===== MÉTHODES SPÉCIFIQUES AU GOBELIN =====
        public void ChangerRole(bool devenirAmical)
        {
            _estAmical = devenirAmical;
            string nouveauRole = devenirAmical ? "amical" : "hostile";
            Console.WriteLine($"{Nom} change de rôle et devient {nouveauRole} !");
        }

        public void AjouterQuete(Quete quete)
        {
            _quetesDisponibles.Add(quete);
            Console.WriteLine($"Quête '{quete.Nom}' ajoutée aux quêtes disponibles de {Nom}.");
        }
    }

    /// <summary>
    /// Classe représentant un Orc (ennemi uniquement)
    /// Hérite de NPCBase et implémente seulement IEnnemi
    /// </summary>
    public class Orc : NPCBase, IEnnemi
    {
        // Champs privés spécifiques à l'Orc
        private int _pointsDeVie;
        private int _force;
        // ===== IMPLÉMENTATION DE LA RELATION D'HÉRITAGE ET D'INTERFACE =====
        // L'Orc hérite de NPCBase et implémente seulement IEnnemi
        // Il a un rôle unique et spécialisé

        /// <summary>
        /// Constructeur de la classe Orc
        /// </summary>
        /// <param name="nom">Nom de l'orc</param>
        /// <param name="niveau">Niveau de l'orc</param>
        /// <param name="pointsDeVie">Points de vie initiaux</param>
        /// <param name="force">Force de l'orc</param>
        public Orc(string nom, int niveau, int pointsDeVie, int force) : base(nom, niveau)
        {
            _pointsDeVie = pointsDeVie;
            _force = force;
        }

        // ===== IMPLÉMENTATION DE LA MÉTHODE ABSTRAITE =====
        public override void Agir()
        {
            Console.WriteLine($"{Nom} agit de manière agressive avec sa force de {_force}.");
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IENNEMI =====
        public void Attaquer()
        {
            Console.WriteLine($"{Nom} attaque avec une force de {_force} !");
        }

        public void RecevoirDegats(int degats)
        {
            _pointsDeVie -= degats;
            Console.WriteLine($"{Nom} reçoit {degats} dégâts. PV restants : {_pointsDeVie}");
        }

        public bool EstHostile()
        {
            return true; // Les orcs sont toujours hostiles
        }
    }

    /// <summary>
    /// Classe représentant un Humain (marchand et artisan)
    /// Hérite de NPCBase et implémente IMarchand et IArtisan
    /// </summary>
    public class Humain : NPCBase, IMarchand, IArtisan
    {
        // Champs privés spécifiques à l'Humain
        private int _or;
        private int _reputation;
        // ===== IMPLÉMENTATION DE LA RELATION D'HÉRITAGE ET D'INTERFACES =====
        // L'Humain hérite de NPCBase et implémente IMarchand et IArtisan
        // Il a des rôles spécialisés dans le commerce et l'artisanat
        private List<Item> _inventaire;
        private List<Recette> _recettes;

        /// <summary>
        /// Constructeur de la classe Humain
        /// </summary>
        /// <param name="nom">Nom de l'humain</param>
        /// <param name="niveau">Niveau de l'humain</param>
        /// <param name="or">Or initial</param>
        /// <param name="reputation">Réputation initiale</param>
        public Humain(string nom, int niveau, int or, int reputation) : base(nom, niveau)
        {
            _or = or;
            _reputation = reputation;
            _inventaire = new List<Item>();
            _recettes = new List<Recette>();
        }

        // ===== IMPLÉMENTATION DE LA MÉTHODE ABSTRAITE =====
        public override void Agir()
        {
            Console.WriteLine($"{Nom} agit de manière civilisée avec une réputation de {_reputation}.");
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IMARCHAND =====
        public void Vendre(Item item)
        {
            if (_inventaire.Contains(item))
            {
                _inventaire.Remove(item);
                _or += item.Prix;
                _reputation += 1;
                Console.WriteLine($"{Nom} vend {item.Nom} pour {item.Prix} or. Réputation : {_reputation}");
            }
        }

        public void Acheter(Item item)
        {
            if (_or >= item.Prix)
            {
                _or -= item.Prix;
                _inventaire.Add(item);
                Console.WriteLine($"{Nom} achète {item.Nom} pour {item.Prix} or.");
            }
        }

        public List<Item> GetInventaire()
        {
            return new List<Item>(_inventaire);
        }

        // ===== IMPLÉMENTATION DE L'INTERFACE IARTISAN =====
        public void CreerObjet(Recette recette)
        {
            if (_recettes.Contains(recette))
            {
                Console.WriteLine($"{Nom} crée un objet avec la recette : {recette.Nom}");
                _reputation += 2;
            }
        }

        public List<Recette> GetRecettes()
        {
            return new List<Recette>(_recettes);
        }

        // ===== MÉTHODES SPÉCIFIQUES À L'HUMAIN =====
        public void AjouterRecette(Recette recette)
        {
            _recettes.Add(recette);
            Console.WriteLine($"Recette '{recette.Nom}' ajoutée aux connaissances de {Nom}.");
        }
    }

    /// <summary>
    /// Classe représentant une quête
    /// </summary>
    public class Quete
    {
        private string _nom;
        private int _experience;

        public string Nom => _nom;
        public int Experience => _experience;

        public Quete(string nom, int experience)
        {
            _nom = nom;
            _experience = experience;
        }
    }

    /// <summary>
    /// Classe représentant une recette d'artisanat
    /// </summary>
    public class Recette
    {
        private string _nom;
        private string _description;

        public string Nom => _nom;
        public string Description => _description;

        public Recette(string nom, string description)
        {
            _nom = nom;
            _description = description;
        }
    }

    /// <summary>
    /// Classe représentant un objet simple
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
    /// Classe de démonstration pour tester l'héritage et les interfaces multiples
    /// </summary>
    public static class Example2Demo
    {
        public static void Demo()
        {
            Console.WriteLine("=== Démonstration Chapitre 5 - Exemple 2 : Héritage et Interfaces Multiples ===\n");

            // Création des NPCs
            Gobelin gobelin = new Gobelin("Grik", 5, 50);
            Orc orc = new Orc("Grom", 8, 150, 25);
            Humain humain = new Humain("Marcus", 10, 100, 50);

            // Création d'objets et quêtes
            Item epee = new Item("Épée", 30);
            Quete queteGobelin = new Quete("Récupérer des champignons", 50);
            Recette recetteHumain = new Recette("Épée en fer", "Forge une épée en fer");

            // ===== DÉMONSTRATION DE L'HÉRITAGE =====
            Console.WriteLine("--- Héritage de NPCBase ---");
            gobelin.Parler(); // Méthode héritée
            orc.Parler();     // Méthode héritée
            humain.Parler();  // Méthode héritée

            gobelin.Agir();   // Méthode abstraite implémentée
            orc.Agir();       // Méthode abstraite implémentée
            humain.Agir();    // Méthode abstraite implémentée

            // ===== DÉMONSTRATION DES INTERFACES MULTIPLES =====
            Console.WriteLine("\n--- Interfaces Multiples ---");

            // Gobelin : 4 rôles différents
            Console.WriteLine("Gobelin (4 rôles) :");
            gobelin.Attaquer(); // IEnnemi
            gobelin.ChangerRole(true);
            gobelin.Aider();    // IAllie
            gobelin.Acheter(epee); // IMarchand
            gobelin.AjouterQuete(queteGobelin);
            gobelin.DonnerQuete(queteGobelin); // IQueteur

            // Orc : rôle d'ennemi uniquement
            Console.WriteLine("\nOrc (rôle ennemi uniquement) :");
            orc.Attaquer(); // IEnnemi seulement

            // Humain : rôles de marchand et artisan
            Console.WriteLine("\nHumain (rôles marchand et artisan) :");
            humain.Acheter(epee); // IMarchand
            humain.AjouterRecette(recetteHumain);
            humain.CreerObjet(recetteHumain); // IArtisan

            // ===== DÉMONSTRATION DE LA FLEXIBILITÉ =====
            Console.WriteLine("\n--- Flexibilité des Rôles ---");
            Console.WriteLine($"Gobelin peut être traité comme :");
            Console.WriteLine($"- NPCBase : {gobelin.Nom} (niveau {gobelin.Niveau})");
            Console.WriteLine($"- IEnnemi : Est hostile = {gobelin.EstHostile()}");
            Console.WriteLine($"- IAllie : Est amical = {gobelin.EstAmical()}");
            Console.WriteLine($"- IMarchand : Inventaire = {gobelin.GetInventaire().Count} objets");
            Console.WriteLine($"- IQueteur : Quêtes disponibles = {gobelin.GetQuetesDisponibles().Count}");
        }
    }
} 