using System;

namespace Heritage {
    public abstract class AnimalDomestique {

        public int _stamina;
        public int Stamina {
            get {
                return _stamina;
            }
            set {
                _stamina = value;
            }
        }

        public void seDeplacer (){
            Console.WriteLine ("Je suis un animal domestique, je bouge!!");
            Console.WriteLine ("Concretement je suis un ");
            Console.WriteLine (this.GetType().Name);
        }

        public abstract void manger ();
    }


}