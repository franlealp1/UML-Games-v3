# Chapitre 5 : Interfaces - Résoudre le Problème de l'Héritage Multiple

## Objectifs
- Comprendre **pourquoi** les interfaces existent
- Identifier les **limitations** de l'héritage simple
- Modéliser des **contrats** sans implémentation
- Utiliser les interfaces pour **éviter** l'héritage multiple

---

## Le Problème : Limitation de l'Héritage Simple

### 🚨 Situation Réelle
Dans **World of Warcraft**, les gobelins peuvent avoir différents rôles selon le contexte :
- **Ennemi** : Attaque les joueurs dans certaines zones
- **Allié** : Aide les joueurs dans d'autres zones
- **Marchand** : Vend des objets aux joueurs
- **Artisan** : Crée des objets pour les joueurs

### 💡 Le Problème avec l'Héritage Simple
En C#, une classe ne peut hériter que d'**une seule** classe mère. Comment modéliser un gobelin qui peut être à la fois ennemi ET allié ?

```csharp
// ❌ IMPOSSIBLE en C# - Héritage multiple non supporté
public class Gobelin : Ennemi, Allie  // ❌ ERREUR DE COMPILATION
{
    // ...
}
```

### 🎯 Le Dilemme - Diagramme UML

#### ❌ APPROCHE 1 : Hériter d'Ennemi seulement
```mermaid
classDiagram
    direction TB
classDef default fill:#e8f5e8,stroke:#2e7d32,stroke-width:2px,color:#1b5e20
    class Ennemi {
        -int pointsDeVie
        -string nom
        +Attaquer()
        +RecevoirDegats(int degats)
        +Mourir()
    }
    
    class Gobelin {
        -bool estHostile
        +Attaquer()
        +RecevoirDegats(int degats)
        +Mourir()
    }
    
    class Allie {
        -int pointsDeVie
        -string nom
        +Aider()
        +Soigner()
        +EstAmical()
    }
    
    class Marchand {
        -List~Item~ inventaire
        -string nom
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
    }
    
    Ennemi <|-- Gobelin : hérite de
    note for Gobelin "❌ Ne peut pas être Allié"
    note for Gobelin "❌ Ne peut pas être Marchand"
```

#### ❌ APPROCHE 2 : Classes séparées (Duplication)
```mermaid
classDiagram
    direction TB
classDef default fill:#e8f5e8,stroke:#2e7d32,stroke-width:2px,color:#1b5e20
    class Ennemi {
        -int pointsDeVie
        -string nom
        +Attaquer()
        +RecevoirDegats(int degats)
        +Mourir()
    }
    
    class Allie {
        -int pointsDeVie
        -string nom
        +Aider()
        +Soigner()
        +EstAmical()
    }
    
    class Marchand {
        -List~Item~ inventaire
        -string nom
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
    }
    
    class GobelinEnnemi {
        +Attaquer()
        +RecevoirDegats(int degats)
        +Mourir()
    }
    
    class GobelinAllie {
        +Aider()
        +Soigner()
        +EstAmical()
    }
    
    class GobelinMarchand {
        -List~Item~ inventaire
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
    }
    
    Ennemi <|-- GobelinEnnemi : hérite de
    Allie <|-- GobelinAllie : hérite de
    Marchand <|-- GobelinMarchand : hérite de
    
    note for GobelinEnnemi "❌ DUPLICATION"
    note for GobelinAllie "❌ DUPLICATION"
    note for GobelinMarchand "❌ DUPLICATION"
    note for GobelinEnnemi "❌ Rôle fixe - pas de flexibilité"
```

---

## La Solution : Interfaces

### 🎯 Qu'est-ce qu'une Interface ?
Une **interface** définit un **contrat** (méthodes et propriétés) qu'une classe doit respecter, **sans fournir d'implémentation**. Elle résout le problème de l'héritage multiple.

### ✅ Avec Interfaces - Diagramme UML

