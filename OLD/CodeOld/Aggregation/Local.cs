using System;
using System.Collections.Generic;

namespace Aggregation
{
    public class Local
    {
        public string _nom;
        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
            }
        }
        public List<PC> listePC;
        public VideoProjecteur videoProj;

        // injection de dépendances dans le constructeur
        public Local(VideoProjecteur videoProj, List<PC> listePC)
        {
            this.listePC = listePC;
            this.videoProj = videoProj;
        }

        public void afficherPCs (){
            Console.WriteLine ("Contenu des PCs du Local :");
            foreach (PC pc in listePC){
                Console.WriteLine (pc.Code);
            }
        }

    }

}