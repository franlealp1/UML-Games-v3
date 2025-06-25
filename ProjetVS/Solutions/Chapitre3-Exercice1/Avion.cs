using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe représentant un avion
    /// </summary>
    public class Avion
    {
        // Champs privés
        private string _immatriculation;
        private string _modele;
        private int _capacitePassagers;
        private double _autonomieKm;
        private bool _estDisponible;
        
        // ===== IMPLÉMENTATION DE LA RELATION DE COMPOSITION =====
        // Un avion contient plusieurs équipements (composition)
        // Cette liste contient tous les équipements installés dans l'avion
        private List<Equipement> _equipements;
        
        // ===== IMPLÉMENTATION DE LA RELATION D'ASSOCIATION =====
        // Un avion peut subir plusieurs maintenances (association)
        // Cette liste contient l'historique des maintenances de l'avion
        private List<Maintenance> _maintenances;

        // Propriétés publiques
        public string Immatriculation
        {
            get { return _immatriculation; }
            set { _immatriculation = value; }
        }

        public string Modele
        {
            get { return _modele; }
            set { _modele = value; }
        }

        public int CapacitePassagers
        {
            get { return _capacitePassagers; }
            set { _capacitePassagers = value; }
        }

        public double AutonomieKm
        {
            get { return _autonomieKm; }
            set { _autonomieKm = value; }
        }

        public bool EstDisponible
        {
            get { return _estDisponible; }
            set { _estDisponible = value; }
        }

        // ===== PROPRIÉTÉS POUR ACCÉDER AUX RELATIONS =====
        public List<Equipement> Equipements
        {
            get { return _equipements; }
            set { _equipements = value; }
        }

        public List<Maintenance> Maintenances
        {
            get { return _maintenances; }
            set { _maintenances = value; }
        }

        /// <summary>
        /// Constructeur de la classe Avion
        /// </summary>
        /// <param name="immatriculation">Immatriculation de l'avion</param>
        /// <param name="modele">Modèle de l'avion</param>
        /// <param name="capacitePassagers">Capacité en nombre de passagers</param>
        /// <param name="autonomieKm">Autonomie en kilomètres</param>
        public Avion(string immatriculation, string modele, int capacitePassagers, double autonomieKm)
        {
            Immatriculation = immatriculation;
            Modele = modele;
            CapacitePassagers = capacitePassagers;
            AutonomieKm = autonomieKm;
            EstDisponible = true;
            
            // Initialisation des collections
            Equipements = new List<Equipement>();
            Maintenances = new List<Maintenance>();
        }

        /// <summary>
        /// Simule le décollage de l'avion
        /// </summary>
        public void Decoller()
        {
            if (EstDisponible)
            {
                Console.WriteLine($"Avion {Immatriculation} décolle");
                EstDisponible = false;
            }
            else
            {
                Console.WriteLine($"Avion {Immatriculation} n'est pas disponible pour décoller");
            }
        }

        /// <summary>
        /// Simule l'atterrissage de l'avion
        /// </summary>
        public void Atterrir()
        {
            Console.WriteLine($"Avion {Immatriculation} atterrit");
            EstDisponible = true;
        }

        /// <summary>
        /// Effectue une maintenance sur l'avion
        /// </summary>
        public void EffectuerMaintenance()
        {
            if (EstDisponible)
            {
                EstDisponible = false;
                Console.WriteLine($"Maintenance en cours sur l'avion {Immatriculation}");
                
                // Vérification de tous les équipements
                foreach (var equipement in Equipements)
                {
                    equipement.Verifier();
                }
                
                // Création d'une nouvelle maintenance
                Maintenance maintenance = new Maintenance("Maintenance régulière", DateTime.Now, DateTime.Now.AddDays(2), "Technicien");
                Maintenances.Add(maintenance);
            }
            else
            {
                Console.WriteLine($"Impossible d'effectuer la maintenance, avion {Immatriculation} n'est pas disponible");
            }
        }

        /// <summary>
        /// Ajoute un équipement à l'avion
        /// </summary>
        /// <param name="equipement">Équipement à ajouter</param>
        public void AjouterEquipement(Equipement equipement)
        {
            if (equipement == null)
                return;
                
            if (!Equipements.Contains(equipement))
            {
                Equipements.Add(equipement);
                Console.WriteLine($"Équipement {equipement.Nom} installé sur l'avion {Immatriculation}");
            }
        }
    }
}
