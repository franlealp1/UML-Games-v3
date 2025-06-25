using System;
using System.Collections.Generic;
using System.Linq;

namespace UMLGames.Examples.Chapitre2.Exemple7
{
    /// <summary>
    /// Classe représentant une unité militaire pouvant commander d'autres unités (relation hiérarchique réflexive)
    /// </summary>
    public class MilitaryUnit
    {
        // Champs privés
        private string _name;
        private string _rank;
        private int _experience;
        // ===== IMPLÉMENTATION DE LA RELATION RÉFLEXIVE =====
        // Une unité peut commander plusieurs subordonnés (relation réflexive)
        // Une unité peut aussi avoir un supérieur (relation réflexive inverse)
        private List<MilitaryUnit> _subordinates; // subordonnés
        private MilitaryUnit? _superior;          // supérieur hiérarchique

        /// <summary>
        /// Constructeur de la classe MilitaryUnit
        /// </summary>
        /// <param name="name">Nom de l'unité</param>
        /// <param name="rank">Grade</param>
        /// <param name="experience">Expérience</param>
        public MilitaryUnit(string name, string rank, int experience)
        {
            _name = name;
            _rank = rank;
            _experience = experience;
            _subordinates = new List<MilitaryUnit>();
            _superior = null;
        }

        // Propriétés publiques
        public string Name => _name;
        public string Rank => _rank;
        public int Experience => _experience;
        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION RÉFLEXIVE =====
        // Cette propriété permet d'accéder à tous les subordonnés
        public IReadOnlyList<MilitaryUnit> Subordinates => _subordinates.AsReadOnly();
        // Cette propriété permet d'accéder au supérieur hiérarchique
        public MilitaryUnit? Superior => _superior;

        /// <summary>
        /// Ajoute un subordonné à cette unité (relation réflexive)
        /// </summary>
        /// <param name="unit">Unité à ajouter comme subordonné</param>
        public void AddSubordinate(MilitaryUnit unit)
        {
            if (unit != null && !_subordinates.Contains(unit) && unit != this)
            {
                _subordinates.Add(unit);
                unit._superior = this;
                Console.WriteLine($"{unit.Name} est maintenant subordonné à {_name}.");
            }
        }

        /// <summary>
        /// Retire un subordonné
        /// </summary>
        /// <param name="unit">Unité à retirer</param>
        public void RemoveSubordinate(MilitaryUnit unit)
        {
            if (unit != null && _subordinates.Contains(unit))
            {
                _subordinates.Remove(unit);
                unit._superior = null;
                Console.WriteLine($"{unit.Name} n'est plus subordonné à {_name}.");
            }
        }

        /// <summary>
        /// Donne un ordre à tous les subordonnés
        /// </summary>
        /// <param name="order">Ordre à donner</param>
        public void GiveOrder(string order)
        {
            Console.WriteLine($"{_name} ({_rank}) donne l'ordre : {order}");
            foreach (var sub in _subordinates)
                sub.GiveOrder(order);
        }

        /// <summary>
        /// Affiche le statut de l'unité et de ses subordonnés
        /// </summary>
        /// <param name="indent">Indentation pour l'affichage</param>
        public void ReportStatus(string indent = "")
        {
            Console.WriteLine($"{indent}- {_name} ({_rank}, Exp: {_experience})");
            foreach (var sub in _subordinates)
                sub.ReportStatus(indent + "  ");
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester la hiérarchie militaire réflexive
    /// </summary>
    public static class Example7Demo
    {
        public static void Demo()
        {
            Console.WriteLine("--- Démonstration Exemple 7 : Hiérarchie militaire (relation réflexive) ---");

            // Création d'unités
            MilitaryUnit general = new MilitaryUnit("General Smith", "Général", 30);
            MilitaryUnit colonel = new MilitaryUnit("Colonel Lee", "Colonel", 20);
            MilitaryUnit captain = new MilitaryUnit("Captain Ray", "Capitaine", 15);
            MilitaryUnit sergeant = new MilitaryUnit("Sergeant Max", "Sergent", 10);

            // Construction de la hiérarchie
            general.AddSubordinate(colonel);
            colonel.AddSubordinate(captain);
            captain.AddSubordinate(sergeant);

            // Rapport de statut
            general.ReportStatus();

            // Donne un ordre à toute la hiérarchie
            general.GiveOrder("Avancez !");
        }
    }
} 