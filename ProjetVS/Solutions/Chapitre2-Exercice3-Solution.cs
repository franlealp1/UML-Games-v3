using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML
{
    /// <summary>
    /// Classe représentant une guilde dans un jeu multijoueur
    /// </summary>
    class Guilde
    {
        // Propriétés privées avec préfixe _ selon la convention du projet
        private string _nom;
        private string _description;
        private DateTime _dateCreation;
        private int _niveauGuilde;
        
        // ===== IMPLÉMENTATION DE LA RELATION ONE-TO-MANY =====
        // Une guilde peut avoir plusieurs membres (one-to-many)
        // Cette liste contient tous les joueurs membres de la guilde
        private List<Joueur> _membres;
        
        // ===== IMPLÉMENTATION DE LA RELATION RÉFLEXIVE =====
        // Une guilde peut avoir plusieurs alliances avec d'autres guildes
        // Cette liste contient toutes les guildes alliées
        private List<Guilde> _alliances;

        // Propriétés publiques
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime DateCreation
        {
            get { return _dateCreation; }
            set { _dateCreation = value; }
        }

        public int NiveauGuilde
        {
            get { return _niveauGuilde; }
            set { _niveauGuilde = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION ONE-TO-MANY =====
        // Cette propriété permet d'accéder à tous les membres de la guilde
        public List<Joueur> Membres
        {
            get { return _membres; }
            set { _membres = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION RÉFLEXIVE =====
        // Cette propriété permet d'accéder à toutes les alliances de la guilde
        public List<Guilde> Alliances
        {
            get { return _alliances; }
            set { _alliances = value; }
        }

        /// <summary>
        /// Constructeur de la classe Guilde
        /// </summary>
        /// <param name="nom">Nom de la guilde</param>
        /// <param name="description">Description de la guilde</param>
        /// <param name="niveauGuilde">Niveau initial de la guilde</param>
        public Guilde(string nom, string description, int niveauGuilde = 1)
        {
            Nom = nom;
            Description = description;
            DateCreation = DateTime.Now;
            NiveauGuilde = niveauGuilde;
            
            // ===== INITIALISATION DES RELATIONS =====
            // Initialisation de la liste des membres (relation one-to-many)
            Membres = new List<Joueur>();
            // Initialisation de la liste des alliances (relation réflexive)
            Alliances = new List<Guilde>();
        }

        /// <summary>
        /// Ajoute un membre à la guilde
        /// </summary>
        /// <param name="joueur">Joueur à ajouter comme membre</param>
        public void AjouterMembre(Joueur joueur)
        {
            if (joueur != null)
            {
                // ===== VÉRIFICATION DE LA CONTRAINTE DE CARDINALITÉ =====
                // Vérifier si le joueur appartient déjà à une guilde
                if (joueur.Guilde != null)
                {
                    // Si le joueur appartient déjà à cette guilde
                    if (joueur.Guilde == this)
                    {
                        Console.WriteLine($"Le joueur '{joueur.Nom}' est déjà membre de la guilde '{Nom}'");
                        return;
                    }
                    // Si le joueur appartient à une autre guilde
                    else
                    {
                        Console.WriteLine($"Le joueur '{joueur.Nom}' doit d'abord quitter sa guilde actuelle '{joueur.Guilde.Nom}'");
                        return;
                    }
                }

                // ===== MAINTIEN DE LA COHÉRENCE BIDIRECTIONNELLE =====
                // Ajout du joueur dans la liste des membres de la guilde
                Membres.Add(joueur);
                // Mise à jour de la référence vers la guilde dans le joueur
                joueur.Guilde = this;
                
                Console.WriteLine($"Le joueur '{joueur.Nom}' a rejoint la guilde '{Nom}'");
            }
        }

        /// <summary>
        /// Retire un membre de la guilde
        /// </summary>
        /// <param name="joueur">Joueur à retirer</param>
        public void RetirerMembre(Joueur joueur)
        {
            if (joueur != null && Membres.Contains(joueur))
            {
                // ===== MAINTIEN DE LA COHÉRENCE BIDIRECTIONNELLE =====
                // Retrait du joueur de la liste des membres
                Membres.Remove(joueur);
                // Mise à jour de la référence vers la guilde dans le joueur
                joueur.Guilde = null;
                
                Console.WriteLine($"Le joueur '{joueur.Nom}' a quitté la guilde '{Nom}'");
            }
            else
            {
                Console.WriteLine($"Le joueur n'est pas membre de la guilde '{Nom}'");
            }
        }

        /// <summary>
        /// Forme une alliance avec une autre guilde
        /// </summary>
        /// <param name="guilde">Guilde avec laquelle former une alliance</param>
        public void FormerAlliance(Guilde guilde)
        {
            if (guilde != null && guilde != this)
            {
                // ===== VÉRIFICATION DE LA RELATION RÉFLEXIVE =====
                // Vérifier si l'alliance n'existe pas déjà
                if (!Alliances.Contains(guilde))
                {
                    // ===== MAINTIEN DE LA COHÉRENCE BIDIRECTIONNELLE =====
                    // Ajout de la guilde dans la liste des alliances
                    Alliances.Add(guilde);
                    // Ajout de cette guilde dans la liste des alliances de l'autre guilde
                    if (!guilde.Alliances.Contains(this))
                    {
                        guilde.Alliances.Add(this);
                    }
                    
                    Console.WriteLine($"Alliance formée entre les guildes '{Nom}' et '{guilde.Nom}'");
                }
                else
                {
                    Console.WriteLine($"Les guildes '{Nom}' et '{guilde.Nom}' sont déjà alliées");
                }
            }
            else if (guilde == this)
            {
                Console.WriteLine("Une guilde ne peut pas former d'alliance avec elle-même");
            }
        }

        /// <summary>
        /// Rompt une alliance avec une autre guilde
        /// </summary>
        /// <param name="guilde">Guilde avec laquelle rompre l'alliance</param>
        public void RompreAlliance(Guilde guilde)
        {
            if (guilde != null && Alliances.Contains(guilde))
            {
                // ===== MAINTIEN DE LA COHÉRENCE BIDIRECTIONNELLE =====
                // Retrait de la guilde de la liste des alliances
                Alliances.Remove(guilde);
                // Retrait de cette guilde de la liste des alliances de l'autre guilde
                if (guilde.Alliances.Contains(this))
                {
                    guilde.Alliances.Remove(this);
                }
                
                Console.WriteLine($"Alliance rompue entre les guildes '{Nom}' et '{guilde.Nom}'");
            }
            else
            {
                Console.WriteLine($"Aucune alliance n'existe entre les guildes '{Nom}' et '{guilde?.Nom}'");
            }
        }

        /// <summary>
        /// Consulte tous les membres de la guilde
        /// </summary>
        public void ConsulterMembres()
        {
            Console.WriteLine($"\n=== Membres de la guilde '{Nom}' ===");
            if (Membres.Count == 0)
            {
                Console.WriteLine("Aucun membre dans cette guilde.");
            }
            else
            {
                // ===== PARCOURS DE LA RELATION ONE-TO-MANY =====
                // Parcours de tous les membres pour les afficher
                foreach (var membre in Membres)
                {
                    Console.WriteLine($"- {membre.Nom} (Niveau {membre.Niveau})");
                }
            }
        }

        /// <summary>
        /// Consulte toutes les alliances de la guilde
        /// </summary>
        public void ConsulterAlliances()
        {
            Console.WriteLine($"\n=== Alliances de la guilde '{Nom}' ===");
            if (Alliances.Count == 0)
            {
                Console.WriteLine("Aucune alliance.");
            }
            else
            {
                // ===== PARCOURS DE LA RELATION RÉFLEXIVE =====
                // Parcours de toutes les alliances pour les afficher
                foreach (var alliance in Alliances)
                {
                    Console.WriteLine($"- {alliance.Nom} (Niveau {alliance.NiveauGuilde})");
                }
            }
        }
    }

    /// <summary>
    /// Classe représentant un joueur dans un jeu multijoueur
    /// </summary>
    class Joueur
    {
        // Propriétés privées avec préfixe _
        private string _nom;
        private int _niveau;
        private DateTime _dateInscription;
        
        // ===== IMPLÉMENTATION DE LA RELATION ONE-TO-MANY =====
        // Un joueur ne peut appartenir qu'à une seule guilde (one-to-many)
        // Cette référence pointe vers la guilde du joueur (ou null si aucune)
        private Guilde _guilde;

        // Propriétés publiques
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int Niveau
        {
            get { return _niveau; }
            set { _niveau = value; }
        }

        public DateTime DateInscription
        {
            get { return _dateInscription; }
            set { _dateInscription = value; }
        }

        // ===== PROPRIÉTÉ POUR ACCÉDER À LA RELATION ONE-TO-MANY =====
        // Cette propriété permet d'accéder à la guilde du joueur
        public Guilde Guilde
        {
            get { return _guilde; }
            set { _guilde = value; }
        }

        /// <summary>
        /// Constructeur de la classe Joueur
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="niveau">Niveau initial du joueur</param>
        public Joueur(string nom, int niveau = 1)
        {
            Nom = nom;
            Niveau = niveau;
            DateInscription = DateTime.Now;
            // Le joueur n'appartient à aucune guilde initialement
            Guilde = null;
        }

        /// <summary>
        /// Permet au joueur de rejoindre une guilde
        /// </summary>
        /// <param name="guilde">Guilde à rejoindre</param>
        public void RejoindreGuilde(Guilde guilde)
        {
            if (guilde != null)
            {
                // ===== DÉLÉGATION DE LA GESTION DE LA RELATION =====
                // Délégation à la méthode AjouterMembre de la guilde
                // qui gère la cohérence bidirectionnelle
                guilde.AjouterMembre(this);
            }
        }

        /// <summary>
        /// Permet au joueur de quitter sa guilde actuelle
        /// </summary>
        public void QuitterGuilde()
        {
            if (Guilde != null)
            {
                // ===== DÉLÉGATION DE LA GESTION DE LA RELATION =====
                // Délégation à la méthode RetirerMembre de la guilde
                // qui gère la cohérence bidirectionnelle
                Guilde guilde = Guilde; // Sauvegarde temporaire de la référence
                guilde.RetirerMembre(this);
            }
            else
            {
                Console.WriteLine($"Le joueur '{Nom}' n'appartient à aucune guilde");
            }
        }

        /// <summary>
        /// Consulte la guilde du joueur
        /// </summary>
        public void ConsulterGuilde()
        {
            Console.WriteLine($"\n=== Guilde de {Nom} ===");
            if (Guilde == null)
            {
                Console.WriteLine("N'appartient à aucune guilde.");
            }
            else
            {
                Console.WriteLine($"Membre de la guilde '{Guilde.Nom}' (Niveau {Guilde.NiveauGuilde})");
                Console.WriteLine($"Description: {Guilde.Description}");
                Console.WriteLine($"Date de création: {Guilde.DateCreation.ToShortDateString()}");
                Console.WriteLine($"Nombre de membres: {Guilde.Membres.Count}");
            }
        }
    }

    /// <summary>
    /// Classe de démonstration pour tester le système de guildes et membres
    /// </summary>
    public static class GuildesExercice3
    {
        public static void Demo()
        {
            Console.WriteLine("=== Système de Guildes et Membres ===\n");

            // Création des guildes
            Guilde guilde1 = new Guilde("Les Chevaliers d'Argent", "Une guilde de guerriers nobles et puissants", 5);
            Guilde guilde2 = new Guilde("Les Mages Écarlates", "Une guilde de mages spécialisés en magie de feu", 4);
            Guilde guilde3 = new Guilde("Les Ombres Silencieuses", "Une guilde d'assassins et d'espions", 3);
            Console.WriteLine("Guildes créées avec succès");

            // Création des joueurs
            Joueur joueur1 = new Joueur("Arthur", 10);
            Joueur joueur2 = new Joueur("Merlin", 15);
            Joueur joueur3 = new Joueur("Morgane", 12);
            Joueur joueur4 = new Joueur("Lancelot", 9);
            Joueur joueur5 = new Joueur("Guenièvre", 8);
            Console.WriteLine("Joueurs créés avec succès");

            // ===== TEST DE LA RELATION ONE-TO-MANY =====
            // Ajout des joueurs aux guildes
            joueur1.RejoindreGuilde(guilde1);
            joueur2.RejoindreGuilde(guilde2);
            joueur3.RejoindreGuilde(guilde3);
            joueur4.RejoindreGuilde(guilde1);
            joueur5.RejoindreGuilde(guilde2);

            // Test de la contrainte de cardinalité (un joueur ne peut être que dans une seule guilde)
            joueur1.RejoindreGuilde(guilde2); // Devrait échouer car déjà dans guilde1

            // ===== TEST DE LA RELATION RÉFLEXIVE =====
            // Formation d'alliances entre guildes
            guilde1.FormerAlliance(guilde2);
            guilde2.FormerAlliance(guilde3);
            
            // Test de la cohérence bidirectionnelle des alliances
            guilde1.ConsulterAlliances(); // Devrait montrer guilde2
            guilde2.ConsulterAlliances(); // Devrait montrer guilde1 et guilde3
            
            // Test de l'impossibilité d'alliance avec soi-même
            guilde1.FormerAlliance(guilde1); // Devrait échouer

            // Consultation des membres de chaque guilde
            guilde1.ConsulterMembres();
            guilde2.ConsulterMembres();
            guilde3.ConsulterMembres();

            // Test du changement de guilde
            Console.WriteLine("\n=== Test de changement de guilde ===");
            joueur4.ConsulterGuilde(); // Actuellement dans guilde1
            joueur4.RejoindreGuilde(guilde3); // Changement de guilde
            joueur4.ConsulterGuilde(); // Maintenant dans guilde3
            
            // Vérification de la mise à jour des listes de membres
            guilde1.ConsulterMembres(); // Ne devrait plus avoir joueur4
            guilde3.ConsulterMembres(); // Devrait maintenant avoir joueur4

            // Test de rupture d'alliance
            Console.WriteLine("\n=== Test de rupture d'alliance ===");
            guilde1.RompreAlliance(guilde2);
            
            // Vérification de la cohérence bidirectionnelle après rupture
            guilde1.ConsulterAlliances(); // Ne devrait plus avoir guilde2
            guilde2.ConsulterAlliances(); // Ne devrait plus avoir guilde1, mais toujours guilde3

            Console.WriteLine("\nDémonstration terminée!");
        }
    }
}
