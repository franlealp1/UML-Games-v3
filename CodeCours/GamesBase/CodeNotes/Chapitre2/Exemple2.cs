// === Exemple 2 : Joueur et Scores (Association 1 à Plusieurs) ===
// Un joueur peut avoir des scores différents dans différentes épreuves (par exemple, Mario Kart)
// UML : Player "1" --> "*" Score : has

using System;
using System.Collections.Generic;
using System.Linq;

namespace UMLGames.Examples.Chapitre2
{
    /// <summary>
    /// Classe représentant un joueur qui possède plusieurs scores (relation 1 à plusieurs).
    /// 
    /// Implémentation de la relation :
    /// - La liste 'scores' dans Player représente l'association 1 à plusieurs avec Score.
    /// </summary>
    public class Player
    {
        private string name;
        private int level;
        // --- Début de l'implémentation de la relation 1 à plusieurs ---
        /// <summary>
        /// Liste des scores associés à ce joueur (relation 1 à plusieurs)
        /// </summary>
        private List<Score> scores;
        // --- Fin de l'implémentation de la relation 1 à plusieurs ---

        public Player(string name, int level)
        {
            this.name = name;
            this.level = level;
            this.scores = new List<Score>();
        }

        public string Name => name;
        public int Level => level;
        // Lecture seule : la liste ne peut être modifiée que par les méthodes de la classe
        public IReadOnlyList<Score> Scores => scores.AsReadOnly();

        /// <summary>
        /// Ajoute ou met à jour un score pour une piste donnée.
        /// </summary>
        public void SetScore(Score score)
        {
            var existing = scores.FirstOrDefault(s => s.TrackName == score.TrackName);
            if (existing != null)
            {
                scores.Remove(existing);
            }
            scores.Add(score);
            Console.WriteLine($"Score ajouté pour {name} sur {score.TrackName} : {score.Points} points");
        }

        /// <summary>
        /// Récupère le score pour une piste donnée.
        /// </summary>
        public Score GetScore(string track)
        {
            return scores.FirstOrDefault(s => s.TrackName == track);
        }

        /// <summary>
        /// Récupère tous les scores du joueur.
        /// </summary>
        public List<Score> GetAllScores()
        {
            return new List<Score>(scores);
        }

        /// <summary>
        /// Récupère le meilleur score du joueur.
        /// </summary>
        public Score GetBestScore()
        {
            return scores.OrderByDescending(s => s.Points).FirstOrDefault();
        }
    }

    /// <summary>
    /// Classe représentant un score sur une piste donnée.
    /// </summary>
    public class Score
    {
        private int points;
        private float time;
        private string trackName;

        public Score(int points, float time, string trackName)
        {
            this.points = points;
            this.time = time;
            this.trackName = trackName;
        }

        public int Points => points;
        public float Time => time;
        public string TrackName => trackName;

        public override string ToString()
        {
            return $"Piste : {trackName}, Points : {points}, Temps : {time}s";
        }
    }

    // === Classe de démonstration pour l'Exemple 2 ===
    public static class Exemple2
    {
        /// <summary>
        /// Méthode de démonstration pour l'exemple 2 (Joueur et Scores)
        /// </summary>
        public static void Demo()
        {
            Console.WriteLine("--- Démonstration Exemple 2 : Joueur et Scores (1 à plusieurs) ---");
            Player mario = new Player("Mario", 5);
            Score score1 = new Score(1500, 120.5f, "Copa Champignon");
            Score score2 = new Score(2000, 95.2f, "Copa Étoile");
            Score score3 = new Score(1800, 110.0f, "Copa Éclair");

            mario.SetScore(score1);
            mario.SetScore(score2);
            mario.SetScore(score3);

            Console.WriteLine($"Meilleur score de {mario.Name} : {mario.GetBestScore()}");
            Console.WriteLine("Tous les scores :");
            foreach (var s in mario.GetAllScores())
            {
                Console.WriteLine(s);
            }
        }
    }
} 