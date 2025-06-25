using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant une route aérienne entre deux aéroports
    /// </summary>
    public class Route
    {
        // Champs privés
        private string _codeRoute;
        private double _distanceKm;
        private int _dureeMinutes;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'ASSOCIATION =====
        // Une route a un aéroport de départ
        private Aeroport _aeroportDepart;
        
        // Une route a un aéroport d'arrivée
        private Aeroport _aeroportArrivee;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'ASSOCIATION =====
        // Une route peut être suivie par plusieurs vols
        private List<Vol> _vols;

        // Propriétés publiques
        public string CodeRoute
        {
            get { return _codeRoute; }
            set { _codeRoute = value; }
        }

        public double DistanceKm
        {
            get { return _distanceKm; }
            set { _distanceKm = value; }
        }

        public int DureeMinutes
        {
            get { return _dureeMinutes; }
            set { _dureeMinutes = value; }
        }

        // ===== PROPRIÉTÉS POUR ACCÉDER AUX RELATIONS =====
        public Aeroport AeroportDepart
        {
            get { return _aeroportDepart; }
            set 
            { 
                _aeroportDepart = value;
                if (value != null)
                {
                    value.AjouterRouteDepart(this);
                }
            }
        }

        public Aeroport AeroportArrivee
        {
            get { return _aeroportArrivee; }
            set 
            { 
                _aeroportArrivee = value;
                if (value != null)
                {
                    value.AjouterRouteArrivee(this);
                }
            }
        }

        public List<Vol> Vols
        {
            get { return _vols; }
            set { _vols = value; }
        }

        /// <summary>
        /// Constructeur de la classe Route
        /// </summary>
        /// <param name="codeRoute">Code identifiant la route</param>
        /// <param name="aeroportDepart">Aéroport de départ</param>
        /// <param name="aeroportArrivee">Aéroport d'arrivée</param>
        /// <param name="distanceKm">Distance en kilomètres</param>
        public Route(string codeRoute, Aeroport aeroportDepart, Aeroport aeroportArrivee, double distanceKm)
        {
            CodeRoute = codeRoute;
            DistanceKm = distanceKm;
            
            // Calcul approximatif de la durée de vol (500 km/h en moyenne)
            DureeMinutes = (int)(distanceKm / 500 * 60);
            
            // Initialisation des relations
            AeroportDepart = aeroportDepart;
            AeroportArrivee = aeroportArrivee;
            Vols = new List<Vol>();
        }

        /// <summary>
        /// Calcule la consommation de carburant estimée pour cette route
        /// </summary>
        /// <returns>Consommation en litres</returns>
        public double CalculerConsommationCarburant()
        {
            // Calcul simplifié: 3 litres par km
            double consommation = DistanceKm * 3;
            Console.WriteLine($"Consommation estimée pour la route {CodeRoute}: {consommation} litres");
            return consommation;
        }

        /// <summary>
        /// Estime le temps de vol pour cette route
        /// </summary>
        /// <returns>Durée formatée en heures et minutes</returns>
        public string EstimationTempsVol()
        {
            int heures = DureeMinutes / 60;
            int minutes = DureeMinutes % 60;
            string estimation = $"{heures}h {minutes}min";
            
            Console.WriteLine($"Temps de vol estimé pour la route {CodeRoute}: {estimation}");
            return estimation;
        }

        /// <summary>
        /// Ajoute un vol qui suit cette route
        /// </summary>
        /// <param name="vol">Vol à ajouter</param>
        public void AjouterVol(Vol vol)
        {
            if (vol == null)
                return;
                
            if (!Vols.Contains(vol))
            {
                Vols.Add(vol);
                vol.Route = this;
                Console.WriteLine($"Vol {vol.NumeroVol} ajouté à la route {CodeRoute}");
            }
        }
    }
}
