using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML
{
    /// <summary>
    /// Classe représentant un Mii (personnage du joueur) dans Wii Sports
    /// </summary>
    class Mii
    {
        // Propriétés privées avec préfixe _ selon la convention du projet
        private string _nom;
        private int _age;
        
        // ===== IMPLÉMENTATION DE LA RELATION MANY-TO-MANY =====
        // Un Mii peut participer à plusieurs épreuves (many-to-many)
        // Cette liste contient toutes les participations du Mii
        private List<Participation> _participations;

        // Propriétés publiques
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION MANY-TO-MANY =====
        // Cette propriété permet d'accéder à toutes les participations du Mii
        // Chaque participation représente une relation avec une épreuve

        // Note: le set est indispensable seulement si on veut 
        // fixer toutes les objets de l'autre côté de la rélation 
        // d'un coup... souvent on a de méthodes ad-hoc pour gérer ce fait
        public List<Participation> Participations
        {
            get { return _participations; }
            set { _participations = value; }
        }

        /// <summary>
        /// Constructeur de la classe Mii
        /// </summary>
        /// <param name="nom">Nom du Mii</param>
        /// <param name="age">Âge du Mii</param>
        public Mii(string nom, int age)
        {
            Nom = nom;
            Age = age;
            // ===== INITIALISATION DE LA RELATION MANY-TO-MANY =====
            // Initialisation de la liste des participations (relation many-to-many)
            Participations = new List<Participation>();
        }

        /// <summary>
        /// Inscrit le Mii à une épreuve
        /// </summary>
        /// <param name="epreuve">Épreuve à laquelle s'inscrire</param>
        public void SInscrireAEpreuve(Epreuve epreuve)
        {
            if (epreuve != null)
            {
                // ===== VÉRIFICATION DE LA RELATION MANY-TO-MANY =====
                // Vérifier si le Mii n'est pas déjà inscrit à cette épreuve
                if (!Participations.Any(p => p.Epreuve == epreuve))
                {
                    // ===== CRÉATION DE LA CLASSE D'ASSOCIATION =====
                    // Création d'une nouvelle participation (classe d'association)
                    Participation participation = new Participation(this, epreuve);
                    
                    // ===== MAINTIEN DE LA COHÉRENCE BIDIRECTIONNELLE =====
                    // Ajout de la participation dans la liste du Mii
                    Participations.Add(participation);
                    // Ajout de la participation dans la liste de l'épreuve
                    epreuve.Participations.Add(participation);
                    
                    Console.WriteLine($"Mii '{Nom}' inscrit à l'épreuve '{epreuve.Nom}'");
                }
                else
                {
                    Console.WriteLine($"Mii '{Nom}' est déjà inscrit à l'épreuve '{epreuve.Nom}'");
                }
            }
        }

        /// <summary>
        /// Enregistre le résultat d'un Mii dans une épreuve.. c'est en fait enregistrer une Participation 
        /// </summary>
        /// <param name="epreuve">Épreuve concernée</param>
        /// <param name="temps">Temps réalisé</param>
        /// <param name="position">Position finale</param>
        public void EnregistrerResultat(Epreuve epreuve, double temps, int position)
        {
            // ===== RECHERCHE DANS LA RELATION MANY-TO-MANY =====
            // Recherche de la participation correspondante dans la relation
            var participation = Participations.FirstOrDefault(p => p.Epreuve == epreuve);
            // Si on la trouve
            if (participation != null)
            {
                // ===== MODIFICATION DES DONNÉES DE LA CLASSE D'ASSOCIATION =====
                // Mise à jour des informations de la participation
                participation.TempsRealise = temps;
                participation.PositionFinale = position;
                participation.Qualification = position <= 3; // Top 3 qualifiés
                Console.WriteLine($"Résultat enregistré pour {Nom} dans {epreuve.Nom}: {temps}s, position {position}");
            }
            else
            {
                Console.WriteLine($"Mii '{Nom}' n'est pas inscrit à l'épreuve '{epreuve.Nom}'");
            }
        }

        /// <summary>
        /// Consulte toutes les épreuves du Mii
        /// </summary>
        public void ConsulterEpreuves()
        {
            Console.WriteLine($"\n=== Épreuves de {Nom} ===");
            if (Participations.Count == 0)
            {
                Console.WriteLine("Aucune épreuve participée.");
            }
            else
            {
                // ===== PARCOURS DE LA RELATION MANY-TO-MANY =====
                // Parcours de toutes les participations pour afficher les épreuves
                foreach (var participation in Participations)
                {
                    string resultat = participation.TempsRealise > 0 
                        ? $" - Temps: {participation.TempsRealise}s, Position: {participation.PositionFinale}"
                        : " - Pas encore participé";
                    Console.WriteLine($"- {participation.Epreuve.Nom}{resultat}");
                }
            }
        }
    }

    /// <summary>
    /// Classe représentant une épreuve d'athlétisme dans Wii Sports
    /// </summary>
    class Epreuve
    {
        // Propriétés privées avec préfixe _
        private string _nom;
        private string _type;
        
        // ===== IMPLÉMENTATION DE LA RELATION MANY-TO-MANY =====
        // Une épreuve peut avoir plusieurs participants (many-to-many)
        // Cette liste contient toutes les participations à cette épreuve
        private List<Participation> _participations;
        
        // ===== IMPLÉMENTATION DE LA RELATION RÉFLEXIVE =====
        // Une épreuve peut avoir plusieurs épreuves comme prérequis (association réflexive)
        // Cette liste contient toutes les épreuves prérequises pour cette épreuve
        private List<Epreuve> _prerequis;

        // Propriétés publiques
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION MANY-TO-MANY =====
        // Cette propriété permet d'accéder à toutes les participations de l'épreuve
        public List<Participation> Participations
        {
            get { return _participations; }
            set { _participations = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION RÉFLEXIVE =====
        // Cette propriété permet d'accéder à tous les prérequis de l'épreuve
        public List<Epreuve> Prerequis
        {
            get { return _prerequis; }
            set { _prerequis = value; }
        }

        /// <summary>
        /// Constructeur de la classe Epreuve
        /// </summary>
        /// <param name="nom">Nom de l'épreuve</param>
        /// <param name="type">Type d'épreuve (course, saut, etc.)</param>
        public Epreuve(string nom, string type)
        {
            Nom = nom;
            Type = type;
            // ===== INITIALISATION DES RELATIONS =====
            // Initialisation de la liste des participations (relation many-to-many)
            Participations = new List<Participation>();
            // Initialisation de la liste des prérequis (relation réflexive)
            Prerequis = new List<Epreuve>();
        }

        /// <summary>
        /// Ajoute un prérequis à cette épreuve (association réflexive)
        /// </summary>
        /// <param name="prerequis">Épreuve prérequise</param>
        public void AjouterPrerequis(Epreuve prerequis)
        {
            // ===== GESTION DE LA RELATION RÉFLEXIVE =====
            // Vérification que l'épreuve prérequise n'est pas la même épreuve
            if (prerequis != null && prerequis != this && !Prerequis.Contains(prerequis))
            {
                // Ajout de l'épreuve dans la liste des prérequis
                Prerequis.Add(prerequis);
                Console.WriteLine($"Épreuve '{prerequis.Nom}' ajoutée comme prérequis pour '{Nom}'");
            }
        }

        /// <summary>
        /// Consulte tous les participants de l'épreuve
        /// </summary>
        public void ConsulterParticipants()
        {
            Console.WriteLine($"\n=== Participants de l'épreuve '{Nom}' ===");
            if (Participations.Count == 0)
            {
                Console.WriteLine("Aucun participant inscrit.");
            }
            else
            {
                // ===== PARCOURS DE LA RELATION MANY-TO-MANY =====
                // Parcours de toutes les participations pour afficher les participants
                foreach (var participation in Participations)
                {
                    string resultat = participation.TempsRealise > 0 
                        ? $" (Temps: {participation.TempsRealise}s, Position: {participation.PositionFinale})"
                        : " (Pas encore participé)";
                    Console.WriteLine($"- {participation.Mii.Nom}{resultat}");
                }
            }
        }

        /// <summary>
        /// Vérifie si un Mii peut participer à cette épreuve (prérequis respectés)
        /// </summary>
        /// <param name="mii">Mii à vérifier</param>
        /// <returns>True si le Mii peut participer</returns>
        public bool PeutParticiper(Mii mii)
        {
            // ===== VÉRIFICATION DE LA RELATION RÉFLEXIVE =====
            // Si aucun prérequis, participation autorisée
            if (Prerequis.Count == 0)
                return true;

            // Vérification de tous les prérequis
            foreach (var prerequis in Prerequis)
            {
                // ===== CROISEMENT DES RELATIONS MANY-TO-MANY ET RÉFLEXIVE =====
                // Recherche de la participation du Mii dans l'épreuve prérequise
                var participationPrerequis = mii.Participations.FirstOrDefault(p => p.Epreuve == prerequis);
                // Vérification que le Mii a participé ET s'est qualifié
                if (participationPrerequis == null || !participationPrerequis.Qualification)
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// Classe d'association entre Mii et Épreuve (many-to-many avec classe d'association)
    /// Cette classe représente la relation many-to-many entre Mii et Épreuve
    /// et contient les informations spécifiques à cette relation
    /// </summary>
    class Participation
    {
        // ===== IMPLÉMENTATION DE LA CLASSE D'ASSOCIATION =====
        // Références vers les deux classes en relation (many-to-many)
        private Mii _mii;           // Référence vers le Mii participant
        private Epreuve _epreuve;   // Référence vers l'épreuve
        
        // ===== DONNÉES SPÉCIFIQUES À LA RELATION =====
        // Ces propriétés sont spécifiques à la relation Mii-Épreuve
        private double _tempsRealise;    // Temps réalisé par le Mii
        private int _positionFinale;     // Position finale du Mii
        private bool _qualification;     // Si le Mii s'est qualifié

        // Propriétés publiques pour accéder aux références
        public Mii Mii
        {
            get { return _mii; }
            set { _mii = value; }
        }

        public Epreuve Epreuve
        {
            get { return _epreuve; }
            set { _epreuve = value; }
        }

        // Propriétés publiques pour accéder aux données de la relation
        public double TempsRealise
        {
            get { return _tempsRealise; }
            set { _tempsRealise = value; }
        }

        public int PositionFinale
        {
            get { return _positionFinale; }
            set { _positionFinale = value; }
        }

        public bool Qualification
        {
            get { return _qualification; }
            set { _qualification = value; }
        }

        /// <summary>
        /// Constructeur de la classe Participation
        /// </summary>
        /// <param name="mii">Mii participant</param>
        /// <param name="epreuve">Épreuve à laquelle participer</param>
        public Participation(Mii mii, Epreuve epreuve)
        {
            // ===== INITIALISATION DE LA RELATION MANY-TO-MANY =====
            // Initialisation des références vers les deux classes en relation
            Mii = mii;
            Epreuve = epreuve;
            
            // ===== INITIALISATION DES DONNÉES DE LA RELATION =====
            // Initialisation des données spécifiques à la participation
            TempsRealise = 0; // Pas encore participé
            PositionFinale = 0;
            Qualification = false;
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester le système d'athlétisme
    /// </summary>
    public static class AthlétismeExercice2
    {
        public static void Demo()
        {
            Console.WriteLine("=== Système d'Athlétisme Wii Sports ===\n");

            // Création des Miis
            Mii mii1 = new Mii("Mario", 25);
            Mii mii2 = new Mii("Luigi", 23);
            Mii mii3 = new Mii("Peach", 22);
            Console.WriteLine("Miis créés avec succès");

            // Création des épreuves
            Epreuve epreuve100m = new Epreuve("100m", "Course");
            Epreuve epreuve200m = new Epreuve("200m", "Course");
            Epreuve epreuveSaut = new Epreuve("Saut en longueur", "Saut");
            Epreuve epreuveFinale = new Epreuve("Finale combinée", "Combiné");

            // ===== CONFIGURATION DE LA RELATION RÉFLEXIVE =====
            // Configuration des prérequis entre épreuves (association réflexive)
            epreuveFinale.AjouterPrerequis(epreuve100m);
            epreuveFinale.AjouterPrerequis(epreuve200m);
            Console.WriteLine("Prérequis configurés");

            // ===== CRÉATION DES RELATIONS MANY-TO-MANY =====
            // Inscription des Miis aux épreuves (création des participations)
            mii1.SInscrireAEpreuve(epreuve100m);
            mii1.SInscrireAEpreuve(epreuve200m);
            mii2.SInscrireAEpreuve(epreuve100m);
            mii2.SInscrireAEpreuve(epreuveSaut);
            mii3.SInscrireAEpreuve(epreuve200m);
            mii3.SInscrireAEpreuve(epreuveSaut);

            // ===== MODIFICATION DES DONNÉES DE LA CLASSE D'ASSOCIATION =====
            // Enregistrement des résultats (modification des participations)
            mii1.EnregistrerResultat(epreuve100m, 10.5, 1);
            mii1.EnregistrerResultat(epreuve200m, 21.2, 2);
            mii2.EnregistrerResultat(epreuve100m, 11.0, 2);
            mii2.EnregistrerResultat(epreuveSaut, 6.8, 1);
            mii3.EnregistrerResultat(epreuve200m, 22.1, 3);
            mii3.EnregistrerResultat(epreuveSaut, 6.5, 2);

            // Consultation des épreuves de chaque Mii
            mii1.ConsulterEpreuves();
            mii2.ConsulterEpreuves();
            mii3.ConsulterEpreuves();

            // Consultation des participants de chaque épreuve
            epreuve100m.ConsulterParticipants();
            epreuve200m.ConsulterParticipants();
            epreuveSaut.ConsulterParticipants();

            // ===== TEST DE LA RELATION RÉFLEXIVE =====
            // Test des prérequis pour la finale (utilisation de la relation réflexive)
            Console.WriteLine($"\n=== Vérification des prérequis pour la finale ===");
            Console.WriteLine($"Mario peut participer à la finale: {epreuveFinale.PeutParticiper(mii1)}");
            Console.WriteLine($"Luigi peut participer à la finale: {epreuveFinale.PeutParticiper(mii2)}");
            Console.WriteLine($"Peach peut participer à la finale: {epreuveFinale.PeutParticiper(mii3)}");
        }
    }
} 