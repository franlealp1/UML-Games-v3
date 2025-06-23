# Diseño y Modelado de Videojuegos con UML

> Este curso utiliza el desarrollo de videojuegos como contexto para aprender UML y principios de diseño de software. 
Implementaremos ejemplos simples en C# consola, enfocándonos en entender los conceptos fundamentales.

## Metodología del Curso
- Cada día seguimos esta estructura:
  1. Teoría con ejemplos prácticos del mundo de los juegos (1h)
  2. Desarrollo conjunto del ejemplo (profesor + alumnos) (2h)
  3. Ejercicios prácticos para reforzar lo aprendido (3h)

## Día 1: Fundamentos de UML

### Mañana (3 horas)
- Teoría: Introducción a UML (1h)
  - ¿Qué es UML y por qué lo usamos?
  - Diagramas de clases básicos
  - Clases, atributos y métodos

- Ejemplo práctico: Personaje de juego (2h)
  ```mermaid
  classDiagram
      class Character {
          -string name
          -int health
          -int energy
          +Move()
          +Attack()
          +TakeDamage(int damage)
      }
      class Weapon {
          -string name
          -int damage
          +Use()
      }
      Character "1" o-- "0..1" Weapon
  ```


- Ejercicios prácticos (3h)
  1. Crear diagrama UML de un personaje simple
  2. Implementar el código en C#
  3. Documentar con mejores prácticas
  4. Testing en consola

## Día 2: Relaciones entre Objetos

### Mañana (3 horas)
- Teoría: Relaciones en UML (1h)
  - Asociación simple
  - Agregación y composición
  - Cardinalidad (1-1, 1-*, *-*)

- Ejemplo práctico: Sistema de inventario (2h)
  ```mermaid
  classDiagram
      class Player {
          -Inventory inventory
          -Weapon currentWeapon
          +Attack()
          +UseItem()
      }
      class Weapon {
          -int damage
          -float range
          +Use()
      }
      class Inventory {
          -List~Item~ items
          +AddItem()
          +RemoveItem()
      }
      class Item {
          -string name
          -string description
          +Use()
      }
      Player "1" o-- "1" Inventory
      Player "1" o-- "0..1" Weapon
      Inventory "1" o-- "*" Item
  ```

### Tarde (3 horas)
- Ejercicios prácticos (3h)
  1. Diseñar sistema de equipamiento
  2. Implementar sistema de armas
  3. Testing con diferentes escenarios

## Día 3: Composición y Modularidad

### Mañana (3 horas)
- Teoría: Composición sobre herencia (1h)
  - Por qué preferimos composición
  - Sistemas modulares
  - Responsabilidad única

- Ejemplo práctico: Sistema de componentes (2h)
  ```mermaid
  classDiagram
      class Character {
          -List~Component~ components
          +Update()
          +AddComponent()
      }
      class Component {
          +Update()
      }
      class HealthComponent {
          -int currentHealth
          -int maxHealth
          +TakeDamage()
          +Heal()
      }
      class CombatComponent {
          -int damage
          -float range
          +Attack()
      }
      Character "1" o-- "*" Component
      Component <|-- HealthComponent
      Component <|-- CombatComponent
  ```

### Tarde (3 horas)
- Ejercicios prácticos (3h)
  1. Diseñar sistema de componentes propio
  2. Implementar diferentes tipos de componentes
  3. Crear un personaje usando composición

## Día 4: Patrones Básicos

### Mañana (3 horas)
- Teoría: Patrones comunes (1h)
  - Singleton para GameManager
  - Observer para eventos
  - Factory para crear objetos

- Ejemplo práctico: Sistema de eventos (2h)
  ```mermaid
  classDiagram
      class GameManager {
          -static GameManager instance
          +GetInstance()
          +NotifyGameEvent()
      }
      class IObserver {
          +OnNotify()
      }
      class ScoreSystem {
          -int currentScore
          +UpdateScore()
          +OnNotify()
      }
      GameManager --> IObserver
      IObserver <|.. ScoreSystem
  ```

### Tarde (3 horas)
- Ejercicios prácticos (3h)
  1. Implementar sistema de puntuación
  2. Crear fábrica de enemigos simple
  3. Conectar sistemas usando eventos

## Día 5: Integración de Conceptos

### Mañana (3 horas)
- Repaso y consolidación (1h)
  - Revisar todos los diagramas
  - Resolver dudas
  - Mejores prácticas

- Ejemplo práctico integrador (2h)
  ```mermaid
  classDiagram
      class Game {
          -GameManager manager
          -List~Character~ characters
          +Update()
      }
      class Character {
          -List~Component~ components
          -Inventory inventory
          +Update()
      }
      class Inventory {
          -List~Item~ items
          +AddItem()
          +UseItem()
      }
      Game "1" o-- "1" GameManager
      Game "1" o-- "*" Character
      Character "1" o-- "1" Inventory
  ```

### Tarde (3 horas)
- Ejercicio final (3h)
  1. Diseñar un pequeño sistema de juego
  2. Implementar la funcionalidad básica
  3. Presentar y explicar las decisiones de diseño

## Recursos
- Ejemplos de código del curso
- Diagramas UML de referencia
- Documentación de C#
