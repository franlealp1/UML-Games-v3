using System;


namespace Toto;

public class Weapon {
    private string name;
    private int damage;

    public Weapon (string name, int damage){
        this.name = name;
        this.damage = damage;
    }


    public void Use(){
        Console.WriteLine ($"on utilise le {name}");
    }

}

