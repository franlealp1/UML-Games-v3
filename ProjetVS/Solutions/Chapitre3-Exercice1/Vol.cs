using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant un vol
    /// </summary>
    public class Vol
    {
        // Champs privés
        private string _numeroVol;
        private DateTime _dateDepart;
        private DateTime _dateArrivee;
        private string _statut; // "Planifié", "En vol", "Atterri", "Annulé"
        
        // ===== IMPLÉMENTATION DE LA RELATION DE COMPOSITION =====
        // Un vol comprend plusieurs réservations (composition)
        // Cette liste contient toutes les réservations pour ce vol
        private List<Reservation> _reservations;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'ASSOCIATION =====
        // Un vol suit une route
        private Route _route;
        
        // Un vol est opéré par un avion
        private Avion _avion;

        // Propriétés publiques
        public string NumeroVol
        {
            get { return _numeroVol; }
            set { _numeroVol = value; }
        }

        public DateTime DateDepart
        {
            get { return _dateDepart; }
            set { _dateDepart = value; }
        }

        public DateTime DateArrivee
        {
            get { return _dateArrivee; }
            set { _dateArrivee = value; }
        }

        public string Statut
        {
            get { return _statut; }
            set { _statut = value; }
        }

        // ===== PROPRIÉTÉS POUR ACCÉDER AUX RELATIONS =====
        public List<Reservation> Reservations
        {
            get { return _reservations; }
            set { _reservations = value; }
        }

        public Route Route
        {
            get { return _route; }
            set { _route = value; }
        }

        public Avion Avion
        {
            get { return _avion; }
            set { _avion = value; }
        }

        /// <summary>
        /// Constructeur de la classe Vol
        /// </summary>
        /// <param name="numeroVol">Numéro du vol</param>
        /// <param name="dateDepart">Date et heure de départ</param>
        /// <param name="dateArrivee">Date et heure d'arrivée</param>
        /// <param name="route">Route suivie par le vol</param>
        /// <param name="avion">Avion utilisé pour le vol</param>
        public Vol(string numeroVol, DateTime dateDepart, DateTime dateArrivee, Route route, Avion avion)
        {
            NumeroVol = numeroVol;
            DateDepart = dateDepart;
            DateArrivee = dateArrivee;
            Statut = "Planifié";
            Route = route;
            Avion = avion;
            
            // Initialisation des collections
            Reservations = new List<Reservation>();
        }

        /// <summary>
        /// Simule l'embarquement des passagers
        /// </summary>
        public void Embarquer()
        {
            if (Statut == "Planifié")
            {
                Console.WriteLine($"Embarquement des passagers pour le vol {NumeroVol}");
                Console.WriteLine($"Nombre de réservations: {Reservations.Count}");
            }
            else
            {
                Console.WriteLine($"Impossible d'embarquer, le vol {NumeroVol} n'est pas en statut 'Planifié'");
            }
        }

        /// <summary>
        /// Simule le décollage du vol
        /// </summary>
        public void Decoller()
        {
            if (Statut == "Planifié" && Avion != null)
            {
                Avion.Decoller();
                Statut = "En vol";
                Console.WriteLine($"Vol {NumeroVol} est maintenant en vol");
            }
            else
            {
                Console.WriteLine($"Impossible de décoller, le vol {NumeroVol} n'est pas prêt ou l'avion n'est pas disponible");
            }
        }

        /// <summary>
        /// Simule l'atterrissage du vol
        /// </summary>
        public void Atterrir()
        {
            if (Statut == "En vol" && Avion != null)
            {
                Avion.Atterrir();
                Statut = "Atterri";
                Console.WriteLine($"Vol {NumeroVol} a atterri");
            }
            else
            {
                Console.WriteLine($"Impossible d'atterrir, le vol {NumeroVol} n'est pas en vol");
            }
        }

        /// <summary>
        /// Annule le vol
        /// </summary>
        public void AnnulerVol()
        {
            if (Statut != "En vol" && Statut != "Atterri")
            {
                Statut = "Annulé";
                Console.WriteLine($"Vol {NumeroVol} a été annulé");
                
                // Annulation de toutes les réservations
                foreach (var reservation in Reservations)
                {
                    reservation.Annuler();
                }
            }
            else
            {
                Console.WriteLine($"Impossible d'annuler le vol {NumeroVol}, il est déjà {Statut}");
            }
        }

        /// <summary>
        /// Ajoute une réservation au vol
        /// </summary>
        /// <param name="reservation">Réservation à ajouter</param>
        public void AjouterReservation(Reservation reservation)
        {
            if (reservation == null || Statut == "Annulé" || Statut == "En vol" || Statut == "Atterri")
                return;
                
            if (!Reservations.Contains(reservation))
            {
                Reservations.Add(reservation);
                Console.WriteLine($"Réservation {reservation.CodeReservation} ajoutée au vol {NumeroVol}");
            }
        }
    }
}
