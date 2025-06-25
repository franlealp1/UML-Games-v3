using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML
{
    // ===== IMPLÉMENTATION DU DIAGRAMME UML =====
    // Ce fichier implémente le diagramme UML du système de potions
    // avec les relations suivantes :
    // 1. Hiérarchie d'héritage : Ingredient (classe abstraite) -> Potion et RawIngredient
    // 2. Relation one-to-many entre Potion et AjoutIngredient
    // 3. Relation many-to-one entre AjoutIngredient et Ingredient
    /// <summary>
    /// Classe abstraite représentant un ingrédient
    /// </summary>
    // ===== CLASSE ABSTRAITE DE BASE =====
    // Cette classe sert de base pour tous les types d'ingrédients
    // Elle définit les propriétés et méthodes communes à tous les ingrédients
    public abstract class Ingredient
    {
        public string nom { get; set; } = "";
        public string description { get; set; } = "";

        public string GetInfo()
        {
            return $"{nom} - {description}";
        }
    }

    /// <summary>
    /// Classe représentant un ingrédient brut
    /// </summary>
    // ===== CLASSE DÉRIVÉE DE INGREDIENT =====
    // Cette classe hérite de Ingredient et ajoute des propriétés spécifiques
    // aux ingrédients bruts comme la source et la rareté
    public class RawIngredient : Ingredient
    {
        public string source { get; set; } = "";
        public int rarete { get; set; }

        public string GetSource()
        {
            return $"Source: {source}, Rareté: {rarete}";
        }
    }

    /// <summary>
    /// Classe représentant une potion qui hérite d'Ingredient
    /// </summary>
    // ===== CLASSE DÉRIVÉE DE INGREDIENT AVEC RELATION ONE-TO-MANY =====
    // Cette classe hérite de Ingredient et ajoute des propriétés spécifiques aux potions
    // Elle implémente également une relation one-to-many avec AjoutIngredient
    // Une potion peut contenir plusieurs AjoutIngredient (liste d'ingrédients)
    public class Potion : Ingredient
    {
        public string effet { get; set; } = "";
        public int complexite { get; set; }
        // ===== IMPLÉMENTATION DE LA RELATION ONE-TO-MANY =====
        // Une potion contient plusieurs ajouts d'ingrédients
        // Cette liste stocke tous les ingrédients de la potion avec leurs détails
        private List<AjoutIngredient> ingredients = new List<AjoutIngredient>();

        /// <summary>
        /// Ajoute un ingrédient à la potion
        /// </summary>
        /// <param name="ingredient">Ingrédient à ajouter (peut être une potion ou un ingrédient brut)</param>
        /// <param name="quantite">Quantité de l'ingrédient</param>
        /// <param name="ordre">Ordre d'ajout de l'ingrédient</param>
        // ===== GESTION DE LA RELATION ONE-TO-MANY =====
        // Cette méthode crée un nouvel AjoutIngredient et l'ajoute à la liste des ingrédients
        // Elle permet d'ajouter n'importe quel type d'Ingredient (Potion ou RawIngredient)
        public void AddIngredient(Ingredient ingredient, int quantite, int ordre)
        {
            // ===== CRÉATION DE LA CLASSE D'ASSOCIATION =====
            // Création d'un nouvel ajout d'ingrédient et ajout à la liste
            ingredients.Add(new AjoutIngredient 
            { 
                ingredient = ingredient, 
                quantite = quantite, 
                ordreAjout = ordre 
            });
        }

        /// <summary>
        /// Retourne la liste des ingrédients de la potion
        /// </summary>
        /// <returns>Liste des ajouts d'ingrédients</returns>
        // ===== ACCÈS À LA RELATION ONE-TO-MANY =====
        // Cette méthode permet d'accéder à tous les ingrédients de la potion
        public List<AjoutIngredient> GetIngredients()
        {
            return ingredients;
        }

        /// <summary>
        /// Vérifie si la potion peut être créée
        /// </summary>
        /// <returns>True si la potion peut être créée</returns>
        // ===== UTILISATION DE LA RELATION ONE-TO-MANY =====
        // Cette méthode utilise la relation pour vérifier si la potion a des ingrédients
        public bool CanBeCreated()
        {
            // Une potion peut être créée si elle a au moins un ingrédient
            return ingredients.Count > 0;
        }
    }

    /// <summary>
    /// Classe représentant l'ajout d'un ingrédient dans une potion
    /// </summary>
    // ===== CLASSE D'ASSOCIATION ENTRE POTION ET INGREDIENT =====
    // Cette classe représente l'association entre une potion et ses ingrédients
    // Elle contient les informations spécifiques à l'ajout d'un ingrédient dans une potion
    // comme la quantité et l'ordre d'ajout
    public class AjoutIngredient
    {
        // ===== RÉFÉRENCE VERS L'INGRÉDIENT =====
        // Cette propriété fait référence à l'ingrédient (Potion ou RawIngredient)
        public Ingredient ingredient { get; set; } = null!;
        
        // ===== DONNÉES SPÉCIFIQUES À L'AJOUT =====
        // Ces propriétés sont spécifiques à l'ajout d'un ingrédient dans une potion
        public int quantite { get; set; }  // Quantité de l'ingrédient
        public int ordreAjout { get; set; } // Ordre dans lequel ajouter l'ingrédient

        public AjoutIngredient() { }

        public AjoutIngredient(Ingredient ingredient, int quantite, int ordreAjout)
        {
            this.ingredient = ingredient;
            this.quantite = quantite;
            this.ordreAjout = ordreAjout;
        }

        public string GetDetails()
        {
            return $"{ingredient.nom} - Quantité: {quantite}, Ordre: {ordreAjout}";
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester le système de potions
    /// </summary>
    public static class PotionsExercice4
    {
        public static void Demo()
        {
            Console.WriteLine("=== Système de Potions ===\n");

            // ===== CRÉATION D'INSTANCES DE RAWINGREDIENT =====
            // Création d'ingrédients bruts (classe dérivée de Ingredient)
            var herbe = new RawIngredient 
            { 
                nom = "Herbe médicinale", 
                description = "Une herbe aux propriétés curatives", 
                source = "Forêt", 
                rarete = 2 
            };

            var champignon = new RawIngredient 
            { 
                nom = "Champignon lumineux", 
                description = "Un champignon qui brille dans le noir", 
                source = "Grotte", 
                rarete = 5 
            };

            var ecaille = new RawIngredient 
            { 
                nom = "Écaille de dragon", 
                description = "Une écaille résistante au feu", 
                source = "Dragon", 
                rarete = 8 
            };

            // ===== CRÉATION D'INSTANCES DE POTION =====
            // Création d'une potion simple (classe dérivée de Ingredient)
            var potionSoin = new Potion 
            { 
                nom = "Potion de soin", 
                description = "Restaure les points de vie", 
                effet = "Guérison", 
                complexite = 2 
            };

            // ===== CRÉATION DE LA RELATION ONE-TO-MANY =====
            // Ajout d'ingrédients bruts à la potion (création d'instances d'AjoutIngredient)
            potionSoin.AddIngredient(herbe, 3, 1);
            potionSoin.AddIngredient(champignon, 1, 2);

            // Création d'une potion avancée qui utilise une autre potion comme ingrédient
            var potionSoinSupreme = new Potion 
            { 
                nom = "Potion de soin suprême", 
                description = "Restaure tous les points de vie", 
                effet = "Guérison complète", 
                complexite = 5 
            };

            // ===== DÉMONSTRATION DE L'HÉRITAGE ET DE LA COMPOSITION =====
            // Ajout d'une potion comme ingrédient dans une autre potion
            // Ceci est possible car Potion hérite de Ingredient
            potionSoinSupreme.AddIngredient(potionSoin, 1, 1);
            potionSoinSupreme.AddIngredient(ecaille, 2, 2);

            // ===== DÉMONSTRATION DU POLYMORPHISME =====
            // Utilisation de la méthode GetInfo() définie dans la classe abstraite
            // et potentiellement redéfinie dans les classes dérivées
            Console.WriteLine("Ingrédients bruts:");
            Console.WriteLine(herbe.GetInfo());
            Console.WriteLine(champignon.GetInfo());
            Console.WriteLine(ecaille.GetInfo());

            Console.WriteLine("\nPotion de soin:");
            Console.WriteLine(potionSoin.GetInfo());
            Console.WriteLine("Effet: " + potionSoin.effet);
            Console.WriteLine("Complexité: " + potionSoin.complexite);
            Console.WriteLine("Peut être créée: " + potionSoin.CanBeCreated());
            // ===== PARCOURS DE LA RELATION ONE-TO-MANY =====
            // Affichage des informations de la potion et de ses ingrédients
            Console.WriteLine("Ingrédients:");
            // ===== ACCÈS AUX OBJETS ASSOCIÉS =====
            // Parcours de tous les AjoutIngredient associés à la potion
            foreach (var ajout in potionSoin.GetIngredients())
            {
                Console.WriteLine("- " + ajout.GetDetails());
            }

            Console.WriteLine("\nPotion de soin suprême:");
            Console.WriteLine(potionSoinSupreme.GetInfo());
            Console.WriteLine("Effet: " + potionSoinSupreme.effet);
            Console.WriteLine("Complexité: " + potionSoinSupreme.complexite);
            Console.WriteLine("Peut être créée: " + potionSoinSupreme.CanBeCreated());
            Console.WriteLine("Ingrédients:");
            foreach (var ajout in potionSoinSupreme.GetIngredients())
            {
                Console.WriteLine("- " + ajout.GetDetails());
            }
        }
    }
}
