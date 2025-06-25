using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursUML.Chapitre3.Exercice1
{
    /// <summary>
    /// Classe de démonstration pour le système de gestion d'aéroline
    /// </summary>
    public class AerolineDemo
    {
        /// <summary>
        /// Méthode principale de démonstration
        /// </summary>
        public static void Demo()
        {
            Console.WriteLine("=== DÉMONSTRATION DU SYSTÈME DE GESTION D'AÉROLINE ===\n");
            
            // Création d'une aéroline
            Console.WriteLine("1. Création d'une aéroline");
            Aeroline airFrance = new Aeroline("Air France", "AF", 1000000);
            Console.WriteLine($"Aéroline créée : {airFrance.Nom} ({airFrance.CodeIATA})\n");
            
            // Création d'aéroports
            Console.WriteLine("2. Création d'aéroports");
            Aeroport cdg = new Aeroport("Charles de Gaulle", "CDG", "Paris", "France", 4);
            Aeroport jfk = new Aeroport("John F. Kennedy", "JFK", "New York", "États-Unis", 6);
            Aeroport nrt = new Aeroport("Narita", "NRT", "Tokyo", "Japon", 3);
            Console.WriteLine($"Aéroports créés : {cdg.Nom} ({cdg.CodeIATA}), {jfk.Nom} ({jfk.CodeIATA}), {nrt.Nom} ({nrt.CodeIATA})\n");
            
            // Création d'avions
            Console.WriteLine("3. Création d'avions");
            Avion a320 = new Avion("F-GKXL", "Airbus A320", 180, 6000);
            Avion b777 = new Avion("F-GSPS", "Boeing 777-300ER", 350, 12000);
            Console.WriteLine($"Avions créés : {a320.Immatriculation} ({a320.Modele}), {b777.Immatriculation} ({b777.Modele})\n");
            
            // Ajout d'équipements aux avions (relation de composition)
            Console.WriteLine("4. Ajout d'équipements aux avions (démonstration de la relation de composition)");
            Equipement gps1 = new Equipement("GPS", "GPS-123456");
            Equipement radar1 = new Equipement("Radar", "RDR-789012");
            a320.AjouterEquipement(gps1);
            a320.AjouterEquipement(radar1);
            
            Equipement gps2 = new Equipement("GPS", "GPS-654321");
            Equipement radar2 = new Equipement("Radar", "RDR-210987");
            b777.AjouterEquipement(gps2);
            b777.AjouterEquipement(radar2);
            Console.WriteLine();
            
            // Ajout des avions à l'aéroline (relation d'agrégation)
            Console.WriteLine("5. Ajout des avions à l'aéroline (démonstration de la relation d'agrégation)");
            airFrance.AjouterAvion(a320);
            airFrance.AjouterAvion(b777);
            Console.WriteLine($"L'aéroline {airFrance.Nom} possède maintenant {airFrance.Avions.Count} avions\n");
            
            // Création de pilotes
            Console.WriteLine("6. Création de pilotes");
            Pilote pilote1 = new Pilote("Jean Dupont", "P-12345", 5000);
            Pilote pilote2 = new Pilote("Marie Martin", "P-67890", 8000);
            Console.WriteLine($"Pilotes créés : {pilote1.Nom} ({pilote1.Licence}), {pilote2.Nom} ({pilote2.Licence})\n");
            
            // Ajout des qualifications aux pilotes (relation many-to-many)
            Console.WriteLine("7. Ajout des qualifications aux pilotes (démonstration de la relation many-to-many)");
            pilote1.AjouterQualification(a320);
            pilote2.AjouterQualification(a320);
            pilote2.AjouterQualification(b777);
            Console.WriteLine();
            
            // Ajout des pilotes à l'aéroline (relation d'agrégation)
            Console.WriteLine("8. Ajout des pilotes à l'aéroline (démonstration de la relation d'agrégation)");
            airFrance.EngagerPilote(pilote1);
            airFrance.EngagerPilote(pilote2);
            Console.WriteLine($"L'aéroline {airFrance.Nom} emploie maintenant {airFrance.Pilotes.Count} pilotes\n");
            
            // Création de routes (relation d'association)
            Console.WriteLine("9. Création de routes (démonstration de la relation d'association)");
            Route routeParisTokyo = new Route("AF-CDG-NRT", cdg, nrt, 9700);
            Route routeParisNY = new Route("AF-CDG-JFK", cdg, jfk, 5800);
            Console.WriteLine($"Routes créées : {routeParisTokyo.CodeRoute} ({routeParisTokyo.DistanceKm} km), {routeParisNY.CodeRoute} ({routeParisNY.DistanceKm} km)\n");
            
            // Ajout des routes à l'aéroline (relation d'agrégation)
            Console.WriteLine("10. Ajout des routes à l'aéroline (démonstration de la relation d'agrégation)");
            airFrance.AjouterRoute(routeParisTokyo);
            airFrance.AjouterRoute(routeParisNY);
            Console.WriteLine($"L'aéroline {airFrance.Nom} gère maintenant {airFrance.Routes.Count} routes\n");
            
            // Création de vols
            Console.WriteLine("11. Création de vols");
            Vol volParisTokyo = new Vol("AF-276", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(12), routeParisTokyo, b777);
            Vol volParisNY = new Vol("AF-022", DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(8), routeParisNY, a320);
            Console.WriteLine($"Vols créés : {volParisTokyo.NumeroVol}, {volParisNY.NumeroVol}\n");
            
            // Ajout des vols à l'aéroline (relation d'association)
            Console.WriteLine("12. Ajout des vols à l'aéroline (démonstration de la relation d'association)");
            airFrance.PlanifierVol(volParisTokyo);
            airFrance.PlanifierVol(volParisNY);
            Console.WriteLine($"L'aéroline {airFrance.Nom} opère maintenant {airFrance.Vols.Count} vols\n");
            
            // Création de passagers
            Console.WriteLine("13. Création de passagers");
            Passager passager1 = new Passager("Pierre Durand", "FR123456");
            Passager passager2 = new Passager("Sophie Lefebvre", "FR789012");
            Console.WriteLine($"Passagers créés : {passager1.Nom} ({passager1.Passeport}), {passager2.Nom} ({passager2.Passeport})\n");
            
            // Réservation de vols par les passagers (relation d'association et de composition)
            Console.WriteLine("14. Réservation de vols par les passagers (démonstration des relations d'association et de composition)");
            Reservation res1 = passager1.ReserverVol(volParisTokyo, "Affaires");
            Reservation res2 = passager2.ReserverVol(volParisTokyo, "Économique");
            Reservation res3 = passager1.ReserverVol(volParisNY, "Première");
            Console.WriteLine($"Le vol {volParisTokyo.NumeroVol} a {volParisTokyo.Reservations.Count} réservations");
            Console.WriteLine($"Le vol {volParisNY.NumeroVol} a {volParisNY.Reservations.Count} réservations\n");
            
            // Démonstration de la maintenance d'un avion (relation d'association)
            Console.WriteLine("15. Démonstration de la maintenance d'un avion (relation d'association)");
            a320.EffectuerMaintenance();
            Console.WriteLine($"L'avion {a320.Immatriculation} a {a320.Maintenances.Count} maintenance(s) dans son historique\n");
            
            // Démonstration du transfert d'un avion (vente) - question de réflexion 1
            Console.WriteLine("16. Démonstration du transfert d'un avion (vente) - question de réflexion 1");
            Aeroline lufthansa = new Aeroline("Lufthansa", "LH", 900000);
            Console.WriteLine($"Nouvelle aéroline créée : {lufthansa.Nom} ({lufthansa.CodeIATA})");
            
            Console.WriteLine($"Avant transfert : {airFrance.Nom} possède {airFrance.Avions.Count} avions");
            airFrance.RetirerAvion(a320);
            lufthansa.AjouterAvion(a320);
            Console.WriteLine($"Après transfert : {airFrance.Nom} possède {airFrance.Avions.Count} avions et {lufthansa.Nom} possède {lufthansa.Avions.Count} avions");
            Console.WriteLine($"Les équipements restent avec l'avion : {a320.Immatriculation} a {a320.Equipements.Count} équipements\n");
            
            // Démonstration de l'annulation d'un vol
            Console.WriteLine("17. Démonstration de l'annulation d'un vol");
            airFrance.AnnulerVol(volParisNY);
            Console.WriteLine($"Statut du vol {volParisNY.NumeroVol} : {volParisNY.Statut}\n");
            
            Console.WriteLine("=== FIN DE LA DÉMONSTRATION ===");
        }
    }
}
