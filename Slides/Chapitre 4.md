# Chapitre 4 : Héritage - Résoudre les Vrais Problèmes

## Objectifs
- Comprendre **pourquoi** l'héritage existe
- Identifier les **problèmes** que chaque concept résout
- Modéliser des solutions **pratiques** aux défis du développement
- Utiliser le polymorphisme pour **simplifier** le code

---

## Le Problème : Duplication de Code

### 🚨 Situation Réelle
Imaginez que vous développez un jeu avec 3 types de personnages : Guerrier, Mage, et Rôdeur. Chaque type a des comportements différents, mais partagent des caractéristiques communes.

**Sans héritage** (approche naïve) :
```csharp
public class Guerrier
{
    private string nom;
    private int niveau;
    private int pointsDeVie;
    private int pointsDeMana;
    private int force;  // Spécifique au guerrier
    
    public void Attaquer() { /* logique spécifique */ }
    public void SeDefendre() { /* logique commune */ }
    public void UtiliserCompetence() { /* logique commune */ }
}

public class Mage
{
    private string nom;        // ❌ DUPLICATION
    private int niveau;        // ❌ DUPLICATION  
    private int pointsDeVie;   // ❌ DUPLICATION
    private int pointsDeMana;  // ❌ DUPLICATION
    private int intelligence;  // Spécifique au mage
    
    public void Attaquer() { /* logique spécifique */ }
    public void SeDefendre() { /* logique commune */ }  // ❌ DUPLICATION
    public void UtiliserCompetence() { /* logique commune */ }  // ❌ DUPLICATION
}
```

### 💡 Le Problème
- **Duplication massive** de code
- **Maintenance difficile** : changer une logique commune = modifier 3 classes
- **Incohérences** : oublier de modifier une classe
- **Code verbeux** et répétitif

---

## La Solution : Héritage

### 🎯 Qu'est-ce que l'Héritage ?
L'héritage permet à une classe **fille** d'hériter des attributs et méthodes d'une classe **mère**, **résolvant** le problème de duplication.

### ✅ Avec Héritage
```csharp
public class Personnage  // Classe mère
{
    protected string nom;        // ✅ PARTAGÉ
    protected int niveau;        // ✅ PARTAGÉ
    protected int pointsDeVie;   // ✅ PARTAGÉ
    protected int pointsDeMana;  // ✅ PARTAGÉ
    
    public virtual void Attaquer() { /* logique commune */ }
    public virtual void SeDefendre() { /* logique commune */ }  // ✅ PARTAGÉ
    public virtual void UtiliserCompetence() { /* logique commune */ }  // ✅ PARTAGÉ
}

public class Guerrier : Personnage  // Classe fille
{
    private int force;  // Spécifique au guerrier
    
    public override void Attaquer() { /* logique spécifique */ }
    // SeDefendre() et UtiliserCompetence() hérités automatiquement
}
```

