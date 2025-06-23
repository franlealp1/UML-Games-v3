using System;
using System.Collections.Generic;

namespace Chapitre2
{
    public class Mission
    {
        private string title;
        private string description;
        private Shepard shepard;
        private List<Reward> rewards;

        public Mission(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.rewards = new List<Reward>();
        }

        public void AddReward(Reward reward)
        {
            if (reward != null && !rewards.Contains(reward))
            {
                rewards.Add(reward);
            }
        }

        public void SetShepard(Shepard shepard)
        {
            this.shepard = shepard;
        }

        public string GetTitle() => title;
        public string GetDescription() => description;
        public Shepard GetShepard() => shepard;
        public List<Reward> GetRewards() => new List<Reward>(rewards);
    }
} 