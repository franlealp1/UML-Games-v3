using System;
using System.Reflection.PortableExecutable;

namespace CoursUML
{
    class Program
    {
        static void Main(string[] args)
        {

            Character gaelle = new Character("Gaelle", 100);
            Character irene = new Character("Irene", 120);

            Skill alchemie = new Skill("alchemie", "magie", 56);
            Skill transformation = new Skill("transformer en pièrre", "magie");

            gaelle.AddSkill(alchemie);
            gaelle.AddSkill(transformation);

            irene.AddSkill(transformation);





        }

    }

}