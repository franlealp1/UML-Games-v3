using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant une réservation de vol
    /// </summary>
    public class Reservation
    {
        // Champs privés
        private string _codeReservation;
        private DateTime _dateReservation;
        private string _classe; // "Économique", "Affaires", "Première"
        private bool _estConfirmee;

        // Propriétés publiques
        public string CodeReservation
        {
            get { return _codeReservation; }
            set { _codeReservation = value; }
        }

        public DateTime DateReservation
        {
            get { return _dateReservation; }
            set { _dateReservation = value; }
        }

        public string Classe
        {
            get { return _classe; }
            set { _classe = value; }
        }

        public bool EstConfirmee
        {
            get { return _estConfirmee; }
            set { _estConfirmee = value; }
        }

        /// <summary>
        /// Constructeur de la classe Reservation
        /// </summary>
        /// <param name="codeReservation">Code unique de la réservation</param>
        /// <param name="dateReservation">Date à laquelle la réservation a été effectuée</param>
        /// <param name="classe">Classe de voyage</param>
        public Reservation(string codeReservation, DateTime dateReservation, string classe)
        {
            CodeReservation = codeReservation;
            DateReservation = dateReservation;
            Classe = classe;
            EstConfirmee = false;
        }

        /// <summary>
        /// Confirme la réservation
        /// </summary>
        public void Confirmer()
        {
            EstConfirmee = true;
            Console.WriteLine($"Réservation {CodeReservation} confirmée");
        }

        /// <summary>
        /// Annule la réservation
        /// </summary>
        public void Annuler()
        {
            EstConfirmee = false;
            Console.WriteLine($"Réservation {CodeReservation} annulée");
        }

        /// <summary>
        /// Modifie la classe de voyage
        /// </summary>
        /// <param name="nouvelleClasse">Nouvelle classe de voyage</param>
        public void ModifierClasse(string nouvelleClasse)
        {
            string ancienneClasse = Classe;
            Classe = nouvelleClasse;
            Console.WriteLine($"Réservation {CodeReservation} : classe modifiée de {ancienneClasse} à {nouvelleClasse}");
        }
    }
}
