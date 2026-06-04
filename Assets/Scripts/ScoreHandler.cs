using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private new Camera camera;
    private int _score;
    private int _highScore;
    private string _fileName;
    private GameManager _gameManager;

    public int GetScore()
    {
        return _score;
    }

    private void Awake()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Start()
    {
        camera = Camera.main;
        _gameManager = GameManager.Instance;
        _gameManager.OnGameOver.AddListener(SaveScore);
        _gameManager.OnGameOver.AddListener(HideScore);
    }

    private void Update()
    {
        _score = (int)camera.transform.position.y;
        scoreText.text = "Score : " + _score;
        highScoreText.text = "High Score : " + _highScore;
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", _score);
        if (PlayerPrefs.GetInt("HighScore") < _score)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }
    
    private void ShowScore()
    {
        scoreText.enabled = true;
        highScoreText.enabled = true;
    }    
    
    private void HideScore()
    {
        scoreText.enabled = false;
        highScoreText.enabled = false;
    }
}