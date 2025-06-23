# 🎮 Exercices - Chapitre 1

## 🎯 Exercice 1 : Les Bases des Classes
Créez une classe `Weapon` qui représente une arme basique :
- Attributs : nom, dégâts
- Méthodes : afficher info
- **Objectif** : Comprendre la création d'une classe simple et l'affichage
- **Consigne** : Créez le diagramme UML puis implémentez la classe

## 🎯 Exercice 2 : Validation et Encapsulation
Créez une classe `HealthPotion` qui représente une potion de soin :
- Attributs : 
  - Quantité de guérison (valeur entre 0 et 100), choisie lors de la création
- Méthodes : 
  - Utiliser (consomme la potion et retourne la quantité de guérison)
  - Obtenir la quantité de guérison
- **Objectif** : Apprendre à valider les données et protéger les attributs
- **Consigne** : Créez le diagramme UML en incluant les méthodes de validation

On verra après comment intégrer la potion pour l'utilisation avec un Personnage

## 🎯 Exercice 3 : États et Comportements
Créez une classe `Chest` (coffre) :
- États possibles : fermé, ouvert, verrouillé
- Contenu : liste d'objets (max 5)
- Méthodes :
  - Ouvrir (uniquement si non verrouillé)
  - Verrouiller/Déverrouiller
  - Ajouter/Retirer des objets (uniquement si ouvert)
- **Objectif** : Gérer des états et comportements conditionnels
- **Consigne** : 
  1. Réfléchissez à la meilleure façon de représenter les états
  2. Implémentez les règles de transition entre états

## 🎯 Exercice 4 : Mini-Projet Combat
Créez une classe `Wizard` (magicien) pour un jeu de combat tour par tour :

1. **Attributs** :
   - Nom du magicien
   - Points de vie (max 100)
   - Points de mana (max 100)
   - Type de magie préféré (feu, glace ou éclair)
   - Niveau de puissance (1-10)

2. **Méthodes** :
   - Attaquer (coûte du mana, fait des dégâts basés sur le type et la puissance)
   - Méditer (récupère du mana)
   - Se soigner (utilise du mana pour restaurer des PV)
   - Afficher état (montre PV, mana et statut)

3. **Règles de gameplay** :
   - L'attaque coûte 10 points de mana
   - La méditation restaure 20 points de mana
   - Les soins coûtent 30 points de mana et restaurent 40 PV
   - Les dégâts sont calculés : puissance × 5 + bonus du type
   - Bonus par type :
     * Feu : +3 dégâts
     * Glace : +2 dégâts et 20% de chance de geler
     * Éclair : +4 dégâts

4. **Système de combat** :
   - Les magiciens jouent chacun leur tour
   - À son tour, un magicien peut :
     * Attaquer l'adversaire
     * Se soigner
     * Méditer pour récupérer du mana
   - Un magicien est vaincu si ses PV atteignent 0
   - Le combat continue jusqu'à ce qu'un magicien soit vaincu

**Consignes** :
1. Créez le diagramme UML de la classe `Wizard` et de l'énumération `MagicType`
2. Implémentez la classe avec toutes ses méthodes
3. Créez un programme de test qui :
   - Crée deux magiciens de types différents
   - Simule un combat tour par tour
   - Affiche l'état des magiciens après chaque action
   - Annonce le vainqueur à la fin

## ✅ Points Clés à Respecter
1. **UML d'abord** : Commencez par le diagramme de classes
2. **Encapsulation** : Utilisez les bons niveaux de visibilité
3. **Validation** : Vérifiez toutes les valeurs entrantes
4. **Documentation** : Commentaires XML sur les méthodes publiques
5. **Tests** : Démontrez tous les cas d'utilisation

Chaque exercice introduit de nouveaux concepts :
- Ex.1 : Structure de base
- Ex.2 : Validation et encapsulation
- Ex.3 : États et comportements complexes
- Ex.4 : Interaction entre classes
