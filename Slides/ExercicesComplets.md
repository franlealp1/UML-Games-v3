# Exercices Complets : Tous les Concepts

## Objectifs
- Appliquer tous les concepts vus dans les chapitres 1-4
- Modéliser un système de jeu complet avec des bonnes pratiques
- Créer des diagrammes UML cohérents et professionnels
- Implémenter les structures de données avec des patterns appropriés

---

## Exercice 1 : "Dragon Quest" - Jeu de Rôle Simple

### Contexte du Jeu
"Dragon Quest" est un jeu de rôle simple où :
- Les **joueurs** créent des **personnages** de différents types
- Les personnages combattent des **monstres** dans des **donjons**
- Les personnages peuvent utiliser des **objets** et des **armes**
- Les **donjons** contiennent des **salles** avec des **monstres** et des **trésors**

### Système de Jeu
1. **Types de personnages** : Guerrier, Mage, Archer
2. **Types de monstres** : Gobelin, Troll, Dragon
3. **Types d'objets** : Potions, Armes, Armures
4. **Structure** : Donjons → Salles → Monstres/Trésors

### Tâches de Modélisation

#### 1.1 Classes de Base
Créez les classes de base avec les attributs et méthodes appropriés :
- **Personnage** (classe abstraite)
- **Monstre** (classe abstraite)
- **Objet** (classe abstraite)
- **Donjon** et **Salle**

#### 1.2 Hiérarchies d'Héritage
Modélisez les hiérarchies suivantes :

**Personnages** :
```
Personnage (abstraite)
├── Guerrier
├── Mage
└── Archer
```

**Monstres** :
```
Monstre (abstraite)
├── Gobelin
├── Troll
└── Dragon
```

**Objets** :
```
Objet (abstraite)
├── Consommable
│   ├── PotionVie
│   └── PotionMana
├── Arme
│   ├── Epee
│   ├── Arc
│   └── Baton
└── Armure
    ├── Cuirasse
    └── Robe
```

#### 1.3 Relations entre Classes
Modélisez les relations suivantes :
- Un **Joueur** a un **Personnage** (composition)
- Un **Personnage** a un **Inventaire** (composition)
- Un **Inventaire** contient des **Objets** (agrégation)
- Un **Personnage** peut équiper une **Arme** et une **Armure** (association)
- Un **Donjon** contient plusieurs **Salles** (composition)
- Une **Salle** contient des **Monstres** et des **Trésors** (agrégation)
- Un **Personnage** peut combattre des **Monstres** (association)

#### 1.4 Diagramme UML Complet
Créez un diagramme UML qui inclut :
- Toutes les classes avec leurs attributs et méthodes
- Toutes les relations (héritage, agrégation, composition, association)
- Les cardinalités appropriées
- Les méthodes abstraites et virtuelles

### Exemple de Structure de Données Professionnelle

