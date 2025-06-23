using System;
using System.Collections.Generic;


namespace Toto;

class Perso {
    private string name;
    private Weapon? weapon;

    public Perso (string name){
        this.name = name;
        this.weapon = null;
    }

    public void Equiper (Weapon weapon){
        this.weapon = weapon;
    } 

    public void Attack (){
        this.weapon.Use();
    }
}