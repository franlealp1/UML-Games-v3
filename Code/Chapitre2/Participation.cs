using System;

namespace Chapitre2
{
    public class Participation
    {
        private Mii mii;
        private Event evt;
        private double time;
        private int position;
        private bool qualified;

        public Participation(Mii mii, Event evt)
        {
            this.mii = mii;
            this.evt = evt;
            this.time = 0;
            this.position = 0;
            this.qualified = false;
        }

        public void SetResult(double time, int position, bool qualified)
        {
            this.time = time;
            this.position = position;
            this.qualified = qualified;
        }

        public Mii GetMii() => mii;
        public Event GetEvent() => evt;
        public double GetTime() => time;
        public int GetPosition() => position;
        public bool IsQualified() => qualified;
    }
} 