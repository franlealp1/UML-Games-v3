using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant un passager
    /// </summary>
    public class Passager
    {
        // Champs privés
        private string _nom;
        private string _passeport;
        private int _pointsFidelite;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'ASSOCIATION =====
        // Un passager peut effectuer plusieurs réservations
        private List<Reservation> _reservations;

        // Propriétés publiques
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Passeport
        {
            get { return _passeport; }
            set { _passeport = value; }
        }

        public int PointsFidelite
        {
            get { return _pointsFidelite; }
            set { _pointsFidelite = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION =====
        public List<Reservation> Reservations
        {
            get { return _reservations; }
            set { _reservations = value; }
        }

        /// <summary>
        /// Constructeur de la classe Passager
        /// </summary>
        /// <param name="nom">Nom du passager</param>
        /// <param name="passeport">Numéro de passeport</param>
        public Passager(string nom, string passeport)
        {
            Nom = nom;
            Passeport = passeport;
            PointsFidelite = 0;
            
            // Initialisation des collections
            Reservations = new List<Reservation>();
        }

        /// <summary>
        /// Réserve un vol pour le passager
        /// </summary>
        /// <param name="vol">Vol à réserver</param>
        /// <param name="classe">Classe de réservation (Économique, Affaires, Première)</param>
        /// <returns>La réservation créée</returns>
        public Reservation ReserverVol(Vol vol, string classe)
        {
            if (vol == null)
                return null;
                
            // Création d'une nouvelle réservation
            string codeReservation = $"RES-{Passeport.Substring(0, 3)}-{DateTime.Now.Ticks % 10000}";
            Reservation reservation = new Reservation(codeReservation, DateTime.Now, classe);
            
            // Ajout de la réservation aux collections
            Reservations.Add(reservation);
            vol.AjouterReservation(reservation);
            
            // Ajout de points de fidélité
            AjouterPointsFidelite(classe);
            
            Console.WriteLine($"Passager {Nom} a réservé le vol {vol.NumeroVol} en classe {classe}");
            return reservation;
        }

        /// <summary>
        /// Annule une réservation
        /// </summary>
        /// <param name="reservation">Réservation à annuler</param>
        public void AnnulerReservation(Reservation reservation)
        {
            if (reservation == null)
                return;
                
            if (Reservations.Contains(reservation))
            {
                reservation.Annuler();
                Console.WriteLine($"Passager {Nom} a annulé la réservation {reservation.CodeReservation}");
            }
        }

        /// <summary>
        /// Simule l'enregistrement des bagages
        /// </summary>
        public void EnregistrerBagages()
        {
            Console.WriteLine($"Passager {Nom} enregistre ses bagages");
        }

        /// <summary>
        /// Ajoute des points de fidélité selon la classe de vol
        /// </summary>
        /// <param name="classe">Classe de vol</param>
        private void AjouterPointsFidelite(string classe)
        {
            switch (classe.ToLower())
            {
                case "économique":
                    PointsFidelite += 100;
                    break;
                case "affaires":
                    PointsFidelite += 250;
                    break;
                case "première":
                    PointsFidelite += 500;
                    break;
                default:
                    PointsFidelite += 50;
                    break;
            }
            
            Console.WriteLine($"Passager {Nom} a maintenant {PointsFidelite} points de fidélité");
        }
    }
}
