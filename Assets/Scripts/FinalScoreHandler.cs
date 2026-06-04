using TMPro;
using UnityEngine;

public class FinalScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    GameManager _gameManager;

    void Start()
    {
        scoreText.enabled = false;
        highScoreText.enabled = false;
        _gameManager = GameManager.Instance;
        _gameManager.OnGameOver.AddListener(ShowFinalScore);
    }

    void ShowFinalScore()
    {
        scoreText.enabled = true;
        highScoreText.enabled = true;
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    void HideFinalScore()
    {
        scoreText.enabled = false;
        highScoreText.enabled = false;
    }
}
