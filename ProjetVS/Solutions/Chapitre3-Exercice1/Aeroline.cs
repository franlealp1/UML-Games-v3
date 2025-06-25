using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant une compagnie aérienne
    /// </summary>
    public class Aeroline
    {
        // Champs privés avec préfixe _ selon la convention du projet
        private string _nom;
        private string _codeIATA;
        private double _budget;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'AGRÉGATION =====
        // Une aéroline possède plusieurs avions (agrégation)
        // Cette liste contient tous les avions possédés par l'aéroline
        private List<Avion> _avions;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'AGRÉGATION =====
        // Une aéroline emploie plusieurs pilotes (agrégation)
        // Cette liste contient tous les pilotes employés par l'aéroline
        private List<Pilote> _pilotes;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'AGRÉGATION =====
        // Une aéroline gère plusieurs routes (agrégation)
        // Cette liste contient toutes les routes gérées par l'aéroline
        private List<Route> _routes;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'ASSOCIATION =====
        // Une aéroline opère plusieurs vols (association)
        // Cette liste contient tous les vols opérés par l'aéroline
        private List<Vol> _vols;

        // Propriétés publiques
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string CodeIATA
        {
            get { return _codeIATA; }
            set { _codeIATA = value; }
        }

        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }

        // ===== PROPRIÉTÉS POUR ACCÉDER AUX RELATIONS =====
        public List<Avion> Avions
        {
            get { return _avions; }
            set { _avions = value; }
        }

        public List<Pilote> Pilotes
        {
            get { return _pilotes; }
            set { _pilotes = value; }
        }

        public List<Route> Routes
        {
            get { return _routes; }
            set { _routes = value; }
        }

        public List<Vol> Vols
        {
            get { return _vols; }
            set { _vols = value; }
        }

        /// <summary>
        /// Constructeur de la classe Aeroline
        /// </summary>
        /// <param name="nom">Nom de la compagnie aérienne</param>
        /// <param name="codeIATA">Code IATA de la compagnie</param>
        /// <param name="budget">Budget initial de la compagnie</param>
        public Aeroline(string nom, string codeIATA, double budget)
        {
            Nom = nom;
            CodeIATA = codeIATA;
            Budget = budget;
            
            // Initialisation des collections
            Avions = new List<Avion>();
            Pilotes = new List<Pilote>();
            Routes = new List<Route>();
            Vols = new List<Vol>();
        }

        /// <summary>
        /// Ajoute un avion à la flotte de l'aéroline
        /// </summary>
        /// <param name="avion">Avion à ajouter</param>
        public void AjouterAvion(Avion avion)
        {
            if (avion == null)
                return;
                
            if (!Avions.Contains(avion))
            {
                Avions.Add(avion);
                Console.WriteLine($"Avion {avion.Immatriculation} ajouté à la flotte de {Nom}");
            }
        }

        /// <summary>
        /// Retire un avion de la flotte de l'aéroline
        /// </summary>
        /// <param name="avion">Avion à retirer</param>
        public void RetirerAvion(Avion avion)
        {
            if (avion == null)
                return;
                
            if (Avions.Contains(avion))
            {
                Avions.Remove(avion);
                Console.WriteLine($"Avion {avion.Immatriculation} retiré de la flotte de {Nom}");
            }
        }

        /// <summary>
        /// Engage un pilote dans l'aéroline
        /// </summary>
        /// <param name="pilote">Pilote à engager</param>
        public void EngagerPilote(Pilote pilote)
        {
            if (pilote == null)
                return;
                
            if (!Pilotes.Contains(pilote))
            {
                Pilotes.Add(pilote);
                Console.WriteLine($"Pilote {pilote.Nom} engagé par {Nom}");
            }
        }

        /// <summary>
        /// Licencie un pilote de l'aéroline
        /// </summary>
        /// <param name="pilote">Pilote à licencier</param>
        public void LicencierPilote(Pilote pilote)
        {
            if (pilote == null)
                return;
                
            if (Pilotes.Contains(pilote))
            {
                Pilotes.Remove(pilote);
                Console.WriteLine($"Pilote {pilote.Nom} licencié par {Nom}");
            }
        }

        /// <summary>
        /// Ajoute une route au réseau de l'aéroline
        /// </summary>
        /// <param name="route">Route à ajouter</param>
        public void AjouterRoute(Route route)
        {
            if (route == null)
                return;
                
            if (!Routes.Contains(route))
            {
                Routes.Add(route);
                Console.WriteLine($"Route {route.CodeRoute} ajoutée au réseau de {Nom}");
            }
        }

        /// <summary>
        /// Planifie un vol pour l'aéroline
        /// </summary>
        /// <param name="vol">Vol à planifier</param>
        public void PlanifierVol(Vol vol)
        {
            if (vol == null)
                return;
                
            if (!Vols.Contains(vol))
            {
                Vols.Add(vol);
                Console.WriteLine($"Vol {vol.NumeroVol} planifié pour {Nom}");
            }
        }

        /// <summary>
        /// Annule un vol de l'aéroline
        /// </summary>
        /// <param name="vol">Vol à annuler</param>
        public void AnnulerVol(Vol vol)
        {
            if (vol == null)
                return;
                
            if (Vols.Contains(vol))
            {
                vol.AnnulerVol();
                Console.WriteLine($"Vol {vol.NumeroVol} annulé pour {Nom}");
            }
        }
    }
}
