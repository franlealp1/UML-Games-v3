using System;
using System.Collections.Generic;
using System.Linq;

namespace UMLGames.Examples.Chapitre3
{
    /// <summary>
    /// Classe représentant un inventaire qui peut contenir des objets (relation d'agrégation)
    /// </summary>
    public class Inventory
    {
        // Champs privés avec préfixe _
        private string _name;
        private int _maxCapacity;
        // ===== IMPLÉMENTATION DE LA RELATION D'AGRÉGATION =====
        // Un inventaire peut contenir plusieurs objets (agrégation)
        // Les objets peuvent exister indépendamment de l'inventaire
        // Si l'inventaire est supprimé, les objets peuvent être transférés ailleurs
        private List<Item> _items;

        /// <summary>
        /// Constructeur de la classe Inventory
        /// </summary>
        /// <param name="name">Nom de l'inventaire</param>
        /// <param name="maxCapacity">Capacité maximale</param>
        public Inventory(string name, int maxCapacity)
        {
            _name = name;
            _maxCapacity = maxCapacity;
            // ===== INITIALISATION DE LA RELATION D'AGRÉGATION =====
            // Initialisation de la liste des objets (relation d'agrégation)
            _items = new List<Item>();
        }

        // Propriétés publiques
        public string Name => _name;
        public int MaxCapacity => _maxCapacity;
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION D'AGRÉGATION =====
        // Cette propriété permet d'accéder à tous les objets de l'inventaire
        // Les objets peuvent exister indépendamment de cet inventaire
        public IReadOnlyList<Item> Items => _items.AsReadOnly();

        /// <summary>
        /// Ajoute un objet à l'inventaire
        /// </summary>
        /// <param name="item">Objet à ajouter</param>
        public void AddItem(Item item)
        {
            // ===== GESTION DE LA RELATION D'AGRÉGATION =====
            // Vérification que l'objet n'est pas null et qu'il y a de la place
            if (item != null && _items.Count < _maxCapacity)
            {
                _items.Add(item);
                Console.WriteLine($"{item.Name} ajouté à l'inventaire {_name}.");
            }
            else
            {
                Console.WriteLine($"Impossible d'ajouter {item?.Name} à {_name} (inventaire plein ou objet invalide).");
            }
        }

        /// <summary>
        /// Retire un objet de l'inventaire
        /// </summary>
        /// <param name="item">Objet à retirer</param>
        public void RemoveItem(Item item)
        {
            // ===== SUPPRESSION DE LA RELATION D'AGRÉGATION =====
            // L'objet continue d'exister après avoir été retiré de l'inventaire
            if (item != null && _items.Contains(item))
            {
                _items.Remove(item);
                Console.WriteLine($"{item.Name} retiré de l'inventaire {_name}.");
            }
            else
            {
                Console.WriteLine($"{item?.Name} n'est pas dans l'inventaire {_name}.");
            }
        }

        /// <summary>
        /// Transfère tous les objets vers un autre inventaire
        /// </summary>
        /// <param name="targetInventory">Inventaire de destination</param>
        public void TransferAllItems(Inventory targetInventory)
        {
            // ===== TRANSFERT DE LA RELATION D'AGRÉGATION =====
            // Les objets sont transférés d'un inventaire à l'autre
            // Ils continuent d'exister indépendamment des inventaires
            if (targetInventory != null)
            {
                var itemsToTransfer = new List<Item>(_items);
                foreach (var item in itemsToTransfer)
                {
                    RemoveItem(item);
                    targetInventory.AddItem(item);
                }
                Console.WriteLine($"Tous les objets de {_name} ont été transférés vers {targetInventory.Name}.");
            }
        }

        /// <summary>
        /// Affiche le contenu de l'inventaire
        /// </summary>
        public void DisplayContents()
        {
            Console.WriteLine($"\nContenu de l'inventaire {_name} ({_items.Count}/{_maxCapacity}) :");
            if (_items.Count == 0)
            {
                Console.WriteLine("Inventaire vide.");
            }
            else
            {
                // ===== PARCOURS DE LA RELATION D'AGRÉGATION =====
                // Parcours de tous les objets contenus dans l'inventaire
                foreach (var item in _items)
                {
                    Console.WriteLine($"- {item.Name} (Quantité: {item.Quantity})");
                }
            }
        }
    }

    /// <summary>
    /// Classe représentant un objet qui peut être stocké dans un inventaire
    /// </summary>
    public class Item
    {
        // Champs privés avec préfixe _
        private string _name;
        private int _quantity;

        /// <summary>
        /// Constructeur de la classe Item
        /// </summary>
        /// <param name="name">Nom de l'objet</param>
        /// <param name="quantity">Quantité</param>
        public Item(string name, int quantity)
        {
            _name = name;
            _quantity = quantity;
        }

        // Propriétés publiques
        public string Name => _name;
        public int Quantity => _quantity;

        /// <summary>
        /// Utilise l'objet (diminue la quantité)
        /// </summary>
        public void Use()
        {
            if (_quantity > 0)
            {
                _quantity--;
                Console.WriteLine($"{_name} utilisé. Quantité restante : {_quantity}");
            }
            else
            {
                Console.WriteLine($"{_name} n'est plus disponible.");
            }
        }

        /// <summary>
        /// Retourne le nom de l'objet
        /// </summary>
        /// <returns>Nom de l'objet</returns>
        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// Retourne la quantité de l'objet
        /// </summary>
        /// <returns>Quantité</returns>
        public int GetQuantity()
        {
            return _quantity;
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester la relation d'agrégation entre Inventory et Item
    /// </summary>
    public static class Example1Demo
    {
        public static void Demo()
        {
            Console.WriteLine("=== Démonstration Chapitre 3 - Exemple 1 : Inventaire et Objets (Agrégation) ===\n");

            // Création d'objets (ils existent indépendamment des inventaires)
            Item diamond = new Item("Diamant", 5);
            Item iron = new Item("Fer", 10);
            Item coal = new Item("Charbon", 20);

            // Création d'inventaires
            Inventory playerInventory = new Inventory("Inventaire du joueur", 10);
            Inventory chestInventory = new Inventory("Coffre", 15);

            // Ajout d'objets dans l'inventaire du joueur
            playerInventory.AddItem(diamond);
            playerInventory.AddItem(iron);
            playerInventory.AddItem(coal);

            // Affichage du contenu
            playerInventory.DisplayContents();

            // Utilisation d'un objet
            diamond.Use();

            // Transfert d'objets vers le coffre
            playerInventory.TransferAllItems(chestInventory);

            // Vérification que les objets existent toujours
            Console.WriteLine($"\nL'objet {diamond.GetName()} existe toujours avec {diamond.GetQuantity()} unités.");

            // Affichage du contenu du coffre
            chestInventory.DisplayContents();
        }
    }
} 