### 🏆 Avantages Immédiats
- **DRY** (Don't Repeat Yourself) : Plus de duplication
- **Maintenance centralisée** : Un seul endroit à modifier
- **Cohérence garantie** : Tous les personnages ont le même comportement de base
- **Code plus court** et lisible

---

## Le Problème : Rigidité du Code

### 🚨 Situation Réelle
Vous avez une liste de personnages et vous voulez que chacun attaque selon sa spécialité :

```csharp
// ❌ APPROCHE RIGIDE - Code qui casse facilement
List<Guerrier> guerriers = new List<Guerrier>();
List<Mage> mages = new List<Mage>();
List<Rodeur> rodeurs = new List<Rodeur>();

// Pour faire attaquer tous les personnages :
foreach (var guerrier in guerriers) guerrier.Attaquer();
foreach (var mage in mages) mage.Attaquer();
foreach (var rodeur in rodeurs) rodeur.Attaquer();

// ❌ PROBLÈME : Si j'ajoute un nouveau type, je dois modifier ce code !
```

### 💡 Le Problème
- **Code rigide** : ne s'adapte pas aux nouveaux types
- **Violation du principe ouvert/fermé** : ouvert à l'extension, fermé à la modification
- **Maintenance coûteuse** : chaque nouveau type = modification du code existant

---

## La Solution : Polymorphisme

### 🎯 Qu'est-ce que le Polymorphisme ?
Le polymorphisme permet d'utiliser une classe fille **partout où** une classe mère est attendue, **résolvant** le problème de rigidité.

### ✅ Avec Polymorphisme
```csharp
// ✅ APPROCHE FLEXIBLE - Code qui s'adapte automatiquement
List<Personnage> personnages = new List<Personnage>();
personnages.Add(new Guerrier());
personnages.Add(new Mage());
personnages.Add(new Rodeur());

// Un seul code pour tous les types !
foreach (Personnage p in personnages)
{
    p.Attaquer(); // ✅ Chaque type utilise sa propre implémentation
}

// ✅ AVANTAGE : Si j'ajoute un nouveau type, ce code ne change pas !
personnages.Add(new Paladin()); // Fonctionne automatiquement
```

### 🏆 Avantages Immédiats
- **Code flexible** : s'adapte automatiquement aux nouveaux types
- **Principe ouvert/fermé** respecté
- **Maintenance réduite** : pas de modification du code existant
- **Extensibilité** naturelle

---

## Le Problème : Méthodes qui ne font rien

### 🚨 Situation Réelle
Vous voulez forcer les classes filles à implémenter certaines méthodes, mais la classe mère ne peut pas fournir une implémentation par défaut :

```csharp
public class Personnage
{
    // ❌ PROBLÈME : Cette méthode n'a pas de sens pour Personnage
    public void Attaquer() 
    { 
        // Que mettre ici ? Rien de logique !
        Console.WriteLine("Attaque générique..."); 
    }
}

public class Guerrier : Personnage
{
    public override void Attaquer() 
    { 
        Console.WriteLine("Le guerrier charge avec son épée !"); 
    }
}

public class Mage : Personnage
{
    // ❌ PROBLÈME : Le mage pourrait oublier d'override et utiliser l'implémentation vide
    // public override void Attaquer() { /* oublié ! */ }
}
```

### 💡 Le Problème
- **Méthodes vides** sans sens dans la classe mère
- **Oublis dangereux** : une classe fille peut oublier d'implémenter
- **Comportement incohérent** : méthode générique appelée par erreur

---

## La Solution : Classes Abstraites

### 🎯 Qu'est-ce qu'une Classe Abstraite ?
Une classe abstraite **force** les classes filles à implémenter certaines méthodes, **résolvant** le problème des méthodes vides.

### ✅ Avec Classes Abstraites
```csharp
public abstract class Personnage  // ✅ ABSTRACT = ne peut pas être instanciée
{
    protected string nom;
    protected int niveau;
    
    public abstract void Attaquer();  // ✅ ABSTRACT = doit être implémentée
    public abstract void SeDefendre(); // ✅ ABSTRACT = doit être implémentée
    
    // ✅ Méthodes concrètes pour la logique commune
    public void GagnerNiveau() { niveau++; }
    public string GetNom() { return nom; }
}

public class Guerrier : Personnage
{
    // ✅ OBLIGATOIRE : Le compilateur force l'implémentation
    public override void Attaquer() 
    { 
        Console.WriteLine("Le guerrier charge avec son épée !"); 
    }
    
    public override void SeDefendre() 
    { 
        Console.WriteLine("Le guerrier lève son bouclier !"); 
    }
}

// ❌ ERREUR DE COMPILATION si on oublie d'implémenter une méthode abstraite
```

### 🏆 Avantages Immédiats
- **Sécurité** : impossible d'oublier d'implémenter
- **Clarté** : la classe mère définit le contrat
- **Cohérence** : toutes les classes filles ont les mêmes méthodes
- **Pas de méthodes vides** inutiles

---

## Le Problème : Comportements par Défaut

### 🚨 Situation Réelle
Vous voulez que certaines méthodes aient un comportement par défaut, mais que les classes filles puissent les personnaliser si nécessaire :

```csharp
public abstract class Personnage
{
    public abstract void Attaquer();  // ❌ PROBLÈME : Toujours obligatoire
    
    // ❌ PROBLÈME : Si on veut un comportement par défaut, on ne peut pas
    public abstract void SeDefendre(); 
}

public class Guerrier : Personnage
{
    public override void Attaquer() { /* logique spécifique */ }
    public override void SeDefendre() { /* logique spécifique */ }
}

public class Mage : Personnage
{
    public override void Attaquer() { /* logique spécifique */ }
    public override void SeDefendre() { /* logique par défaut - répétition ! */ }
}
```

### 💡 Le Problème
- **Pas de comportement par défaut** possible avec abstract
- **Duplication** si plusieurs classes veulent le même comportement
- **Flexibilité limitée** : tout ou rien

---

## La Solution : Méthodes Virtuelles

### 🎯 Qu'est-ce qu'une Méthode Virtuelle ?
Une méthode virtuelle fournit un **comportement par défaut** que les classes filles peuvent **optionnellement** redéfinir.

### ✅ Avec Méthodes Virtuelles
```csharp
public class Personnage
{
    public virtual void Attaquer() 
    { 
        Console.WriteLine("Attaque de base");  // ✅ COMPORTEMENT PAR DÉFAUT
    }
    
    public virtual void SeDefendre() 
    { 
        Console.WriteLine("Défense de base");  // ✅ COMPORTEMENT PAR DÉFAUT
    }
}

public class Guerrier : Personnage
{
    public override void Attaquer() 
    { 
        Console.WriteLine("Le guerrier charge !");  // ✅ PERSONNALISATION
    }
    // ✅ SeDefendre() utilise le comportement par défaut automatiquement
}

public class Mage : Personnage
{
    public override void Attaquer() 
    { 
        Console.WriteLine("Le mage lance un sort !");  // ✅ PERSONNALISATION
    }
    // ✅ SeDefendre() utilise le comportement par défaut automatiquement
}
```

### 🏆 Avantages Immédiats
- **Flexibilité** : comportement par défaut + personnalisation optionnelle
- **DRY** : pas de duplication du comportement par défaut
- **Simplicité** : les classes filles n'implémentent que ce qui change
- **Évolution** : facile d'ajouter de nouveaux comportements

---

## 🎯 Classe Abstraite vs Méthodes Virtuelles : Quand Utiliser Chaque Approche

### 🚨 Le Problème de Confusion
Beaucoup de développeurs confondent `abstract` et `virtual`. Voici quand utiliser chaque approche :

### 📋 Règles de Décision

| Situation | Utiliser | Pourquoi |
|-----------|----------|----------|
| **La classe mère peut implémenter** | `virtual` | Comportement par défaut logique |
| **La classe mère ne peut pas implémenter** | `abstract` | Pas de sens par défaut |
| **Toutes les classes filles doivent implémenter** | `abstract` | Obligation absolue |
| **Certaines classes filles peuvent utiliser le défaut** | `virtual` | Flexibilité |

### 🔍 Exemples Concrets

#### ❌ MAUVAIS : Abstract quand Virtual serait mieux 

Ex: on va considérer ici que le Guerrier et l'Amazone se defendent avec un bouclier

```csharp
public abstract class Personnage
{
    public abstract void SeDefendre();  // ❌ MAUVAIS : La défense a un sens par défaut
}

public class Guerrier : Personnage
{
    public override void SeDefendre() 
    { 
        Console.WriteLine("Lève son bouclier"); 
    }
}

public class Amazone : Personnage
{
    public override void SeDefendre() 
    { 
        Console.WriteLine("Lève son bouclier");  // ❌ DUPLICATION !
    }
}
```

#### ✅ BON : Virtual pour comportement par défaut

Ex: on veut un coportement par défaut pour plusieurs classes filles. Certaines le personnaliseront mais en géneral le comportement est le même

```csharp
public class Personnage
{
    public virtual void SeDefendre() 
    { 
        Console.WriteLine("Lève son bouclier");  // ✅ COMPORTEMENT PAR DÉFAUT
    }
}

public class Guerrier : Personnage
{
    // ✅ Hérite automatiquement du comportement par défaut
}

public class Amazone : Personnage
{
    public override void SeDefendre() 
    { 
        Console.WriteLine("Crée un bouclier magique");  // ✅ PERSONNALISATION
    }
}

public class Paladin : Personnage
{
    // ✅ Hérite automatiquement du comportement par défaut
    // Pas besoin de redéfinir SeDefendre() - utilise "Lève son bouclier"
}
```

#### ❌ MAUVAIS : Virtual quand Abstract serait mieux
```csharp
public class Personnage
{
    public virtual void Attaquer() 
    { 
        Console.WriteLine("Attaque générique...");  // ❌ MAUVAIS : N'a pas de sens du tout! :D
    }
}

public class Guerrier : Personnage
{
    public override void Attaquer() 
    { 
        Console.WriteLine("Charge avec son épée"); 
    }
}

public class Mage : Personnage
{
    // ❌ DANGER : Oublie d'override et utilise l'attaque générique !
}
```

#### ✅ BON : Abstract pour obligation absolue

Ex: on ne veut pas définir un comportement par défaut pour la classe de base car ce ne fait pas du sens... alors on est obligé d'implementer la méthode pour toutes les filles


```csharp
public abstract class Personnage
{
    public abstract void Attaquer();  // ✅ OBLIGATOIRE
}

public class Guerrier : Personnage
{
    public override void Attaquer() 
    { 
        Console.WriteLine("Charge avec son épée"); 
    }
}

public class Mage : Personnage
{
    public override void Attaquer() 
    { 
        Console.WriteLine("Lance un sort"); 
    }
    // ✅ ERREUR DE COMPILATION si on oublie !
}
```

### 🎯 Cas d'Usage Pratiques

#### 🎮 Cas 1 : Système de Compétences
```csharp
public abstract class Competence
{
    protected string nom;
    protected int coutMana;
    
    // ✅ ABSTRACT : Chaque compétence doit avoir sa propre logique
    public abstract void Executer();
    
    // ✅ VIRTUAL : Comportement par défaut logique
    public virtual bool PeutEtreUtilisee(int manaActuel)
    {
        return manaActuel >= coutMana;
    }
}

public class CompetenceAttaque : Competence
{
    private int degats;
    
    public override void Executer() 
    { 
        Console.WriteLine($"Inflige {degats} dégâts"); 
    }
    // ✅ PeutEtreUtilisee() héritée automatiquement
}

public class CompetenceSoin : Competence
{
    private int pointsSoin;
    
    public override void Executer() 
    { 
        Console.WriteLine($"Soigne {pointsSoin} points de vie"); 
    }
    
    public override bool PeutEtreUtilisee(int manaActuel)
    {
        // ✅ PERSONNALISATION : Soin nécessite plus de mana
        return manaActuel >= coutMana + 5;
    }
}
```

#### 🎮 Cas 2 : Système d'Ennemis
```csharp
public abstract class Ennemi
{
    protected string nom;
    protected int pointsDeVie;
    
    // ✅ ABSTRACT : Chaque ennemi doit définir son attaque
    public abstract void Attaquer();
    
    // ✅ ABSTRACT : Chaque ennemi doit définir sa mort
    public abstract void Mourir();
    
    // ✅ VIRTUAL : Logique commune pour recevoir des dégâts
    public virtual void RecevoirDegats(int degats)
    {
        pointsDeVie -= degats;
        if (pointsDeVie <= 0) Mourir();
    }
}
```

### Résumé des Avantages

#### ✅ Avantages des Classes Abstraites
- **Sécurité absolue** : Impossible d'oublier d'implémenter
- **Clarté du contrat** : La classe mère définit exactement ce qui doit être fait
- **Pas de comportements vides** : Évite les méthodes sans sens
- **Cohérence garantie** : Toutes les classes filles ont les mêmes méthodes

#### ✅ Avantages des Méthodes Virtuelles
- **Flexibilité maximale** : Comportement par défaut + personnalisation optionnelle
- **DRY** : Pas de duplication du comportement commun si plusieurs filles implementent une même méthode exactement de la même manière
- **Évolution facile** : Ajouter de nouveaux types sans modifier le code existant
- **Simplicité** : Les classes filles n'implémentent que ce qui change

### 🎯 Règle d'Or
**"Si la classe mère peut fournir une implémentation logique → `virtual`**
**Si la classe mère ne peut pas implémenter → `abstract`"**

---

## Exemple Pratique : Système de Combat

### 🎮 Contexte Réel
Dans un RPG, vous avez différents types d'ennemis qui combattent différemment, mais partagent des comportements communs.

### 🚨 Problèmes à Résoudre
1. **Duplication** : tous les ennemis ont des points de vie, un nom, etc.
2. **Rigidité** : code qui ne s'adapte pas aux nouveaux types d'ennemis
3. **Méthodes vides** : comportements qui n'ont pas de sens par défaut
4. **Comportements par défaut** : certains ennemis partagent des comportements

### ✅ Solution Complète
```csharp
public abstract class Ennemi
{
    protected string nom;
    protected int pointsDeVie;
    
    // ✅ ABSTRACT : Comportements obligatoires sans sens par défaut
    public abstract void Attaquer();
    public abstract void Mourir();
    
    // ✅ VIRTUAL : Comportements avec logique par défaut
    public virtual void SeDefendre() 
    { 
        Console.WriteLine($"{nom} se défend"); 
    }
    
    public virtual void RecevoirDegats(int degats) 
    { 
        pointsDeVie -= degats;
        if (pointsDeVie <= 0) Mourir();
    }
}

public class Gobelin : Ennemi
{
    public override void Attaquer() 
    { 
        Console.WriteLine("Le gobelin attaque rapidement !"); 
    }
    
    public override void Mourir() 
    { 
        Console.WriteLine("Le gobelin s'effondre !"); 
    }
    
    // ✅ SeDefendre() et RecevoirDegats() hérités automatiquement
}

public class Troll : Ennemi
{
    public override void Attaquer() 
    { 
        Console.WriteLine("Le troll frappe violemment !"); 
    }
    
    public override void Mourir() 
    { 
        Console.WriteLine("Le troll s'effondre lentement !"); 
    }
    
    public override void SeDefendre() 
    { 
        Console.WriteLine("Le troll lève ses bras pour se protéger !"); 
    }
    // ✅ RecevoirDegats() hérité automatiquement
}
```

### 🎯 Utilisation Polymorphique
```csharp
List<Ennemi> ennemis = new List<Ennemi>();
ennemis.Add(new Gobelin());
ennemis.Add(new Troll());

// ✅ Code flexible qui s'adapte automatiquement
foreach (Ennemi ennemi in ennemis)
{
    ennemi.Attaquer();  // Chaque type utilise sa propre implémentation
    ennemi.SeDefendre(); // Troll personnalise, Gobelin utilise le défaut
}
```

---

## Résumé : Problèmes et Solutions

### 🔧 Outils et Leurs Problèmes Résolus

| Concept | Problème Résolu | Quand l'Utiliser |
|---------|----------------|------------------|
| **Héritage** | Duplication de code | Classes qui partagent des caractéristiques |
| **Polymorphisme** | Code rigide | Traiter différents types de manière uniforme |
| **Classes Abstraites** | Méthodes vides | Forcer l'implémentation de comportements |
| **Méthodes Virtuelles** | Comportements par défaut | Flexibilité + réutilisation |

### 🎯 Règles Pratiques
- **Héritage** : "Est-un" (Guerrier est un Personnage)
- **Abstract** : Quand la classe mère ne peut pas implémenter
- **Virtual** : Quand la classe mère peut fournir un comportement par défaut
- **Polymorphisme** : Pour traiter des collections d'objets différents

### 🚀 Prochaines Étapes
- **Interfaces** : Contrats sans implémentation
- **Composition** : Alternative à l'héritage
- **Patterns de conception** : Utilisation avancée 