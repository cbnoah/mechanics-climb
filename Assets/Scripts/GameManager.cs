using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UnityEvent OnGameOver = new UnityEvent();

    private bool _isPlaying = true;

    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioSource backgroundMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool GetIsPlaying()
    {
        return _isPlaying;
    }

    public void SetIsPlaying(bool gameState)
    {
        _isPlaying = gameState;
    }

    public void GameOver()
    {
        _isPlaying = false;
        backgroundMusic.Stop();
        SoundFXManager.Instance.PlaySound(deathSound, transform, 0.1f);
        OnGameOver.Invoke();
    }

    public void NewGame()
    {
        _isPlaying = true;
        backgroundMusic.Play();
    }
}