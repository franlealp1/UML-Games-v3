using System;
using System.Collections.Generic;
using System.Linq;

namespace UMLGames.Examples.Chapitre2.Exemple6
{
    /// <summary>
    /// Classe représentant un conteneur pouvant contenir d'autres conteneurs ou des objets
    /// </summary>
    public class Container
    {
        // Champs privés
        private string _name;
        private int _maxCapacity;
        private int _currentWeight;
        // ===== IMPLÉMENTATION DE LA RELATION RÉFLEXIVE =====
        // Un conteneur peut contenir plusieurs sous-conteneurs (relation réflexive)
        // Un conteneur peut aussi avoir un conteneur parent (relation réflexive inverse)
        private List<Container> _subContainers; // sous-conteneurs
        private Container? _parentContainer;    // conteneur parent
        private List<GameItem> _items;              // objets contenus

        /// <summary>
        /// Constructeur de la classe Container
        /// </summary>
        /// <param name="name">Nom du conteneur</param>
        /// <param name="maxCapacity">Capacité maximale</param>
        public Container(string name, int maxCapacity)
        {
            _name = name;
            _maxCapacity = maxCapacity;
            _currentWeight = 0;
            _subContainers = new List<Container>();
            _parentContainer = null;
            _items = new List<GameItem>();
        }

        // Propriétés publiques
        public string Name => _name;
        public int MaxCapacity => _maxCapacity;
        public int CurrentWeight => _currentWeight;
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION RÉFLEXIVE =====
        // Cette propriété permet d'accéder à tous les sous-conteneurs
        public IReadOnlyList<Container> SubContainers => _subContainers.AsReadOnly();
        // Cette propriété permet d'accéder au conteneur parent
        public Container? ParentContainer => _parentContainer;
        // Objets contenus
        public IReadOnlyList<GameItem> Items => _items.AsReadOnly();

        /// <summary>
        /// Ajoute un objet dans le conteneur
        /// </summary>
        /// <param name="item">Objet à ajouter</param>
        public void AddItem(GameItem item)
        {
            if (item != null && _currentWeight + item.Weight <= _maxCapacity)
            {
                _items.Add(item);
                _currentWeight += item.Weight;
                Console.WriteLine($"{item.Name} ajouté à {_name}.");
            }
            else
            {
                Console.WriteLine($"Impossible d'ajouter {item?.Name} à {_name} (capacité dépassée).");
            }
        }

        /// <summary>
        /// Retire un objet du conteneur
        /// </summary>
        /// <param name="item">Objet à retirer</param>
        public void RemoveItem(GameItem item)
        {
            if (item != null && _items.Contains(item))
            {
                _items.Remove(item);
                _currentWeight -= item.Weight;
                Console.WriteLine($"{item.Name} retiré de {_name}.");
            }
        }

        /// <summary>
        /// Ajoute un sous-conteneur à ce conteneur (relation réflexive)
        /// </summary>
        /// <param name="container">Sous-conteneur à ajouter</param>
        public void AddSubContainer(Container container)
        {
            if (container != null && !_subContainers.Contains(container) && container != this)
            {
                _subContainers.Add(container);
                container._parentContainer = this;
                Console.WriteLine($"{container.Name} ajouté comme sous-conteneur de {_name}.");
            }
        }

        /// <summary>
        /// Retire un sous-conteneur
        /// </summary>
        /// <param name="container">Sous-conteneur à retirer</param>
        public void RemoveSubContainer(Container container)
        {
            if (container != null && _subContainers.Contains(container))
            {
                _subContainers.Remove(container);
                container._parentContainer = null;
                Console.WriteLine($"{container.Name} retiré de {_name}.");
            }
        }

        /// <summary>
        /// Retourne la liste de tous les objets contenus (récursivement)
        /// </summary>
        public List<GameItem> GetAllContents()
        {
            var all = new List<GameItem>(_items);
            foreach (var sub in _subContainers)
                all.AddRange(sub.GetAllContents());
            return all;
        }

        /// <summary>
        /// Affiche la structure du conteneur et de ses sous-conteneurs
        /// </summary>
        /// <param name="indent">Indentation pour l'affichage</param>
        public void PrintStructure(string indent = "")
        {
            Console.WriteLine($"{indent}- {_name} (Poids: {_currentWeight}/{_maxCapacity})");
            foreach (var item in _items)
                Console.WriteLine($"{indent}  * {item.Name} (Poids: {item.Weight})");
            foreach (var sub in _subContainers)
                sub.PrintStructure(indent + "  ");
        }
    }

    /// <summary>
    /// Classe représentant un objet simple (exemple)
    /// </summary>
    public class GameItem
    {
        private string _name;
        private int _weight;
        public string Name => _name;
        public int Weight => _weight;
        public GameItem(string name, int weight) { _name = name; _weight = weight; }
    }

    /// <summary>
    /// Classe de démonstration pour tester la structure de conteneurs imbriqués
    /// </summary>
    public static class Example6Demo
    {
        public static void Demo()
        {
            Console.WriteLine("--- Démonstration Exemple 6 : Conteneurs imbriqués (relation réflexive) ---");

            // Création de conteneurs
            Container backpack = new Container("Mochila", 50);
            Container box = new Container("Boîte", 20);
            Container bag = new Container("Sac", 10);

            // Création d'objets
            GameItem potion = new GameItem("Potion", 2);
            GameItem sword = new GameItem("Épée", 5);
            GameItem apple = new GameItem("Pomme", 1);

            // Ajout d'objets et de sous-conteneurs
            backpack.AddItem(potion);
            backpack.AddSubContainer(box);
            box.AddItem(sword);
            box.AddSubContainer(bag);
            bag.AddItem(apple);

            // Affichage de la structure imbriquée
            backpack.PrintStructure();
        }
    }
} 