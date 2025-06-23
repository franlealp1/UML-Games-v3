using System;

namespace Chapitre2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Chapitre 2 : Relations entre Classes ===");
            
            // Test Mass Effect
            Console.WriteLine("\n--- Test Mass Effect ---");
            Shepard shepard = new Shepard("Commander Shepard");
            
            Mission mission1 = new Mission("Rescatar colonos", "Salvar a los colonos de los ataques");
            mission1.AddReward(new Reward("Crédits", 5000, "Monnaie"));
            mission1.AddReward(new Reward("XP", 100, "Expérience"));
            
            shepard.AcceptMission(mission1);
            shepard.CompleteMission(mission1);
            
            // Test Wii Sports
            Console.WriteLine("\n--- Test Wii Sports ---");
            Mii mii1 = new Mii("Mon Mii");
            Event event1 = new Event("100m", "Course");
            
            mii1.RegisterForEvent(event1);
            mii1.RecordResult(event1, 12.5, 3, true);
        }
    }
} 