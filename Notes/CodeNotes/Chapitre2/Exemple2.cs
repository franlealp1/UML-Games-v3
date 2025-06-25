using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string _name;
    private int _level;
    private List<Score> _scores;
    public Player(string name, int level)
    {
        _name = name;
        _level = level;
        _scores = new List<Score>();
    }
    public string Name => _name;
    public int Level => _level;
    public IReadOnlyList<Score> Scores => _scores.AsReadOnly();
    public void SetScore(Score score)
    {
        var existing = _scores.FirstOrDefault(s => s.TrackName == score.TrackName);
        if (existing != null)
        {
            _scores.Remove(existing);
        }
        _scores.Add(score);
        Console.WriteLine($"Score ajouté pour {_name} sur {score.TrackName} : {score.Points} points");
    }
    public Score? GetScore(string track)
    {
        return _scores.FirstOrDefault(s => s.TrackName == track);
    }
    public List<Score> GetAllScores()
    {
        return new List<Score>(_scores);
    }
    public Score? GetBestScore()
    {
        return _scores.OrderByDescending(s => s.Points).FirstOrDefault();
    }
}

public class Score
{
    private int _points;
    private float _time;
    private string _trackName;
    public Score(int points, float time, string trackName)
    {
        _points = points;
        _time = time;
        _trackName = trackName;
    }
    public int Points => _points;
    public float Time => _time;
    public string TrackName => _trackName;
    public override string ToString()
    {
        return $"Piste : {_trackName}, Points : {_points}, Temps : {_time}s";
    }
}

public static class Exemple2
{
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