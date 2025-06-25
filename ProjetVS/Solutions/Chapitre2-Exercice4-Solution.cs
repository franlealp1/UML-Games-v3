using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML
{
    /// <summary>
    /// Classe abstraite représentant un ingrédient
    /// </summary>
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
    public class Potion : Ingredient
    {
        public string effet { get; set; } = "";
        public int complexite { get; set; }
        private List<AjoutIngredient> ingredients = new List<AjoutIngredient>();

        public void AddIngredient(Ingredient ingredient, int quantite, int ordre)
        {
            ingredients.Add(new AjoutIngredient 
            { 
                ingredient = ingredient, 
                quantite = quantite, 
                ordreAjout = ordre 
            });
        }

        public List<AjoutIngredient> GetIngredients()
        {
            return ingredients;
        }

        public bool CanBeCreated()
        {
            // Une potion peut être créée si elle a au moins un ingrédient
            return ingredients.Count > 0;
        }
    }

    /// <summary>
    /// Classe représentant l'ajout d'un ingrédient dans une potion
    /// </summary>
    public class AjoutIngredient
    {
        public Ingredient ingredient { get; set; } = null!;
        public int quantite { get; set; }
        public int ordreAjout { get; set; }

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

            // Création d'ingrédients bruts
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

            // Création d'une potion simple
            var potionSoin = new Potion 
            { 
                nom = "Potion de soin", 
                description = "Restaure les points de vie", 
                effet = "Guérison", 
                complexite = 2 
            };

            // Ajout d'ingrédients à la potion
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

            // Ajout d'ingrédients à la potion avancée, y compris une autre potion
            potionSoinSupreme.AddIngredient(potionSoin, 1, 1);
            potionSoinSupreme.AddIngredient(ecaille, 2, 2);

            // Affichage des informations
            Console.WriteLine("Ingrédients bruts:");
            Console.WriteLine(herbe.GetInfo());
            Console.WriteLine(champignon.GetInfo());
            Console.WriteLine(ecaille.GetInfo());

            Console.WriteLine("\nPotion de soin:");
            Console.WriteLine(potionSoin.GetInfo());
            Console.WriteLine("Effet: " + potionSoin.effet);
            Console.WriteLine("Complexité: " + potionSoin.complexite);
            Console.WriteLine("Peut être créée: " + potionSoin.CanBeCreated());
            Console.WriteLine("Ingrédients:");
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
