using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UnityEvent OnGameOver = new UnityEvent();

    private bool _isPlaying = true;

    [SerializeField] AudioClip deathSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
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
        SoundFXManager.Instance.PlaySound(deathSound, transform, 0.1f);
        Debug.Log("GameOver");
        OnGameOver.Invoke();
    }
}