```mermaid
classDiagram
    direction TB
classDef default fill:#e8f5e8,stroke:#2e7d32,stroke-width:2px,color:#1b5e20
    class IEnnemi {
        <<interface>>
        +Attaquer()*
        +RecevoirDegats(int degats)*
        +EstHostile()*
    }
    
    class IAllie {
        <<interface>>
        +Aider()*
        +Soigner()*
        +EstAmical()*
    }
    
    class IMarchand {
        <<interface>>
        +Vendre(Item item)*
        +Acheter(Item item)*
        +GetInventaire()*
    }
    
    class Gobelin {
        -int or
        -int experience
        +Attaquer()
        +RecevoirDegats(int degats)
        +EstHostile()
        +Aider()
        +Soigner()
        +EstAmical()
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
        +ChangerRôle(bool devenirAmical)
    }
    
    IEnnemi <|.. Gobelin : implémente
    IAllie <|.. Gobelin : implémente
    IMarchand <|.. Gobelin : implémente
    
    note for Gobelin "✅ Rôles multiples"
    note for Gobelin "✅ Pas de duplication"
    note for Gobelin "✅ Flexibilité - peut changer de rôle"
```

### Avantages Immédiats
- **Héritage multiple** : Une classe peut implémenter plusieurs interfaces
- **Flexibilité** : Un gobelin peut changer de rôle dynamiquement
- **Pas de duplication** : Une seule classe pour tous les rôles
- **Contrats clairs** : Chaque interface définit exactement ce qui doit être fait

---

## Le Problème : Structure ET Comportement Communs

### 🚨 Situation Réelle
Dans un jeu, nous avons des créatures qui partagent **structure ET comportement communs** :
- **Structure commune** : Toutes les créatures ont `nom`, `niveau`, `pointsDeVie`
- **Comportement commun** : Toutes les créatures peuvent `parler`, `agir`, `mourir`
- **Rôles multiples** : Une créature peut être ennemie ET alliée ET marchande

### 💡 Le Problème - Diagramme UML

```mermaid
classDiagram
    direction TB
classDef default fill:#e8f5e8,stroke:#2e7d32,stroke-width:2px,color:#1b5e20
    class IEnnemi {
        <<interface>>
        +Attaquer()*
        +RecevoirDegats(int degats)*
        +EstHostile()*
    }
    
    class IAllie {
        <<interface>>
        +Aider()*
        +Soigner()*
        +EstAmical()*
    }
    
    class Gobelin {
        -string nom
        -int niveau
        -int pointsDeVie
        -int or
        +Parler()
        +Agir()
        +Mourir()
        +Attaquer()
        +RecevoirDegats(int degats)
        +EstHostile()
        +Aider()
        +Soigner()
        +EstAmical()
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
    }
    
    class Orc {
        -string nom
        -int niveau
        -int pointsDeVie
        -int force
        +Parler()
        +Agir()
        +Mourir()
        +Attaquer()
        +RecevoirDegats(int degats)
        +EstHostile()
    }
    
    class Troll {
        -string nom
        -int niveau
        -int pointsDeVie
        -int resistance
        +Parler()
        +Agir()
        +Mourir()
        +Attaquer()
        +RecevoirDegats(int degats)
        +EstHostile()
    }
    
    IEnnemi <|.. Gobelin : implémente
    IEnnemi <|.. Orc : implémente
    IEnnemi <|.. Troll : implémente
    IAllie <|.. Gobelin : implémente
    
    note for Gobelin "❌ Structure commune - DUPLICATION"
    note for Orc "❌ Structure commune - DUPLICATION"
    note for Troll "❌ Structure commune - DUPLICATION"
    note for Gobelin "❌ Comportement commune - DUPLICATION"
    note for Orc "❌ Comportement commune - DUPLICATION"
    note for Troll "❌ Comportement commune - DUPLICATION"
```

### 💡 Le Problème
**Situation :** Nous avons des créatures qui partagent **structure ET comportement communs**, mais qui peuvent aussi avoir **rôles multiples**.

**❌ Problème avec les interfaces seules :**

```csharp
// Chaque classe redéfinit TOUT depuis zéro
public class Gobelin : IEnnemi, IAllie, IMarchand
{
    // ❌ DUPLICATION de structure
    private string nom;
    private int niveau;
    private int pointsDeVie;
    private int or;
    
    // ❌ DUPLICATION de comportement
    public void Parler() { /* logique commune */ }
    public void Agir() { /* logique commune */ }
    public void Mourir() { /* logique commune */ }
    
    // Méthodes spécifiques aux interfaces
    public void Attaquer() { /* spécifique */ }
    public void Aider() { /* spécifique */ }
    public void Vendre(Item item) { /* spécifique */ }
}

public class Orc : IEnnemi
{
    // ❌ MÊME DUPLICATION
    private string nom;
    private int niveau;
    private int pointsDeVie;
    private int force;
    
    public void Parler() { /* même logique */ }
    public void Agir() { /* même logique */ }
    public void Mourir() { /* même logique */ }
    public void Attaquer() { /* spécifique */ }
}
```

