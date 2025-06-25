using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant un équipement d'avion
    /// </summary>
    public class Equipement
    {
        // Champs privés
        private string _nom;
        private string _numeroSerie;
        private DateTime _dateInstallation;
        private bool _estFonctionnel;

        // Propriétés publiques
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string NumeroSerie
        {
            get { return _numeroSerie; }
            set { _numeroSerie = value; }
        }

        public DateTime DateInstallation
        {
            get { return _dateInstallation; }
            set { _dateInstallation = value; }
        }

        public bool EstFonctionnel
        {
            get { return _estFonctionnel; }
            set { _estFonctionnel = value; }
        }

        /// <summary>
        /// Constructeur de la classe Equipement
        /// </summary>
        /// <param name="nom">Nom de l'équipement</param>
        /// <param name="numeroSerie">Numéro de série</param>
        public Equipement(string nom, string numeroSerie)
        {
            Nom = nom;
            NumeroSerie = numeroSerie;
            DateInstallation = DateTime.Now;
            EstFonctionnel = true;
        }

        /// <summary>
        /// Vérifie l'état de fonctionnement de l'équipement
        /// </summary>
        public void Verifier()
        {
            // Simulation d'une vérification avec 10% de chance de défaillance
            Random random = new Random();
            EstFonctionnel = random.Next(10) > 0;
            
            if (EstFonctionnel)
            {
                Console.WriteLine($"Équipement {Nom} ({NumeroSerie}) est fonctionnel");
            }
            else
            {
                Console.WriteLine($"Équipement {Nom} ({NumeroSerie}) est défectueux et nécessite une réparation");
            }
        }

        /// <summary>
        /// Répare l'équipement s'il est défectueux
        /// </summary>
        public void Reparer()
        {
            if (!EstFonctionnel)
            {
                EstFonctionnel = true;
                Console.WriteLine($"Équipement {Nom} ({NumeroSerie}) a été réparé");
            }
            else
            {
                Console.WriteLine($"Équipement {Nom} ({NumeroSerie}) n'a pas besoin de réparation");
            }
        }
    }
}