```csharp
// Classes abstraites avec bonnes pratiques
public abstract class Personnage
{
    protected string nom;
    protected int niveau;
    protected int pointsDeVie;
    protected int pointsDeVieMax;
    protected int pointsDeMana;
    protected int pointsDeManaMax;
    protected Inventaire inventaire;
    protected Arme armeEquipee;
    protected Armure armureEquipee;
    
    protected Personnage(string nom, int niveau)
    {
        this.nom = nom;
        this.niveau = niveau;
        this.inventaire = new Inventaire(20); // Composition
    }
    
    public abstract void Attaquer(Monstre cible);
    public abstract void UtiliserCompetence();
    public virtual void SeDefendre() 
    { 
        Console.WriteLine($"{nom} se défend"); 
    }
    
    public virtual void RecevoirDegats(int degats)
    {
        pointsDeVie = Math.Max(0, pointsDeVie - degats);
        if (pointsDeVie <= 0)
        {
            Mourir();
        }
    }
    
    protected virtual void Mourir()
    {
        Console.WriteLine($"{nom} est mort");
    }
    
    // Propriétés pour encapsulation
    public string Nom => nom;
    public int Niveau => niveau;
    public int PointsDeVie => pointsDeVie;
    public bool EstVivant => pointsDeVie > 0;
}

public abstract class Monstre
{
    protected string nom;
    protected int pointsDeVie;
    protected int pointsDeVieMax;
    protected int degats;
    protected int recompense;
    protected int niveau;
    
    protected Monstre(string nom, int niveau, int pointsDeVie, int degats, int recompense)
    {
        this.nom = nom;
        this.niveau = niveau;
        this.pointsDeVie = pointsDeVie;
        this.pointsDeVieMax = pointsDeVie;
        this.degats = degats;
        this.recompense = recompense;
    }
    
    public abstract void Attaquer(Personnage cible);
    public abstract void Comportement();
    
    public virtual void RecevoirDegats(int degats)
    {
        pointsDeVie = Math.Max(0, pointsDeVie - degats);
        if (pointsDeVie <= 0)
        {
            Mourir();
        }
    }
    
    protected virtual void Mourir()
    {
        Console.WriteLine($"{nom} est vaincu");
    }
    
    public string Nom => nom;
    public int Niveau => niveau;
    public int PointsDeVie => pointsDeVie;
    public bool EstVivant => pointsDeVie > 0;
    public int Recompense => recompense;
}

public abstract class Objet
{
    protected string nom;
    protected string description;
    protected int valeur;
    protected int niveauRequis;
    
    protected Objet(string nom, string description, int valeur, int niveauRequis)
    {
        this.nom = nom;
        this.description = description;
        this.valeur = valeur;
        this.niveauRequis = niveauRequis;
    }
    
    public abstract void Utiliser(Personnage cible);
    public abstract bool PeutEtreUtilisePar(Personnage cible);
    
    public string Nom => nom;
    public string Description => description;
    public int Valeur => valeur;
    public int NiveauRequis => niveauRequis;
}

// Relations avec gestion appropriée
public class Inventaire
{
    private List<Objet> objets;
    private int capaciteMax;
    
    public Inventaire(int capaciteMax)
    {
        this.capaciteMax = capaciteMax;
        this.objets = new List<Objet>(); // Agrégation : liste externe
    }
    
    public bool AjouterObjet(Objet objet)
    {
        if (objets.Count < capaciteMax)
        {
            objets.Add(objet);
            return true;
        }
        return false;
    }
    
    public bool RetirerObjet(Objet objet)
    {
        return objets.Remove(objet);
    }
    
    public List<Objet> Objets => new List<Objet>(objets); // Encapsulation
    public int CapaciteMax => capaciteMax;
    public int NombreObjets => objets.Count;
}

public class Donjon
{
    private string nom;
    private List<Salle> salles;
    private int niveauDifficulte;
    
    public Donjon(string nom, int niveauDifficulte)
    {
        this.nom = nom;
        this.niveauDifficulte = niveauDifficulte;
        this.salles = new List<Salle>(); // Composition : création interne
    }
    
    public void AjouterSalle(Salle salle)
    {
        salles.Add(salle);
    }
    
    public string Nom => nom;
    public int NiveauDifficulte => niveauDifficulte;
    public IReadOnlyList<Salle> Salles => salles.AsReadOnly();
}
```

---

## Exercice 2 : "Space Battle" - Jeu de Combat Spatial

### Contexte du Jeu
"Space Battle" est un jeu de combat spatial où :
- Les **joueurs** contrôlent des **vaisseaux** de différents types
- Les vaisseaux combattent dans des **secteurs spatiaux**
- Les vaisseaux peuvent être équipés de **modules** et d'**armes**
- Les **flottes** organisent des **missions** dans différents **secteurs**

### Système de Jeu
1. **Types de vaisseaux** : Chasseur, Croiseur, Cuirassé
2. **Types d'ennemis** : Vaisseau Pirate, Station Spatiale, Flotte Ennemie
3. **Types d'équipement** : Armes, Boucliers, Moteurs
4. **Structure** : Secteur → Flotte → Vaisseaux → Équipement

### Tâches de Modélisation

#### 2.1 Classes de Base
Créez les classes de base avec les attributs et méthodes appropriés :
- **Vaisseau** (classe abstraite)
- **Ennemi** (classe abstraite)
- **Equipement** (classe abstraite)
- **Secteur**, **Flotte** et **Mission**