**🔍 Problèmes identifiés :**
1. **Duplication de Structure** : Attributs identiques dans toutes les classes (`nom`, `niveau`, `pointsDeVie`)
2. **Duplication de Comportement** : Méthodes communes redéfinies partout (`Parler`, `Agir`, `Mourir`)
3. **Pas de réutilisation** : Chaque classe réinvente la roue
4. **Maintenance difficile** : Changer la logique commune = modifier toutes les classes

---

## La Solution : Classes Abstraites + Interfaces

### 🎯 Approche Hybride
Combiner les **classes abstraites** (pour le comportement commun) avec les **interfaces** (pour les contrats multiples).

### ✅ Solution Complète - Diagramme UML

```mermaid
classDiagram
    direction TB
classDef default fill:#e8f5e8,stroke:#2e7d32,stroke-width:2px,color:#1b5e20
    class NPCBase {
        <<abstract>>
        -string nom
        -int niveau
        +Parler()
        +Agir()*
    }
    
    class IEnnemi {
        <<interface>>
        +Attaquer()*
        +RecevoirDegats(int degats)*
        +EstHostile()*
    }
    
    class IAllie {
        <<interface>>
        +Aider()*
        +Soigner()*
        +EstAmical()*
    }
    
    class IMarchand {
        <<interface>>
        +Vendre(Item item)*
        +Acheter(Item item)*
        +GetInventaire()*
    }
    
    class IQueteur {
        <<interface>>
        +DonnerQuete(Quete quete)*
        +ValiderQuete(Quete quete)*
        +GetQuetesDisponibles()*
    }
    
    class IArtisan {
        <<interface>>
        +CreerObjet(Recette recette)*
        +GetRecettes()*
    }
    
    class Gobelin {
        -int or
        -int experience
        +Attaquer()
        +RecevoirDegats(int degats)
        +EstHostile()
        +Aider()
        +Soigner()
        +EstAmical()
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
        +DonnerQuete(Quete quete)
        +ValiderQuete(Quete quete)
        +GetQuetesDisponibles()
        +ChangerRôle(bool devenirAmical)
    }
    
    class Orc {
        -int pointsDeVie
        -int force
        +Attaquer()
        +RecevoirDegats(int degats)
        +EstHostile()
    }
    
    class Humain {
        -int or
        -int reputation
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
        +CreerObjet(Recette recette)
        +GetRecettes()
    }
    
    NPCBase <|-- Gobelin : hérite de
    NPCBase <|-- Orc : hérite de
    NPCBase <|-- Humain : hérite de
    
    IEnnemi <|.. Gobelin : implémente
    IEnnemi <|.. Orc : implémente
    IAllie <|.. Gobelin : implémente
    IMarchand <|.. Gobelin : implémente
    IMarchand <|.. Humain : implémente
    IQueteur <|.. Gobelin : implémente
    IArtisan <|.. Humain : implémente
    
    note for Gobelin "✅ 4 rôles différents"
    note for Orc "✅ Rôle d'ennemi uniquement"
    note for Humain "✅ Rôles de marchand et artisan"
```

### 🏆 Avantages de l'Approche Hybride
- **Réutilisation** : Comportement commun hérité de la classe abstraite
- **Flexibilité** : Rôles multiples via les interfaces
- **DRY** : Pas de duplication de code
- **Évolutivité** : Facile d'ajouter de nouveaux rôles

---

## Exemple Pratique : Système de Quêtes

### 🎮 Contexte Réel
Dans **Skyrim**, les NPCs peuvent avoir plusieurs rôles :
- **Ennemi** : Attaque le joueur
- **Allié** : Aide le joueur
- **Marchand** : Vend des objets
- **Quêteur** : Donne des quêtes
- **Artisan** : Crée des objets

### 🚨 Problèmes à Résoudre
1. **Rôles multiples** : Un NPC peut être marchand ET quêteur
2. **Comportements communs** : Tous les ennemis attaquent de la même façon
3. **Flexibilité** : Un NPC peut changer de rôle selon les conditions

### ✅ Solution Complète - Diagramme UML

