using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant un aéroport
    /// </summary>
    public class Aeroport
    {
        // Champs privés
        private string _nom;
        private string _codeIATA;
        private string _ville;
        private string _pays;
        private int _nombrePistes;
        
        // ===== IMPLÉMENTATION DES RELATIONS D'ASSOCIATION =====
        // Un aéroport peut être le départ de plusieurs routes
        private List<Route> _routesDepart;
        
        // Un aéroport peut être l'arrivée de plusieurs routes
        private List<Route> _routesArrivee;

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

        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }

        public string Pays
        {
            get { return _pays; }
            set { _pays = value; }
        }

        public int NombrePistes
        {
            get { return _nombrePistes; }
            set { _nombrePistes = value; }
        }

        // ===== PROPRIÉTÉS POUR ACCÉDER AUX RELATIONS =====
        public List<Route> RoutesDepart
        {
            get { return _routesDepart; }
            set { _routesDepart = value; }
        }

        public List<Route> RoutesArrivee
        {
            get { return _routesArrivee; }
            set { _routesArrivee = value; }
        }

        /// <summary>
        /// Constructeur de la classe Aeroport
        /// </summary>
        /// <param name="nom">Nom de l'aéroport</param>
        /// <param name="codeIATA">Code IATA de l'aéroport</param>
        /// <param name="ville">Ville où se situe l'aéroport</param>
        /// <param name="pays">Pays où se situe l'aéroport</param>
        /// <param name="nombrePistes">Nombre de pistes</param>
        public Aeroport(string nom, string codeIATA, string ville, string pays, int nombrePistes)
        {
            Nom = nom;
            CodeIATA = codeIATA;
            Ville = ville;
            Pays = pays;
            NombrePistes = nombrePistes;
            
            // Initialisation des collections
            RoutesDepart = new List<Route>();
            RoutesArrivee = new List<Route>();
        }

        /// <summary>
        /// Ajoute une piste à l'aéroport
        /// </summary>
        public void AjouterPiste()
        {
            NombrePistes++;
            Console.WriteLine($"Une nouvelle piste a été ajoutée à l'aéroport {Nom}. Total: {NombrePistes} pistes");
        }

        /// <summary>
        /// Accueille un vol à l'arrivée
        /// </summary>
        /// <param name="vol">Vol à accueillir</param>
        public void AccueillirVol(Vol vol)
        {
            if (vol == null)
                return;
                
            Console.WriteLine($"Aéroport {Nom} accueille le vol {vol.NumeroVol}");
            vol.Atterrir();
        }

        /// <summary>
        /// Ajoute une route au départ de cet aéroport
        /// </summary>
        /// <param name="route">Route à ajouter</param>
        public void AjouterRouteDepart(Route route)
        {
            if (route == null)
                return;
                
            if (!RoutesDepart.Contains(route))
            {
                RoutesDepart.Add(route);
                Console.WriteLine($"Route {route.CodeRoute} ajoutée au départ de l'aéroport {Nom}");
            }
        }

        /// <summary>
        /// Ajoute une route à l'arrivée de cet aéroport
        /// </summary>
        /// <param name="route">Route à ajouter</param>
        public void AjouterRouteArrivee(Route route)
        {
            if (route == null)
                return;
                
            if (!RoutesArrivee.Contains(route))
            {
                RoutesArrivee.Add(route);
                Console.WriteLine($"Route {route.CodeRoute} ajoutée à l'arrivée de l'aéroport {Nom}");
            }
        }
    }
}
