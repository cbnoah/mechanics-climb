using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameOverUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Image background;
    [SerializeField] private GameObject homeButton;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.OnGameOver.AddListener(GameOver);
        gameOverText.enabled = false;
        background.enabled = false;
        homeButton.SetActive(false);
    }

    void GameOver()
    {
        gameOverText.enabled = true;
        background.enabled = true;
        homeButton.SetActive(true);
    }
}