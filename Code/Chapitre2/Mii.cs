using System;
using System.Collections.Generic;

namespace Chapitre2
{
    public class Mii
    {
        private string name;
        private List<Participation> participations;

        public Mii(string name)
        {
            this.name = name;
            this.participations = new List<Participation>();
        }

        public void RegisterForEvent(Event evt)
        {
            if (evt != null)
            {
                var participation = new Participation(this, evt);
                participations.Add(participation);
                evt.AddParticipant(participation);
                Console.WriteLine($"{name} s'est inscrit à l'épreuve : {evt.GetName()}");
            }
        }

        public void RecordResult(Event evt, double time, int position, bool qualified)
        {
            var participation = participations.Find(p => p.GetEvent() == evt);
            if (participation != null)
            {
                participation.SetResult(time, position, qualified);
                Console.WriteLine($"{name} - {evt.GetName()}: Temps {time}s, Position {position}, Qualifié: {qualified}");
            }
        }

        public List<Participation> GetParticipations() => new List<Participation>(participations);
        public string GetName() => name;
    }
} 