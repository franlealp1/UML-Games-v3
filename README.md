# Projet UML-Games-v3

## Description
Ce projet est une collection d'exemples et d'exercices pratiques pour illustrer les concepts UML (Unified Modeling Language) dans le développement de jeux vidéo et d'applications. Il est conçu comme un outil pédagogique pour comprendre les différentes relations entre classes (association, agrégation, composition) ainsi que les concepts d'héritage et d'interfaces.

L'objectif principal est de fournir une base solide pour la modélisation orientée objet dans le contexte des jeux vidéo, en montrant comment les différentes relations UML peuvent être implémentées en code C#. Les exemples sont inspirés de mécaniques de jeu courantes, ce qui permet de voir comment la théorie s'applique à des scénarios concrets de développement de jeux.

## Structure du Projet
Le projet est organisé en chapitres, chacun couvrant différents aspects des relations UML. Chaque chapitre explore un concept fondamental de la modélisation UML et son application dans le développement de jeux:

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

### Chapitre 5: Interfaces et Héritage
Ce chapitre aborde les concepts d'interfaces et d'héritage, qui sont fondamentaux pour créer des hiérarchies de classes et implémenter le polymorphisme. Ces concepts permettent de créer des systèmes flexibles et extensibles.

- **Exemple 1**: Interfaces - Gobelin Multi-Rôles - Utilisation des interfaces pour permettre à une entité d'avoir plusieurs comportements
- **Exemple 2**: Héritage + Interfaces - NPCs Avancés - Combinaison de l'héritage et des interfaces pour créer un système de PNJ (personnages non-joueurs) complexe et modulaire

## Comment Utiliser ce Projet
1. Clonez le dépôt sur votre machine locale
2. Ouvrez le projet dans Visual Studio ou votre IDE C# préféré
3. Compilez le projet avec `dotnet build`
4. Exécutez l'application avec `dotnet run`
5. Un menu interactif vous permettra de sélectionner et d'exécuter les différents exemples et exercices (si tout va bien!!)

Chaque exemple et exercice est conçu pour être autonome et illustrer clairement un concept spécifique. Le code est abondamment commenté pour faciliter la compréhension des principes UML mis en œuvre.

## Focus sur l'Exercice 1 du Chapitre 3: Système de Gestion d'Aéroline
Cet exercice complet illustre les concepts d'agrégation, de composition et d'association dans un système de gestion d'aéroline. Il s'agit d'un cas d'étude approfondi qui montre comment ces différentes relations UML peuvent être combinées pour modéliser un système complexe et réaliste.

### Types de Relations Illustrées:
- **Agrégation**: Une aéroline possède des avions, mais ces avions peuvent exister indépendamment et être transférés à une autre aéroline.
- **Composition**: Un avion contient des équipements qui n'ont pas d'existence propre en dehors de l'avion.
- **Association simple**: Un vol est opéré par un avion, mais les deux entités ont des cycles de vie indépendants.
- **Association many-to-many**: Un pilote peut être qualifié pour piloter plusieurs types d'avions, et un type d'avion peut être piloté par plusieurs pilotes.

### Classes Principales:
- **Aeroline**: Classe centrale qui gère les avions, pilotes, routes et vols. Elle illustre l'agrégation avec ses avions et pilotes.
- **Avion**: Représente un avion avec ses équipements (composition) et maintenances (association). Démontre comment implémenter une relation de composition.
- **Pilote**: Représente un pilote qualifié pour piloter certains avions (many-to-many). Montre comment implémenter une relation many-to-many.
- **Aeroport**: Représente un aéroport qui peut être le départ ou l'arrivée de routes. Illustre les associations bidirectionnelles.
- **Route**: Représente une route aérienne entre deux aéroports. Montre comment gérer les relations entre trois classes (Route, Aeroport, Vol).
- **Vol**: Représente un vol qui suit une route avec un avion spécifique. Démontre les associations multiples.
- **Passager**: Représente un passager qui peut faire des réservations. Illustre l'association avec cardinalité 1 à plusieurs.
- **Reservation**: Représente une réservation de vol (composition avec Vol). Montre comment implémenter une relation de composition avec cycle de vie dépendant.
- **Equipement**: Représente un équipement d'avion (composition avec Avion). Illustre la composition pure.
- **Maintenance**: Représente une opération de maintenance sur un avion. Montre une association simple.

### Questions de Réflexion Traitées:
1. Comment gérer le transfert d'un avion d'une aéroline à une autre? (Agrégation vs Composition)
2. Quelle est la différence entre la relation Avion-Equipement (composition) et Avion-Maintenance (association)?
3. Comment implémenter correctement une relation many-to-many entre Pilote et Avion?

### Diagramme UML:
Le diagramme UML complet est disponible dans le fichier `ProjetVS/Solutions/Chapitre3-Exercice1-Diagramme.md`. Il illustre visuellement toutes les relations entre les classes et leurs cardinalités.

### Démonstration:
La classe `AerolineDemo` illustre l'utilisation de toutes ces classes et leurs relations dans un scénario concret. Elle montre comment:
- Créer une aéroline et y ajouter des avions et des pilotes
- Établir des routes entre aéroports
- Planifier des vols sur ces routes
- Gérer les réservations de passagers
- Effectuer des opérations de maintenance sur les avions
- Transférer un avion d'une aéroline à une autr
## Prérequis
- .NET 5.0 ou supérieur
- Connaissances de base en C# et en programmation orientée objet

## Contribution
Les contributions sont les bienvenues! N'hésitez pas à soumettre des pull requests pour ajouter de nouveaux exemples ou améliorer les existants.
