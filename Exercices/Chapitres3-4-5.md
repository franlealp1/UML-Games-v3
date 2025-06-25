# 🎮 Exercices - Chapitres 3, 4 et 5


## 🎯 Exercice 1: Agrégation et Composition

### Contexte : Système de Gestion d'Aéroline (Style Airline Manager)

Vous développez un jeu de gestion d'aéroline. Vous devez modéliser les relations entre les différentes entités de votre compagnie aérienne.

### ✈️ Entités à Modéliser

1. **Aéroline** : Compagnie aérienne avec avions, personnel et routes
2. **Avion** : Aéronef avec capacité et caractéristiques techniques
3. **Pilote** : Membre d'équipage qui pilote les avions
4. **Aéroport** : Base d'opérations avec pistes et installations
5. **Vol** : Trajet entre deux aéroports
6. **Équipement** : Matériel de bord (GPS, radio, etc.)
7. **Passager** : Client qui voyage sur les vols
8. **Réservation** : Réservation de vol par un passager
9. **Route** : Itinéraire entre deux aéroports
10. **Maintenance** : Entretien effectué sur un avion

### 📝 Tâches

#### A. Analyse des Relations
Pour chaque paire d'entités, déterminez le type de relation (association simple, agrégation ou composition) et justifiez votre choix :

1. **Pilote ↔ Avion** : Un pilote peut piloter plusieurs avions, un avion peut être piloté par plusieurs pilotes
2. **Passager ↔ Vol** : Un passager peut prendre plusieurs vols, un vol peut avoir plusieurs passagers
3. **Aéroport ↔ Route** : Un aéroport peut être le départ ou l'arrivée de plusieurs routes
4. **Aéroline ↔ Avion** : Un avion peut-il exister sans aéroline ?
5. **Aéroline ↔ Pilote** : Un pilote peut-il exister sans aéroline ?
6. **Aéroline ↔ Vol** : Un vol peut-il exister sans aéroline ?
7. **Avion ↔ Équipement** : Un avion peut-il exister sans équipement ?
8. **Vol ↔ Réservation** : Une réservation peut-elle exister sans vol ?
9. **Route ↔ Vol** : Un vol peut-il exister sans route ?
10. **Avion ↔ Maintenance** : Un avion peut-il avoir plusieurs maintenances ?

#### B. Diagramme UML Complet
Créez un diagramme UML montrant toutes les relations avec :
- Les associations simples (ligne simple)
- Les agrégations (losange vide ◇)
- Les compositions (losange plein ◆)
- Les bonnes cardinalités
- Les attributs principaux de chaque classe


#### D. Questions de Réflexion
1. **Vente d'avion** : Comment modéliser le transfert d'un avion vers une autre aéroline ?
2. **Maintenance** : Que se passe-t-il avec l'équipement pendant la révision d'un avion ?
3. **Vol annulé** : Que deviennent les pilotes assignés et les réservations ?
4. **Nouveau pilote** : Comment affecte-t-il la planification des vols ?
5. **Changement de route** : Que se passe-t-il avec les vols existants ?



## 🎯 Exercice 2 : Héritage et Polymorphisme

### Contexte : Système de Véhicules de Course

Vous développez un jeu de course avec différents types de véhicules. Chaque véhicule a des comportements spécifiques mais partage des caractéristiques communes.

### 🏎️ Types de Véhicules

1. **Voiture de Course** : Vitesse élevée, faible résistance
2. **4x4** : Vitesse moyenne, haute résistance, peut grimper
3. **Moto** : Vitesse très élevée, très faible résistance, peut faire des wheelies
4. **Camion** : Vitesse lente, très haute résistance, peut transporter

### 📝 Tâches

#### A. Analyse des Caractéristiques Communes
Identifiez les attributs et méthodes communs à tous les véhicules :
- **Attributs** : nom, vitesse, résistance, carburant, position
- **Méthodes** : démarrer(), accélérer(), freiner(), se déplacer()

