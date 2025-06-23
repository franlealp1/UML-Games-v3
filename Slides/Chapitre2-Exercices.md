# 🎮 Exercices - Chapitre 2 : Relations entre Classes

## 🎯 Exercice 1 : Système de Missions et Récompenses

### Contexte
Dans **Mass Effect**, le Commandant Shepard peut accepter plusieurs missions données par les NPCs de la galaxie. Chaque mission peut être acceptée par un seul Shepard, et Shepard peut accepter plusieurs missions simultanément.

### Relations à modéliser
1. **Shepard ↔ Mission** : Shepard peut accepter plusieurs missions, et chaque mission appartient à un seul Shepard
2. **Mission ↔ Récompense** : Une mission peut donner plusieurs récompenses (crédits, XP, armes, améliorations)

### Exigences
- Créez les classes `Shepard`, `Mission`, et `Récompense`
- Implémentez les associations :
  - Shepard ↔ Mission (one-to-many)
  - Mission ↔ Récompense (one-to-many)
- Ajoutez des méthodes pour :
  - Accepter une mission
  - Terminer une mission et recevoir les récompenses
  - Consulter les missions de Shepard
  - Consulter les récompenses d'une mission

### Objectif pédagogique
- Comprendre les associations one-to-many simples
- Gérer les workflows de missions
- Implémenter des systèmes de progression

---

## 🎯 Exercice 2 : Système d'Athlétisme et Courses

### Contexte
Dans **Wii Sports**, les Miis (personnages du joueur) peuvent participer à plusieurs épreuves d'athlétisme (100m, 200m, saut en longueur, etc.). Un Mii peut participer à plusieurs épreuves, et une épreuve peut avoir plusieurs Miis participants.

### Relations à modéliser
1. **Mii ↔ Épreuve** : Un Mii peut participer à plusieurs épreuves, et une épreuve peut avoir plusieurs Miis
2. **Épreuve ↔ Épreuve** : Une épreuve peut être un prérequis pour une autre épreuve (ex: qualification pour finale)

### Exigences
- Créez les classes `Mii`, `Épreuve`, et `Participation`
- Implémentez les associations :
  - Mii ↔ Épreuve (many-to-many avec classe d'association)
  - Épreuve ↔ Épreuve (association réflexive)
- La classe d'association `Participation` doit contenir :
  - Temps réalisé
  - Position finale
  - Qualification (oui/non)
- Ajoutez des méthodes pour :
  - Inscrire un Mii à une épreuve
  - Enregistrer le résultat d'un Mii
  - Consulter les épreuves d'un Mii
  - Consulter les participants d'une épreuve

### Objectif pédagogique
- Comprendre les associations many-to-many avec classe d'association
- Gérer les associations réflexives
- Implémenter des systèmes de qualification

---

## 🎯 Exercice 3 : Système de Guildes et Membres

### Contexte
Dans un jeu multijoueur, les joueurs peuvent rejoindre des guildes. Une guilde peut avoir plusieurs membres, et un joueur ne peut appartenir qu'à une seule guilde à la fois.

### Relations à modéliser
1. **Guilde ↔ Joueur** : Association one-to-many
2. **Guilde ↔ Guilde** : Association réflexive (alliances entre guildes)

### Exigences
- Créez les classes `Guilde` et `Joueur`
- Implémentez l'association réflexive pour les alliances
- Ajoutez des méthodes pour :
  - Rejoindre une guilde
  - Quitter une guilde
  - Former une alliance
  - Consulter les membres d'une guilde
  - Consulter les alliances d'une guilde

### Objectif pédagogique
- Comprendre les associations réflexives
- Gérer les contraintes de cardinalité
- Implémenter des relations hiérarchiques

---

## 🎯 Exercice 4 : Système de Crafting et Recettes

### Contexte
Dans un jeu de survie, les joueurs peuvent créer des objets en utilisant des recettes. Une recette nécessite plusieurs ingrédients et peut créer plusieurs produits.

### Relations à modéliser
1. **Recette ↔ Ingredient** : Association many-to-many avec classe d'association (quantité requise)
2. **Recette ↔ Produit** : Association one-to-many (une recette peut créer plusieurs produits)

### Exigences
- Créez les classes `Recette`, `Ingredient`, `Produit`, et `RecetteIngredient`
- La classe d'association doit contenir la quantité d'ingrédient requise
- Implémentez des méthodes pour :
  - Vérifier si un joueur peut créer une recette
  - Consommer les ingrédients et créer les produits
  - Consulter les recettes disponibles

### Objectif pédagogique
- Comprendre les associations complexes
- Gérer les quantités et ressources
- Implémenter des systèmes de validation 