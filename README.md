# Projet UML-Games-v3

## Description
Ce projet est une collection d'exemples et d'exercices pratiques pour illustrer les concepts UML (Unified Modeling Language) dans le développement de jeux vidéo et d'applications. Il est conçu comme un outil pédagogique pour comprendre les différentes relations entre classes (association, agrégation, composition) ainsi que les concepts d'héritage et d'interfaces.

L'objectif principal est de fournir une base solide pour la modélisation orientée objet dans le contexte des jeux vidéo, en montrant comment les différentes relations UML peuvent être implémentées en code C#. Les exemples sont inspirés de mécaniques de jeu courantes, ce qui permet de voir comment la théorie s'applique à des scénarios concrets de développement de jeux.

## Structure du Projet
Le projet est organisé en chapitres, chacun couvrant différents aspects des relations UML. Chaque chapitre explore un concept fondamental de la modélisation UML et son application dans le développement de jeux:

### Chapitre 1: Introduction à l'UML
Ce chapitre introduit les concepts fondamentaux de la modélisation UML et son importance dans le développement de jeux vidéo. Il présente les différents types de diagrammes UML et leur utilité dans la conception de systèmes orientés objet.

### Chapitre 2: Relations d'Association
Ce chapitre explore les différents types de relations d'association entre classes, fondamentales dans la conception orientée objet. Les associations définissent comment les objets interagissent entre eux et forment la base de toute architecture logicielle.

- **Exemple 1**: Relation entre Personnage et Véhicule (1 à plusieurs) - Un personnage peut posséder plusieurs véhicules
- **Exemple 2**: Joueur et Scores (1 à plusieurs) - Un joueur peut avoir plusieurs scores dans différents niveaux
- **Exemple 3**: Joueur et Armes (many-to-many) - Les joueurs peuvent utiliser plusieurs armes et une arme peut être utilisée par plusieurs joueurs
- **Exemple 4**: Système de Compétences et Personnages - Implémentation d'un système de compétences modulaire
- **Exemple 5**: Joueur et Système de Santé (1 à 1) - Chaque joueur a exactement un système de santé
- **Exemple 6**: Conteneurs imbriqués (relation réflexive) - Des objets peuvent contenir d'autres objets du même type
- **Exemple 7**: Hiérarchie militaire (relation réflexive) - Structure hiérarchique où chaque unité peut commander d'autres unités
- **Exercice 2**: Système d'Athlétisme - Modélisation d'un système de compétitions sportives
- **Exercice 3**: Système de Guildes et Membres - Gestion des guildes et de leurs membres avec différents rôles
- **Exercice 4**: Système de Potions dans The Witcher - Système d'alchimie inspiré du jeu The Witcher

### Chapitre 3: Agrégation et Composition
Ce chapitre se concentre sur les relations d'agrégation et de composition, qui sont des formes spéciales d'association indiquant des relations de type "tout-partie". La distinction entre ces deux types est essentielle pour modéliser correctement le cycle de vie des objets.

- **Exemple 1**: Inventaire et Objets (Agrégation) - Un inventaire contient des objets, mais ces objets peuvent exister indépendamment
- **Exemple 2**: Niveau de Jeu et Plateformes (Composition) - Un niveau contient des plateformes qui n'existent pas en dehors du niveau
- **Exercice 1**: Système de Gestion d'Aéroline (Agrégation, Composition et Association) - Système complet illustrant les trois types de relations dans un contexte réaliste

### Chapitre 4: Héritage et Polymorphisme
Ce chapitre se concentre sur les mécanismes d'héritage et de polymorphisme, qui permettent de créer des hiérarchies de classes et de réutiliser du code. Ces concepts sont essentiels pour créer des architectures extensibles et maintenables.

- **Exemple 1**: Hiérarchie d'Entités de Jeu - Implémentation d'une hiérarchie de classes pour les entités de jeu
- **Exemple 2**: Armes et Projectiles - Utilisation du polymorphisme pour gérer différents types d'armes et leurs effets

### Chapitre 5: Interfaces et Implémentation de Comportements
Ce chapitre se concentre spécifiquement sur les interfaces et leur utilisation pour implémenter des comportements multiples et modulaires. Les interfaces permettent de définir des contrats que les classes doivent respecter, offrant ainsi une grande flexibilité dans la conception.

- **Exemple 1**: Interfaces - Gobelin Multi-Rôles - Utilisation des interfaces pour permettre à une entité d'avoir plusieurs comportements
- **Exemple 2**: Interfaces Avancées - NPCs Modulaires - Création d'un système de PNJ (personnages non-joueurs) avec des comportements interchangeables

## Comment Utiliser ce Projet
1. Clonez le dépôt sur votre machine locale
2. Ouvrez le projet dans Visual Studio ou votre IDE C# préféré
3. Compilez le projet avec `dotnet build`
4. Exécutez l'application avec `dotnet run`
5. Un menu interactif vous permettra de sélectionner et d'exécuter les différents exemples et exercices (si tout va bien!!)

Chaque exemple et exercice est conçu pour être autonome et illustrer clairement un concept spécifique. Le code est abondamment commenté pour faciliter la compréhension des principes UML mis en œuvre.

