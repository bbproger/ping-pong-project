using System;
using UnityEngine;

namespace Service.Score
{
    public class ScoreService
    {
        private const string HighScoreKey = "HighScore";
        private int _highScore;
        public int Score { get; private set; }
        public int HighScore => PlayerPrefs.GetInt(HighScoreKey, 0);

        public event Action<int> OnScoreChanged;
        public event Action<int> OnHighScoreChanged;

        public void AddScore(int score)
        {
            Score += score;
            OnScoreChanged?.Invoke(Score);

            if (Score > HighScore)
            {
                PlayerPrefs.SetInt(HighScoreKey, Score);
                PlayerPrefs.Save();
                OnHighScoreChanged?.Invoke(Score);
            }
        }

        public void ResetScore()
        {
            Score = 0;
            OnScoreChanged?.Invoke(Score);
        }
    }
}