```mermaid
classDiagram
    direction TB
classDef default fill:#e8f5e8,stroke:#2e7d32,stroke-width:2px,color:#1b5e20
    class NPCBase {
        <<abstract>>
        -string nom
        -int niveau
        +Parler()
        +Agir()*
    }
    
    class IEnnemi {
        <<interface>>
        +Attaquer()*
        +RecevoirDegats(int degats)*
        +EstHostile()*
    }
    
    class IAllie {
        <<interface>>
        +Aider()*
        +Soigner()*
        +EstAmical()*
    }
    
    class IMarchand {
        <<interface>>
        +Vendre(Item item)*
        +Acheter(Item item)*
        +GetInventaire()*
    }
    
    class IQueteur {
        <<interface>>
        +DonnerQuete(Quete quete)*
        +ValiderQuete(Quete quete)*
        +GetQuetesDisponibles()*
    }
    
    class IArtisan {
        <<interface>>
        +CreerObjet(Recette recette)*
        +GetRecettes()*
    }
    
    class Gobelin {
        -int or
        -int experience
        +Attaquer()
        +RecevoirDegats(int degats)
        +EstHostile()
        +Aider()
        +Soigner()
        +EstAmical()
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
        +DonnerQuete(Quete quete)
        +ValiderQuete(Quete quete)
        +GetQuetesDisponibles()
        +ChangerRôle(bool devenirAmical)
    }
    
    class Orc {
        -int pointsDeVie
        -int force
        +Attaquer()
        +RecevoirDegats(int degats)
        +EstHostile()
    }
    
    class Humain {
        -int or
        -int reputation
        +Vendre(Item item)
        +Acheter(Item item)
        +GetInventaire()
        +CreerObjet(Recette recette)
        +GetRecettes()
    }
    
    NPCBase <|-- Gobelin : hérite de
    NPCBase <|-- Orc : hérite de
    NPCBase <|-- Humain : hérite de
    
    IEnnemi <|.. Gobelin : implémente
    IEnnemi <|.. Orc : implémente
    IAllie <|.. Gobelin : implémente
    IMarchand <|.. Gobelin : implémente
    IMarchand <|.. Humain : implémente
    IQueteur <|.. Gobelin : implémente
    IArtisan <|.. Humain : implémente
    
    note for Gobelin "✅ 4 rôles différents"
    note for Orc "✅ Rôle d'ennemi uniquement"
    note for Humain "✅ Rôles de marchand et artisan"
```


### 🎯 Utilisation Polymorphique
```csharp
// ✅ Code flexible qui s'adapte aux rôles
List<NPCBase> npcs = new List<NPCBase>();
npcs.Add(new Gobelin("Grik"));
npcs.Add(new Orc("Grom"));

foreach (NPCBase npc in npcs)
{
    npc.Agir();  // Chaque type utilise sa propre implémentation
    
    // ✅ Vérification de rôles
    if (npc is IMarchand marchand)
    {
        marchand.Vendre(new Item("Épée"));
    }
    
    if (npc is IQueteur queteur)
    {
        queteur.DonnerQuete(new Quete("Tuer les rats"));
    }
}
```

---

## Comparaison : Héritage vs Interfaces

### 📊 Tableau Comparatif

| Aspect | Héritage | Interfaces |
|--------|----------|------------|
| **Héritage multiple** | ❌ Non supporté | ✅ Supporté |
| **Implémentation** | ✅ Code fourni | ❌ Contrat seulement |
| **Réutilisation** | ✅ Héritage de code | ❌ Pas de code |
| **Flexibilité** | ❌ Relation fixe | ✅ Rôles multiples |
| **Contrats** | ❌ Implicite | ✅ Explicite |

### 🎯 Quand Utiliser Chaque Approche

#### ✅ Utiliser l'Héritage quand :
- **Relation "est-un"** claire
- **Comportement commun** à partager
- **Hiérarchie** logique et stable
- Exemple : `Gobelin` est un `Ennemi`

#### ✅ Utiliser les Interfaces quand :
- **Rôles multiples** nécessaires
- **Contrats** sans implémentation
- **Flexibilité** requise
- Exemple : `Gobelin` peut être `IEnnemi`, `IAllie`, `IMarchand`

#### ✅ Utiliser l'Approche Hybride quand :
- **Comportement commun** + **rôles multiples**
- **Réutilisation** + **flexibilité**
- Exemple : `Gobelin` hérite de `EnnemiBase` + implémente `IAllie`, `IMarchand`

---

## Résumé : Problèmes et Solutions

### 🎯 Règles Pratiques
- **Interface** : "Peut faire" (contrat)
- **Classe Abstraite** : "Est" + comportement commun
- **Héritage Multiple** : Via interfaces (ou interfaces + une classe), pas via classes car impossible
- **Flexibilité** : Interfaces pour rôles dynamiques