#### B. Hiérarchie d'Héritage
Créez un diagramme UML montrant :
- La classe abstraite `Vehicule`
- Les classes concrètes qui en héritent
- Les méthodes abstraites et concrètes
- Les attributs spécifiques à chaque type

#### C. Implémentation C#
```csharp
public abstract class Vehicule
{
    protected string nom;
    protected int vitesse;
    protected int resistance;
    protected int carburant;
    protected Position position;
    
    public abstract void Demarrer();
    public abstract void Accelerer();
    public virtual void Freiner() { /* logique commune */ }
    public virtual void SeDeplacer() { /* logique commune */ }
}

// Implémentez les classes concrètes
```

#### D. Polymorphisme
Créez un système de course qui utilise le polymorphisme :

```csharp
public class Course
{
    private List<Vehicule> participants;
    
    public void DemarrerCourse()
    {
        foreach (Vehicule v in participants)
        {
            v.Demarrer();
            v.Accelerer();
        }
    }
}
```

#### E. Questions de Réflexion
1. **Nouveau véhicule** : Comment ajouter facilement un nouveau type de véhicule ?
2. **Comportements spéciaux** : Comment gérer les comportements uniques (wheelie pour moto) ?
3. **Évolution** : Comment faire évoluer un véhicule (améliorer ses stats) ?

---

## 🎯 Exercice 3 : Interfaces et Rôles Multiples

### Contexte : Système de Personnages RPG Avancé

Vous développez un RPG où les personnages peuvent avoir plusieurs rôles simultanément et changer de rôle selon le contexte.

### 🎭 Rôles Possibles

1. **Combattant** : Peut attaquer, se défendre, utiliser des armes
2. **Mage** : Peut lancer des sorts, utiliser des potions, méditer
3. **Explorateur** : Peut ouvrir des coffres, détecter des pièges, cartographier
4. **Artisan** : Peut fabriquer des objets, réparer des équipements
5. **Marchand** : Peut vendre, acheter, négocier des prix
6. **Diplomate** : Peut parler aux NPCs, résoudre des conflits

### 📝 Tâches

#### A. Analyse des Rôles
Pour chaque rôle, identifiez :
- Les méthodes spécifiques
- Les attributs nécessaires
- Les interactions possibles avec d'autres rôles

#### B. Interfaces
Créez les interfaces pour chaque rôle :

```csharp
public interface ICombattant
{
    void Attaquer(Cible cible);
    void SeDefendre();
    bool PeutUtiliserArme(Arme arme);
}

public interface IMage
{
    void LancerSort(Sort sort);
    void UtiliserPotion(Potion potion);
    void Mediter();
}

// Créez les autres interfaces...
```

#### C. Classe de Base
Créez une classe abstraite `Personnage` avec les attributs communs :

```csharp
public abstract class Personnage
{
    protected string nom;
    protected int niveau;
    protected int pointsDeVie;
    protected int pointsDeMana;
    protected Position position;
    
    public abstract void Agir();
    public virtual void Parler() { /* logique commune */ }
}
```

#### D. Classes Concrètes
Implémentez des classes qui héritent et implémentent plusieurs interfaces :

```csharp
public class GuerrierMage : Personnage, ICombattant, IMage
{
    // Implémentation des interfaces
}

public class ExplorateurArtisan : Personnage, IExplorateur, IArtisan
{
    // Implémentation des interfaces
}
```

#### E. Système de Changement de Rôle
Implémentez un système permettant de changer de rôle dynamiquement :

```csharp
public class GestionnaireRoles
{
    public void ChangerRole(Personnage personnage, Type nouveauRole)
    {
        // Logique de changement de rôle
    }
}
```

#### F. Questions de Réflexion
1. **Rôles incompatibles** : Comment gérer les rôles qui ne peuvent pas coexister ?
2. **Évolution des rôles** : Comment faire évoluer un rôle (niveaux, compétences) ?
3. **Interactions entre rôles** : Comment gérer les synergies entre rôles ?

---
