using System;
using System.Collections.Generic;

namespace Chapitre2
{
    public class Event
    {
        private string name;
        private string type;
        private List<Participation> participants;

        public Event(string name, string type)
        {
            this.name = name;
            this.type = type;
            this.participants = new List<Participation>();
        }

        public void AddParticipant(Participation participation)
        {
            if (participation != null && !participants.Contains(participation))
            {
                participants.Add(participation);
            }
        }

        public string GetName() => name;
        public string GetType() => type;
        public List<Participation> GetParticipants() => new List<Participation>(participants);
    }
} 