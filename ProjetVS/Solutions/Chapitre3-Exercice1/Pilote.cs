using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant un pilote d'avion
    /// </summary>
    public class Pilote
    {
        // Champs privés
        private string _nom;
        private string _licence;
        private int _heuresDeVol;
        private bool _estDisponible;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'ASSOCIATION MANY-TO-MANY =====
        // Un pilote peut piloter plusieurs avions (many-to-many)
        // Cette liste contient tous les avions que le pilote est qualifié pour piloter
        private List<Avion> _avionsQualifies;

        // Propriétés publiques
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Licence
        {
            get { return _licence; }
            set { _licence = value; }
        }

        public int HeuresDeVol
        {
            get { return _heuresDeVol; }
            set { _heuresDeVol = value; }
        }

        public bool EstDisponible
        {
            get { return _estDisponible; }
            set { _estDisponible = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION MANY-TO-MANY =====
        public List<Avion> AvionsQualifies
        {
            get { return _avionsQualifies; }
            set { _avionsQualifies = value; }
        }

        /// <summary>
        /// Constructeur de la classe Pilote
        /// </summary>
        /// <param name="nom">Nom du pilote</param>
        /// <param name="licence">Numéro de licence du pilote</param>
        /// <param name="heuresDeVol">Nombre d'heures de vol</param>
        public Pilote(string nom, string licence, int heuresDeVol)
        {
            Nom = nom;
            Licence = licence;
            HeuresDeVol = heuresDeVol;
            EstDisponible = true;
            
            // Initialisation des collections
            AvionsQualifies = new List<Avion>();
        }

        /// <summary>
        /// Pilote un avion spécifique
        /// </summary>
        /// <param name="avion">Avion à piloter</param>
        public void PiloterAvion(Avion avion)
        {
            if (avion == null || !EstDisponible)
                return;
                
            if (AvionsQualifies.Contains(avion))
            {
                Console.WriteLine($"Pilote {Nom} pilote l'avion {avion.Immatriculation}");
                EstDisponible = false;
            }
            else
            {
                Console.WriteLine($"Pilote {Nom} n'est pas qualifié pour piloter l'avion {avion.Immatriculation}");
            }
        }

        /// <summary>
        /// Termine un vol
        /// </summary>
        public void TerminerVol()
        {
            if (!EstDisponible)
            {
                EstDisponible = true;
                HeuresDeVol += 1; // Ajoute une heure de vol (simplifié)
                Console.WriteLine($"Pilote {Nom} a terminé son vol. Total heures de vol: {HeuresDeVol}");
            }
        }

        /// <summary>
        /// Prend un repos réglementaire
        /// </summary>
        public void PrendreRepos()
        {
            Console.WriteLine($"Pilote {Nom} prend un repos réglementaire");
            EstDisponible = false;
        }

        /// <summary>
        /// Ajoute une qualification pour un type d'avion
        /// </summary>
        /// <param name="avion">Avion pour lequel le pilote est qualifié</param>
        public void AjouterQualification(Avion avion)
        {
            if (avion == null)
                return;
                
            if (!AvionsQualifies.Contains(avion))
            {
                AvionsQualifies.Add(avion);
                Console.WriteLine($"Pilote {Nom} est maintenant qualifié pour piloter l'avion {avion.Immatriculation}");
            }
        }
    }
}
