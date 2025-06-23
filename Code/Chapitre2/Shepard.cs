using System;
using System.Collections.Generic;

namespace Chapitre2
{
    public class Shepard
    {
        private string name;
        private int level;
        private List<Mission> missions;

        public Shepard(string name)
        {
            this.name = name;
            this.level = 1;
            this.missions = new List<Mission>();
        }

        public void AcceptMission(Mission mission)
        {
            if (mission != null && !missions.Contains(mission))
            {
                missions.Add(mission);
                mission.SetShepard(this);
                Console.WriteLine($"{name} a accepté la mission : {mission.GetTitle()}");
            }
        }

        public void CompleteMission(Mission mission)
        {
            if (missions.Contains(mission))
            {
                var rewards = mission.GetRewards();
                Console.WriteLine($"{name} a terminé la mission : {mission.GetTitle()}");
                Console.WriteLine("Récompenses reçues :");
                foreach (var reward in rewards)
                {
                    Console.WriteLine($"- {reward.GetName()}: {reward.GetValue()}");
                }
                missions.Remove(mission);
            }
        }

        public List<Mission> GetMissions() => new List<Mission>(missions);
        public string GetName() => name;
        public int GetLevel() => level;
    }
} 