# 🎮 Code - UML Games

Cette section contient le code source pour les exercices des Chapitres 1 et 2.

## 📁 Structure

```
Code/
├── .gitignore          # Fichiers à ignorer par Git
├── README.md           # Ce fichier
├── Chapitre1/          # Code du Chapitre 1 : Classes de Base
│   ├── README.md       # Solutions avec diagrammes UML
│   ├── Weapon.cs       # Classe Weapon
│   ├── HealthPotion.cs # Classe HealthPotion
│   ├── Player.cs       # Classe Player
│   └── Program.cs      # Programme principal
└── Chapitre2/          # Code du Chapitre 2 : Relations entre Classes
    ├── README.md       # Solutions avec diagrammes UML
    ├── Shepard.cs      # Classe Shepard (Mass Effect)
    ├── Mission.cs      # Classe Mission
    ├── Reward.cs       # Classe Reward
    ├── Mii.cs          # Classe Mii (Wii Sports)
    ├── Event.cs        # Classe Event
    ├── Participation.cs # Classe Participation
    └── Program.cs      # Programme principal
```

## 🚀 Comment compiler et exécuter

### Prérequis
- .NET 6.0 ou plus récent
- Un éditeur de code (Visual Studio, VS Code, etc.)

### Compilation et exécution

#### Chapitre 1
```bash
cd Code/Chapitre1
dotnet run
```

#### Chapitre 2
```bash
cd Code/Chapitre2
dotnet run
```

## 📚 Contenu

### Chapitre 1 : Classes de Base
- **Weapon** : Classe simple avec attributs et méthodes
- **HealthPotion** : Classe avec validation de données
- **Player** : Classe qui utilise HealthPotion (association)

### Chapitre 2 : Relations entre Classes
- **Mass Effect** : Système de missions (one-to-many)
- **Wii Sports** : Système d'athlétisme (many-to-many avec classe d'association)

## 🎯 Objectifs pédagogiques

1. **Comprendre les classes** : Attributs, méthodes, constructeurs
2. **Maîtriser les relations** : One-to-many, many-to-many, associations réflexives
3. **Implémenter des systèmes** : Validation, gestion d'état, workflows
4. **Lire les diagrammes UML** : Chaque solution inclut un diagramme Mermaid

## 🔧 Personnalisation

Vous pouvez modifier les classes pour :
- Ajouter de nouvelles fonctionnalités
- Implémenter d'autres relations
- Créer de nouveaux exemples de jeux
- Tester différents scénarios

## 📖 Documentation

Chaque chapitre contient un fichier `README.md` avec :
- Diagrammes UML en Mermaid
- Code source complet
- Explications des concepts
- Exemples d'utilisation 