#### 2.2 Hiérarchies d'Héritage
Modélisez les hiérarchies suivantes :

**Vaisseaux** :
```
Vaisseau (abstraite)
├── Chasseur
├── Croiseur
└── Cuirasse
```

**Ennemis** :
```
Ennemi (abstraite)
├── VaisseauPirate
├── StationSpatiale
└── FlotteEnnemie
```

**Équipement** :
```
Equipement (abstraite)
├── Arme
│   ├── Laser
│   ├── Missile
│   └── Canon
├── Bouclier
│   ├── BouclierStandard
│   └── BouclierRenforce
└── Moteur
    ├── MoteurStandard
    └── MoteurHyperdrive
```

#### 2.3 Relations entre Classes
Modélisez les relations suivantes :
- Un **Joueur** contrôle une **Flotte** (composition)
- Une **Flotte** contient plusieurs **Vaisseaux** (agrégation)
- Un **Vaisseau** peut être équipé de plusieurs **Modules** (agrégation)
- Un **Vaisseau** peut avoir plusieurs **Armes** (agrégation)
- Un **Secteur** contient plusieurs **Flottes** (agrégation)
- Une **Mission** implique une **Flotte** et un **Secteur** (association)
- Les **Vaisseaux** peuvent combattre des **Ennemis** (association)

#### 2.4 Relations Réflexives
Modélisez les relations réflexives :
- Une **Flotte** peut avoir une **Flotte alliée** (agrégation réflexive)
- Un **Vaisseau** peut avoir un **Vaisseau de commandement** (association réflexive)

#### 2.5 Diagramme UML Complet
Créez un diagramme UML qui inclut :
- Toutes les classes avec leurs attributs et méthodes
- Toutes les relations (héritage, agrégation, composition, association)
- Les relations réflexives
- Les cardinalités appropriées
- Les méthodes abstraites et virtuelles

### Exemple de Structure de Données Professionnelle

