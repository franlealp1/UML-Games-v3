using System;

namespace Chapitre2
{
    public class Reward
    {
        private string name;
        private int value;
        private string type;

        public Reward(string name, int value, string type)
        {
            this.name = name;
            this.value = value;
            this.type = type;
        }

        public string GetName() => name;
        public int GetValue() => value;
        public string GetType() => type;

        public override string ToString()
        {
            return $"{name} ({type}): {value}";
        }
    }
} 