using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant une opération de maintenance sur un avion
    /// </summary>
    public class Maintenance
    {
        // Champs privés
        private string _typeMaintenance;
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private string _technicien;
        private bool _estTerminee;

        // Propriétés publiques
        public string TypeMaintenance
        {
            get { return _typeMaintenance; }
            set { _typeMaintenance = value; }
        }

        public DateTime DateDebut
        {
            get { return _dateDebut; }
            set { _dateDebut = value; }
        }

        public DateTime DateFin
        {
            get { return _dateFin; }
            set { _dateFin = value; }
        }

        public string Technicien
        {
            get { return _technicien; }
            set { _technicien = value; }
        }

        public bool EstTerminee
        {
            get { return _estTerminee; }
            set { _estTerminee = value; }
        }

        /// <summary>
        /// Constructeur de la classe Maintenance
        /// </summary>
        /// <param name="typeMaintenance">Type de maintenance effectuée</param>
        /// <param name="dateDebut">Date de début de la maintenance</param>
        /// <param name="dateFin">Date de fin prévue de la maintenance</param>
        /// <param name="technicien">Nom du technicien responsable</param>
        public Maintenance(string typeMaintenance, DateTime dateDebut, DateTime dateFin, string technicien)
        {
            TypeMaintenance = typeMaintenance;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Technicien = technicien;
            EstTerminee = false;
        }

        /// <summary>
        /// Démarre l'opération de maintenance
        /// </summary>
        public void DemarrerMaintenance()
        {
            Console.WriteLine($"Maintenance {TypeMaintenance} démarrée le {DateDebut.ToShortDateString()} par {Technicien}");
        }

        /// <summary>
        /// Termine l'opération de maintenance
        /// </summary>
        public void TerminerMaintenance()
        {
            EstTerminee = true;
            DateFin = DateTime.Now;
            Console.WriteLine($"Maintenance {TypeMaintenance} terminée le {DateFin.ToShortDateString()} par {Technicien}");
        }
    }
}
