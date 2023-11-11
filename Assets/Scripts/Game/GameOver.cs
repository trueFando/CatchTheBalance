using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _starsText;

    public void OnGameOver()
    {
        int score = FindObjectOfType<ScoreKeeper>().Score;
        _scoreText.text = $"Score {score}";

        int best = PlayerPrefs.GetInt("record");
        if (score > best)
        {
            PlayerPrefs.SetInt("record", score);
            best = score;
        }
        _bestScoreText.text = $"Best {best}";

        int stars = PlayerPrefs.GetInt("stars");
        stars += score;
        _starsText.text = stars.ToString();
        PlayerPrefs.SetInt("stars", stars);
    }
}
