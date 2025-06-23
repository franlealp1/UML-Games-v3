using System.Runtime.ExceptionServices;
using System.Security;
using Internal;

namespace CoursUML;


class Personnage {
    // proprietés
    private int _hp;
    private string _nom;
    

    public int hp {
        get {
            return _hp;
        }
        set {
            _hp = value;
        }

    }

    public int nom {
        get {
            return _nom;
        }
        set {
            _nom = value;
        }

    }


    // méthodes
    public Personnage (int hp, int nom){
        Hp = hp;
        Nom = nom;
    }

    public void Attaquer (){
        Console.WriteLine ("On attaque!!");
    }
    public void SeDeplacer(int posX, int posY){
        Console.WriteLine ($"On se deplace vers {posX}, {posY}");
    }


}