```csharp
// Classes abstraites avec patterns appropriés
public abstract class Vaisseau
{
    protected string nom;
    protected int pointsDeVie;
    protected int pointsDeVieMax;
    protected int bouclier;
    protected int bouclierMax;
    protected List<Arme> armes;
    protected List<Module> modules;
    protected Vaisseau commandant; // Relation réflexive
    protected Flotte flotte;
    
    protected Vaisseau(string nom, int pointsDeVie, int bouclier)
    {
        this.nom = nom;
        this.pointsDeVie = pointsDeVie;
        this.pointsDeVieMax = pointsDeVie;
        this.bouclier = bouclier;
        this.bouclierMax = bouclier;
        this.armes = new List<Arme>();
        this.modules = new List<Module>();
    }
    
    public abstract void Attaquer(Ennemi cible);
    public abstract void UtiliserCapacite();
    public virtual void SeDefendre() 
    { 
        Console.WriteLine($"{nom} active ses boucliers"); 
    }
    
    public virtual void RecevoirDegats(int degats)
    {
        int degatsRestants = degats;
        
        // Les boucliers absorbent d'abord les dégâts
        if (bouclier > 0)
        {
            int degatsBouclier = Math.Min(bouclier, degatsRestants);
            bouclier -= degatsBouclier;
            degatsRestants -= degatsBouclier;
        }
        
        // Les dégâts restants vont aux points de vie
        if (degatsRestants > 0)
        {
            pointsDeVie = Math.Max(0, pointsDeVie - degatsRestants);
        }
        
        if (pointsDeVie <= 0)
        {
            Detruire();
        }
    }
    
    protected virtual void Detruire()
    {
        Console.WriteLine($"{nom} a été détruit");
        flotte?.RetirerVaisseau(this);
    }
    
    public bool AjouterArme(Arme arme)
    {
        if (armes.Count < 4) // Limite d'armes
        {
            armes.Add(arme);
            return true;
        }
        return false;
    }
    
    public bool AjouterModule(Module module)
    {
        if (modules.Count < 3) // Limite de modules
        {
            modules.Add(module);
            return true;
        }
        return false;
    }
    
    // Propriétés
    public string Nom => nom;
    public int PointsDeVie => pointsDeVie;
    public int Bouclier => bouclier;
    public bool EstOperationnel => pointsDeVie > 0;
    public Vaisseau Commandant => commandant;
    public void SetCommandant(Vaisseau commandant) => this.commandant = commandant;
}

public abstract class Ennemi
{
    protected string nom;
    protected int pointsDeVie;
    protected int pointsDeVieMax;
    protected int puissance;
    protected string type;
    protected int recompense;
    
    protected Ennemi(string nom, int pointsDeVie, int puissance, string type, int recompense)
    {
        this.nom = nom;
        this.pointsDeVie = pointsDeVie;
        this.pointsDeVieMax = pointsDeVie;
        this.puissance = puissance;
        this.type = type;
        this.recompense = recompense;
    }
    
    public abstract void Attaquer(Vaisseau cible);
    public abstract void Comportement();
    
    public virtual void RecevoirDegats(int degats)
    {
        pointsDeVie = Math.Max(0, pointsDeVie - degats);
        if (pointsDeVie <= 0)
        {
            Detruire();
        }
    }
    
    protected virtual void Detruire()
    {
        Console.WriteLine($"{nom} a été détruit");
    }
    
    public string Nom => nom;
    public int PointsDeVie => pointsDeVie;
    public bool EstOperationnel => pointsDeVie > 0;
    public int Recompense => recompense;
}

public abstract class Equipement
{
    protected string nom;
    protected int cout;
    protected int niveau;
    protected bool estActif;
    
    protected Equipement(string nom, int cout, int niveau)
    {
        this.nom = nom;
        this.cout = cout;
        this.niveau = niveau;
        this.estActif = false;
    }
    
    public abstract void Activer(Vaisseau vaisseau);
    public abstract void Desactiver(Vaisseau vaisseau);
    public abstract bool PeutEtreEquipeSur(Vaisseau vaisseau);
    
    public string Nom => nom;
    public int Cout => cout;
    public int Niveau => niveau;
    public bool EstActif => estActif;
}

// Relations avec gestion appropriée
public class Flotte
{
    private string nom;
    private List<Vaisseau> vaisseaux;
    private Flotte flotteAlliee; // Relation réflexive
    private Joueur proprietaire;
    
    public Flotte(string nom, Joueur proprietaire)
    {
        this.nom = nom;
        this.proprietaire = proprietaire;
        this.vaisseaux = new List<Vaisseau>(); // Agrégation : liste externe
    }
    
    public bool AjouterVaisseau(Vaisseau vaisseau)
    {
        if (vaisseaux.Count < 10) // Limite de vaisseaux
        {
            vaisseaux.Add(vaisseau);
            return true;
        }
        return false;
    }
    
    public bool RetirerVaisseau(Vaisseau vaisseau)
    {
        return vaisseaux.Remove(vaisseau);
    }
    
    public void SetFlotteAlliee(Flotte flotteAlliee)
    {
        this.flotteAlliee = flotteAlliee;
    }
    
    public string Nom => nom;
    public IReadOnlyList<Vaisseau> Vaisseaux => vaisseaux.AsReadOnly();
    public Flotte FlotteAlliee => flotteAlliee;
    public int NombreVaisseaux => vaisseaux.Count;
}

public class Secteur
{
    private string nom;
    private List<Flotte> flottes;
    private List<Ennemi> ennemis;
    private int niveauDanger;
    
    public Secteur(string nom, int niveauDanger)
    {
        this.nom = nom;
        this.niveauDanger = niveauDanger;
        this.flottes = new List<Flotte>();
        this.ennemis = new List<Ennemi>();
    }
    
    public void AjouterFlotte(Flotte flotte)
    {
        flottes.Add(flotte);
    }
    
    public void AjouterEnnemi(Ennemi ennemi)
    {
        ennemis.Add(ennemi);
    }
    
    public string Nom => nom;
    public int NiveauDanger => niveauDanger;
    public IReadOnlyList<Flotte> Flottes => flottes.AsReadOnly();
    public IReadOnlyList<Ennemi> Ennemis => ennemis.AsReadOnly();
}
```

---

## Critères d'Évaluation Professionnels

### Modélisation UML (40%)
- **Héritage** : Hiérarchies logiques avec classes abstraites appropriées
- **Agrégation/Composition** : Relations correctement identifiées et justifiées
- **Associations** : Relations appropriées avec cardinalités correctes
- **Relations réflexives** : Modélisation appropriée des auto-références
- **Encapsulation** : Utilisation appropriée des modificateurs d'accès

### Implémentation (30%)
- **Classes abstraites** : Utilisation correcte avec méthodes abstraites
- **Méthodes virtuelles** : Redéfinition appropriée avec `override`
- **Structures de données** : Cohérence avec le modèle UML et bonnes pratiques
- **Gestion des relations** : Implémentation correcte des patterns
- **Gestion d'erreurs** : Validation et gestion des cas limites

### Analyse et Justification (30%)
- **Choix de conception** : Justification des relations et patterns utilisés
- **Cohérence** : Logique du système de jeu et des interactions
- **Extensibilité** : Possibilité d'ajouter de nouvelles fonctionnalités
- **Performance** : Considérations d'optimisation et de scalabilité
- **Maintenabilité** : Qualité du code et facilité de maintenance

---

## Bonnes Pratiques Appliquées

### 1. Encapsulation
- Utilisation de propriétés pour l'accès aux données
- Méthodes `protected` pour la logique interne
- Constructeurs appropriés pour l'initialisation

### 2. Héritage Approprié
- Classes abstraites pour les concepts généraux
- Méthodes abstraites pour les comportements obligatoires
- Méthodes virtuelles pour les comportements optionnels

### 3. Gestion des Relations
- Composition pour les objets dépendants
- Agrégation pour les objets indépendants
- Relations réflexives pour les hiérarchies internes

### 4. Validation et Sécurité
- Vérification des limites (capacité, niveau requis)
- Gestion des états (vivant/mort, actif/inactif)
- Protection contre les accès non autorisés

### 5. Extensibilité
- Patterns permettant l'ajout facile de nouvelles classes
- Interfaces claires pour les extensions
- Séparation des responsabilités

---

## Conseils pour la Réalisation

### 1. Planification
- Identifiez d'abord les **entités principales** et leurs responsabilités
- Définissez les **hiérarchies d'héritage** avec des classes abstraites appropriées
- Identifiez les **relations entre classes** en justifiant chaque choix
- Vérifiez la **cohérence** et la **logique** du modèle

### 2. Modélisation
- Utilisez des **classes abstraites** pour les concepts qui ne doivent pas être instanciés
- Distinguez clairement **agrégation** et **composition** selon les cycles de vie
- Pensez aux **relations réflexives** pour les hiérarchies internes
- Vérifiez les **cardinalités** et les **contraintes** de chaque relation

### 3. Implémentation
- Implémentez d'abord les **classes abstraites** avec leurs méthodes abstraites
- Ajoutez les **hiérarchies d'héritage** avec les méthodes `override`
- Implémentez les **relations entre classes** avec la gestion appropriée
- Testez la **cohérence** et la **robustesse** du système

### 4. Validation
- Vérifiez que le modèle **supporte** toutes les fonctionnalités du jeu
- Testez les **scénarios** de base et les cas limites
- Validez la **logique** des relations et des interactions
- Vérifiez l'**extensibilité** et la **maintenabilité** du modèle

---

## Bonus : Extension du Jeu

### Fonctionnalités Avancées
- **Système de niveau** : Progression avec expérience et compétences
- **Système d'économie** : Achat/vente avec gestion des ressources
- **Système de quêtes** : Missions avec objectifs et récompenses
- **Système de guildes/flottes** : Organisation et hiérarchie des joueurs
- **Système de craft** : Création d'objets/équipement avec recettes

### Considérations Techniques Avancées
- **Performance** : Optimisation des relations et des requêtes
- **Persistance** : Sauvegarde/chargement avec sérialisation
- **Réseau** : Synchronisation multi-joueurs avec patterns appropriés
- **Interface** : Séparation MVC avec patterns Observer/Command
- **Tests** : Tests unitaires et d'intégration pour chaque composant

Ces exercices permettent d'appliquer tous les concepts vus dans les chapitres 1-4 dans un contexte professionnel de développement de jeux avec des bonnes pratiques et des patterns appropriés. 